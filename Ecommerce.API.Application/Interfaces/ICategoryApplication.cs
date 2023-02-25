using Ecommerce.API.Domain.Validations.Base;

namespace Ecommerce.API.Application.Interfaces
{
    public interface ICategoryApplication
    {
        Task<Response<List<string>>> GetAllAsync();
    }
}
