namespace Ecommerce.Interfaces.DataConnector
{
    public interface IServiceConnector
    {
        Task<string> AuthenticationAsync(string url, string username, string password);
        Task<string> GetWithTokenAsync(string url, string token);
        Task<string> GetAsync(string url);
        Task<bool> PostAsync(string url, string json);
        Task<bool> PatchAsync(string url, string json);
    }
}
