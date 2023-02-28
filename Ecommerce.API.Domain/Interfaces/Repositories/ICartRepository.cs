using Ecommerce.API.Domain.Models;

namespace Ecommerce.API.Domain.Interfaces.Repositories
{
    public interface ICartRepository
    {
        Task<List<CartModel>> GetUserCartAsync(int userId);
        Task AddCartAsync(CartModel cart);
    }
}
