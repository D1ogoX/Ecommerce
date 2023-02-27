using Ecommerce.API.Domain.Interfaces.Repositories;
using Ecommerce.API.Domain.Interfaces.Repositories.DataConnector;
using Ecommerce.API.Domain.Models;
using Newtonsoft.Json;

namespace Ecommerce.API.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IServiceConnector _serviceConnector;

        public UserRepository(IServiceConnector serviceConnector)
        {
            _serviceConnector = serviceConnector;
        }

        public async Task<string> AuthenticationAsync(string password, string username)
        {
            var data = await _serviceConnector.AuthenticationAsync("auth/login", username, password);

            return data;
        }

        public async Task<List<UserModel>> GetAllAsync()
        {
            var data = await _serviceConnector.GetAsync("users");

            return JsonConvert.DeserializeObject<List<UserModel>>(data);
        }

        public Task<UserModel> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserModel> GetByUsernameAsync(string username)
        {
            var allUsers = await GetAllAsync();

            return allUsers.Where(x => x.username == username).FirstOrDefault();
        }

        public Task InsertAsync(UserModel user)
        {
            throw new NotImplementedException();
        }
    }
}
