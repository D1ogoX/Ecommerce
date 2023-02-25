namespace Ecommerce.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<string>> GetAllAsync();
    }
}
