using Ecommerce.Interfaces.DataConnector;
using Ecommerce.Interfaces.Repositories;
using Ecommerce.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Ecommerce.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IServiceConnector _serviceConnector;

        public UserRepository(IServiceConnector serviceConnector)
        {
            _serviceConnector = serviceConnector;
        }

        public async Task<AuthResponseModel> AuthenticationAsync(string username, string password)
        {
            var data = await _serviceConnector.AuthenticationAsync("api/User/auth", username, password);

            var dataObject = JsonConvert.DeserializeObject<JObject>(data);
            var logged = dataObject.GetValue("data");

            return JsonConvert.DeserializeObject<AuthResponseModel>(logged.ToString());
        }

        public async Task<List<UserModel>> GetAllAsync()
        {
            var data = await _serviceConnector.GetAsync("api/User/All");

            var dataObject = JsonConvert.DeserializeObject<JObject>(data);
            var products = dataObject.GetValue("data");

            return JsonConvert.DeserializeObject<List<UserModel>>(products.ToString());
        }
    }
}
