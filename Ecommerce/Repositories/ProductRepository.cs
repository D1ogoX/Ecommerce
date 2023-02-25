using Ecommerce.Interfaces.DataConnector;
using Ecommerce.Interfaces.Repositories;
using Ecommerce.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Ecommerce.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IServiceConnector _serviceConnector;

        public ProductRepository(IServiceConnector serviceConnector)
        {
            _serviceConnector = serviceConnector;
        }

        public async Task<List<ProductModel>> GetAllAsync()
        {
            var data = await _serviceConnector.GetAsync("api/Product/All");

            var dataObject = JsonConvert.DeserializeObject<JObject>(data);
            var products = dataObject.GetValue("data");

            return JsonConvert.DeserializeObject<List<ProductModel>>(products.ToString());
        }

        public async Task<List<ProductModel>> GetAllByCategoryAsync(string category)
        {
            var data = await _serviceConnector.GetAsync("api/Product/categories/" + category);

            var dataObject = JsonConvert.DeserializeObject<JObject>(data);
            var products = dataObject.GetValue("data");

            return JsonConvert.DeserializeObject<List<ProductModel>>(products.ToString());
        }

        public async Task<ProductModel> GetByIdAsync(int Id)
        {
            var data = await _serviceConnector.GetAsync("api/Product/" + Id);

            var dataObject = JsonConvert.DeserializeObject<JObject>(data);
            var product = dataObject.GetValue("data");

            return JsonConvert.DeserializeObject<ProductModel>(product.ToString());
        }
    }
}
