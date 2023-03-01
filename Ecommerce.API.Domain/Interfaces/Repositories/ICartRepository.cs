using Ecommerce.API.Domain.Models;

namespace Ecommerce.API.Domain.Interfaces.Repositories
{
    public interface ICartRepository
    {
        Task<List<CartModel>> GetUserCartAsync(int userId);
        Task<CartModel> GetCartByIdAsync(int cartId);
        Task AddCartAsync(CartModel cart);
        Task UpdateCartAsync(CartModel cart);
    }
}
