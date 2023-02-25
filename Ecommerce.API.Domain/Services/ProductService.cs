using Ecommerce.API.Domain.Interfaces.Repositories;
using Ecommerce.API.Domain.Interfaces.Services;
using Ecommerce.API.Domain.Models;
using Ecommerce.API.Domain.Validations.Base;

namespace Ecommerce.API.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Response<List<ProductModel>>> GetAllAsync()
        {
            var response = new Response<List<ProductModel>>();

            var data = await _productRepository.GetAllAsync();
            response.Data = data;
            return response;
        }

        public async Task<Response<List<ProductModel>>> GetAllByCategoryAsync(string category)
        {
            var response = new Response<List<ProductModel>>();

            var data = await _productRepository.GetAllByCategoryAsync(category);
            response.Data = data;
            return response;
        }

        public async Task<Response<ProductModel>> GetByIdAsync(int Id)
        {
            var response = new Response<ProductModel>();

            var data = await _productRepository.GetByIdAsync(Id);
            response.Data = data;
            return response;
        }
    }
}
