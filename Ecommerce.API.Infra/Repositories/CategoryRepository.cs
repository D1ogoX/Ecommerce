using Ecommerce.API.Domain.Interfaces.Repositories;
using Ecommerce.API.Domain.Interfaces.Repositories.DataConnector;
using Newtonsoft.Json;

namespace Ecommerce.API.Infra.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IServiceConnector _serviceConnector;

        public CategoryRepository(IServiceConnector serviceConnector)
        {
            _serviceConnector = serviceConnector;
        }

        public async Task<List<string>> GetAllAsync()
        {
            var data = await _serviceConnector.GetAsync("products/categories");

            return JsonConvert.DeserializeObject<List<string>>(data);
        }
    }
}
