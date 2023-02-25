namespace Ecommerce.Interfaces.DataConnector
{
    public interface IServiceConnector
    {
        Task<string> GetAsync(string url);
    }
}
