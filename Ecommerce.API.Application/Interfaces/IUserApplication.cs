using Ecommerce.API.Application.DataContract.Request.User;
using Ecommerce.API.Application.DataContract.Response.User;
using Ecommerce.API.Domain.Models;
using Ecommerce.API.Domain.Validations.Base;

namespace Ecommerce.API.Application.Interfaces
{
    public interface IUserApplication
    {
        Task<Response> InsertAsync(UserModel user);
        Task<Response<AuthResponse>> AuthenticationAsync(AuthRequest auth);
        Task<Response<UserResponse>> GetByUsernameAsync(string username);
        Task<Response<UserResponse>> GetByIdAsync(int Id);
        Task<Response<List<UserResponse>>> GetAllAsync();
    }
}
