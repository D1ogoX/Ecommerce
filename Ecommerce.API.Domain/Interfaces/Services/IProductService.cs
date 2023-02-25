using Ecommerce.API.Domain.Models;
using Ecommerce.API.Domain.Validations.Base;

namespace Ecommerce.API.Domain.Interfaces.Services
{
    public interface IProductService
    {
        Task<Response<ProductModel>> GetByIdAsync(int Id);
        Task<Response<List<ProductModel>>> GetAllByCategoryAsync(string category);
        Task<Response<List<ProductModel>>> GetAllAsync();
    }
}
