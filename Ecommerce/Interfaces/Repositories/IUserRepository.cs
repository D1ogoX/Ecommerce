using Ecommerce.Models;

namespace Ecommerce.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<AuthResponseModel> AuthenticationAsync(string username, string password);
        Task<List<UserModel>> GetAllAsync();
    }
}
