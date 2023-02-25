using Ecommerce.API.Domain.Models;

namespace Ecommerce.API.Domain.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<string>> GetAllAsync();
    }
}
