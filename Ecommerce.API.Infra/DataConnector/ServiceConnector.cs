using Ecommerce.API.Domain.Interfaces.Repositories.DataConnector;
using Ecommerce.API.Domain.Models;
using Newtonsoft.Json;

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

        public async Task<string> AuthenticationAsync(string url, string username, string password)
        {
            string BaseAddress = client.BaseAddress.AbsoluteUri;

            HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod("post"), BaseAddress + url);

            var postParams = new Dictionary<string, string>() { { "username", username }, { "password", password } };

            if (postParams != null)
                requestMessage.Content = new FormUrlEncodedContent(postParams);


            HttpResponseMessage response = await client.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<AuthTokenModel>(apiResponse).token;
            }

            else
                throw new Exception("Request error: " + response.StatusCode.ToString());
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
