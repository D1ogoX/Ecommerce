using Ecommerce.API.Application.DataContract.Request.Cart;
using Ecommerce.API.Application.DataContract.Response.Cart;
using Ecommerce.API.Domain.Validations.Base;

namespace Ecommerce.API.Application.Interfaces
{
    public interface ICartApplication
    {
        Task<Response<List<CartResponse>>> GetUserCartAsync(int userId);
        Task<Response<CartResponse>> GetCartByIdAsync(int cartId);
        Task<Response> AddCartAsync(CartRequest cart);
        Task<Response> UpdateCartAsync(UpdateCartRequest cart);
    }
}
