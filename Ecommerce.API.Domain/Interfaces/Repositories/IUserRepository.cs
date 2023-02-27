using Ecommerce.API.Domain.Models;

namespace Ecommerce.API.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task InsertAsync(UserModel user);
        Task<string> AuthenticationAsync(string password, string username);
        Task<UserModel> GetByUsernameAsync(string username);
        Task<UserModel> GetByIdAsync(int Id);
        Task<List<UserModel>> GetAllAsync();
    }
}
