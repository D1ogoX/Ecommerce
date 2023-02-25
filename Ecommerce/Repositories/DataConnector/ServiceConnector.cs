using Ecommerce.Interfaces.DataConnector;

namespace Ecommerce.Repositories.DataConnector
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
            string BaseAddress = client.BaseAddress.AbsoluteUri;

            var response = await client.GetAsync(BaseAddress + url);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();

            else
                throw new Exception("Request error: " + response.StatusCode.ToString());
        }
    }
}
