using Ecommerce.API.Domain.Interfaces.Repositories;
using Ecommerce.API.Domain.Interfaces.Services;
using Ecommerce.API.Domain.Models;
using Ecommerce.API.Domain.Validations.Base;

namespace Ecommerce.API.Domain.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<Response> AddCartAsync(CartModel cart)
        {
            var response = new Response();

            await _cartRepository.AddCartAsync(cart);

            return response;
        }

        public async Task<Response<List<CartModel>>> GetUserCartAsync(int userId)
        {
            var response = new Response<List<CartModel>>();

            var data = await _cartRepository.GetUserCartAsync(userId);
            response.Data = data;
            return response;
        }
    }
}
