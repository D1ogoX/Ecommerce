using Ecommerce.API.Domain.Models;
using Ecommerce.API.Domain.Validations.Base;

namespace Ecommerce.API.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<Response> InsertAsync(UserModel user);
        Task<Response<UserModel>> GetByIdAsync(int Id);
        Task<Response<List<UserModel>>> GetAllAsync();
    }
}
