using Ecommerce.Models;

namespace Ecommerce.Interfaces.Repositories
{
    public interface ICartRepository
    {
        Task<CartModel> GetCartByUserIdAsync(int userId);
        Task<bool> AddCart(CartRequestModel cart);
    }
}
