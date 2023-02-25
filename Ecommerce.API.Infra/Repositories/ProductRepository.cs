using Ecommerce.API.Domain.Interfaces.Repositories;
using Ecommerce.API.Domain.Interfaces.Repositories.DataConnector;
using Ecommerce.API.Domain.Models;
using Newtonsoft.Json;

namespace Ecommerce.API.Infra.Repositories
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
            var data = await _serviceConnector.GetAsync("products");

            return JsonConvert.DeserializeObject<List<ProductModel>>(data);
        }

        public async Task<List<ProductModel>> GetAllByCategoryAsync(string category)
        {
            var data = await _serviceConnector.GetAsync($"products/category/{category}");

            return JsonConvert.DeserializeObject<List<ProductModel>>(data);
        }

        public async Task<ProductModel> GetByIdAsync(int Id)
        {
            var data = await _serviceConnector.GetAsync($"products/{Id}");

            return JsonConvert.DeserializeObject<ProductModel>(data);
        }
    }
}
