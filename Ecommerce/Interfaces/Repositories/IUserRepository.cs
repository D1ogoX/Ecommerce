using Ecommerce.Models;

namespace Ecommerce.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAllAsync();
    }
}
