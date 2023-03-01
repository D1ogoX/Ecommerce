using Ecommerce.Models;

namespace Ecommerce.Interfaces.Repositories
{
    public interface ICartRepository
    {
        Task<CartModel> GetCartByUserIdAsync(int userId);
        Task<CartModel> GetCartByIdAsync(int cartId);
        Task<bool> AddCart(CartRequestModel cart);
        Task<bool> UpdateCart(CartUpdateRequestModel cart);
    }
}
