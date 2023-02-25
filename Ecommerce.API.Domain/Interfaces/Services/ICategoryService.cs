using Ecommerce.API.Domain.Models;
using Ecommerce.API.Domain.Validations.Base;

namespace Ecommerce.API.Domain.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<Response<List<string>>> GetAllAsync();
    }
}
