using Ecommerce.API.Domain.Interfaces.Repositories;
using Ecommerce.API.Domain.Interfaces.Repositories.DataConnector;
using Ecommerce.API.Domain.Models;
using Newtonsoft.Json;

namespace Ecommerce.API.Infra.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly IServiceConnector _serviceConnector;
        private readonly IProductRepository _productRepository;

        public CartRepository(IServiceConnector serviceConnector, IProductRepository productRepository)
        {
            _serviceConnector = serviceConnector;
            _productRepository = productRepository;
        }

        public async Task AddCartAsync(CartModel cart)
        {
            var json = JsonConvert.SerializeObject(cart);

            await _serviceConnector.PostAsync("carts", json);

            return;
        }

        public async Task<CartModel> GetCartByIdAsync(int cartId)
        {
            var data = await _serviceConnector.GetAsync($"carts/{cartId}");

            var cart = JsonConvert.DeserializeObject<CartModel>(data);

            foreach (var _products in cart.products)
            {
                _products.product = await _productRepository.GetByIdAsync(_products.productId);
            }

            return cart;
        }

        public async Task<List<CartModel>> GetUserCartAsync(int userId)
        {
            var data = await _serviceConnector.GetAsync($"carts/user/{userId}");

            var cartList = JsonConvert.DeserializeObject<List<CartModel>>(data);

            foreach(var _cart in cartList)
            {
                foreach(var _products in _cart.products)
                {
                    _products.product = await _productRepository.GetByIdAsync(_products.productId);
                }
            }

            return cartList;
        }

        public async Task UpdateCartAsync(CartModel cart)
        {
            var json = JsonConvert.SerializeObject(cart);

            await _serviceConnector.PatchAsync($"carts/{cart.id}", json);

            return;
        }
    }
}
