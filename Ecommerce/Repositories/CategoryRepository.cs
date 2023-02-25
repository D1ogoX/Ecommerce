using Ecommerce.Interfaces.DataConnector;
using Ecommerce.Interfaces.Repositories;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Ecommerce.Repositories
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
            var data = await _serviceConnector.GetAsync("api/Product/categories");

            var dataObject = JsonConvert.DeserializeObject<JObject>(data);
            var categories = dataObject.GetValue("data");

            return JsonConvert.DeserializeObject<List<string>>(categories.ToString());
        }
    }
}
