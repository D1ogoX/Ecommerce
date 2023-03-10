using Ecommerce.Interfaces.DataConnector;
using Ecommerce.Interfaces.Repositories;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Ecommerce.Models;

namespace Ecommerce.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly IServiceConnector _serviceConnector;

        public CartRepository(IServiceConnector serviceConnector)
        {
            _serviceConnector = serviceConnector;
        }

        public async Task<bool> AddCart(CartRequestModel cart)
        {
            var json = JsonConvert.SerializeObject(cart);

            var data = await _serviceConnector.PostAsync("api/cart/Add", json);

            return data;
        }

        public async Task<CartModel> GetCartByIdAsync(int cartId)
        {
            var data = await _serviceConnector.GetAsync("api/Cart/" + cartId);

            var dataObject = JsonConvert.DeserializeObject<JObject>(data);
            var carts = dataObject.GetValue("data");

            return JsonConvert.DeserializeObject<CartModel>(carts.ToString());
        }

        public async Task<CartModel> GetCartByUserIdAsync(int userId)
        {
            var data = await _serviceConnector.GetAsync("api/Cart/user/" + userId);

            var dataObject = JsonConvert.DeserializeObject<JObject>(data);
            var carts = dataObject.GetValue("data");

            return JsonConvert.DeserializeObject<List<CartModel>>(carts.ToString()).First();
        }

        public async Task<bool> UpdateCart(CartUpdateRequestModel cart)
        {
            var json = JsonConvert.SerializeObject(cart);

            var data = await _serviceConnector.PatchAsync("api/cart/update", json);

            return data;
        }
    }
}
