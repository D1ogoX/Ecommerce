using Ecommerce.API.Domain.Models;

namespace Ecommerce.API.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<ProductModel> GetByIdAsync(int Id);
        Task<List<ProductModel>> GetAllAsync();
    }
}
