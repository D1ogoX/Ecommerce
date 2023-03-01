using Ecommerce.Interfaces.DataConnector;
using Newtonsoft.Json;
using System.Net.Http.Headers;

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

        public async Task<bool> PostAsync (string url, string json)
        {
            string BaseAddress = client.BaseAddress.AbsoluteUri;

            var buffer = System.Text.Encoding.UTF8.GetBytes(json);
            var byteContent = new ByteArrayContent(buffer);

            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(BaseAddress + url, byteContent);

            if (response.IsSuccessStatusCode)
                return true;

            return false;
        }

        public async Task<string> AuthenticationAsync(string url, string username, string password)
        {
            string BaseAddress = client.BaseAddress.AbsoluteUri;

            var data = JsonConvert.SerializeObject(new Models.AuthModel() { Username = username, Password = password });

            var buffer = System.Text.Encoding.UTF8.GetBytes(data);
            var byteContent = new ByteArrayContent(buffer);

            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(BaseAddress + url, byteContent);

            string json = await response.Content.ReadAsStringAsync();

            return json;
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

        public async Task<string> GetWithTokenAsync(string url, string token)
        {
            string BaseAddress = client.BaseAddress.AbsoluteUri;

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync(BaseAddress + url);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();

            else
                throw new Exception("Request error: " + response.StatusCode.ToString());
        }

        public async Task<bool> PatchAsync(string url, string json)
        {
            string BaseAddress = client.BaseAddress.AbsoluteUri;

            var buffer = System.Text.Encoding.UTF8.GetBytes(json);
            var byteContent = new ByteArrayContent(buffer);

            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PatchAsync(BaseAddress + url, byteContent);

            if (response.IsSuccessStatusCode)
                return true;

            return false;
        }
    }
}
