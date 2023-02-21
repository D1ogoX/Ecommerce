using Ecommerce.API.Application.DataContract.Response.Product;
using Ecommerce.API.Domain.Validations.Base;

namespace Ecommerce.API.Application.Interfaces
{
    public interface IProductApplication
    {
        Task<Response<ProductResponse>> GetByIdAsync(int Id);
        Task<Response<List<ProductResponse>>> GetAllAsync();
    }
}
