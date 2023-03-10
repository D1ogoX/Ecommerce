using Ecommerce.API.Domain.Models;
using Ecommerce.API.Domain.Validations.Base;

namespace Ecommerce.API.Domain.Interfaces.Services
{
    public interface ICartService
    {
        Task<Response<List<CartModel>>> GetUserCartAsync(int userId);
        Task<Response<CartModel>> GetCartByIdAsync(int cartId);
        Task<Response> AddCartAsync(CartModel cart);
        Task<Response> UpdateCartAsync(CartModel cart);
    }
}
