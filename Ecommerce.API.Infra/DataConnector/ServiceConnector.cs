using Ecommerce.API.Domain.Interfaces.Repositories.DataConnector;

namespace Ecommerce.API.Infra.DataConnector
{
    public class ServiceConnector : IServiceConnector
    {
        HttpClient client;

        public ServiceConnector(string url)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
        }

        public async Task<string> GetAsync(string url)
        {
            return await client.GetStringAsync(client.BaseAddress + url);
        }
    }
}
