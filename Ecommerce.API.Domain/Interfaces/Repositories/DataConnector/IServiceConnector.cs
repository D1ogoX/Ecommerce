namespace Ecommerce.API.Domain.Interfaces.Repositories.DataConnector
{
    public interface IServiceConnector
    {
        Task<string> AuthenticationAsync(string url, string username, string password);
        Task<string> GetAsync(string url);
        Task<bool> PostAsync(string url, string json);
        Task<bool> PatchAsync(string url, string json);
    }
}
