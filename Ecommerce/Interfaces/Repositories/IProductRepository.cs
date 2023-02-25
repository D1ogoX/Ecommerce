using Ecommerce.Models;

namespace Ecommerce.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<ProductModel> GetByIdAsync(int Id);
        Task<List<ProductModel>> GetAllByCategoryAsync(string category);
        Task<List<ProductModel>> GetAllAsync();
    }
}
