namespace Ecommerce.API.Domain.Interfaces.Repositories.DataConnector
{
    public interface IServiceConnector
    {
        Task<string> GetAsync(string url);
    }
}
