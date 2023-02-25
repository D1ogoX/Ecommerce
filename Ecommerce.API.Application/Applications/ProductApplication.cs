using AutoMapper;
using Ecommerce.API.Application.DataContract.Response.Product;
using Ecommerce.API.Application.Interfaces;
using Ecommerce.API.Domain.Interfaces.Services;
using Ecommerce.API.Domain.Models;
using Ecommerce.API.Domain.Validations.Base;

namespace Ecommerce.API.Application.Applications
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductApplication(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<Response<List<ProductResponse>>> GetAllAsync()
        {
            Response<List<ProductModel>> product = await _productService.GetAllAsync();

            if (product.Report.Any())
                return Response.Unprocessable<List<ProductResponse>>(product.Report);

            var response = _mapper.Map<List<ProductResponse>>(product.Data);

            return Response.OK(response);
        }

        public async Task<Response<List<ProductResponse>>> GetAllByCategoryAsync(string category)
        {
            Response<List<ProductModel>> product = await _productService.GetAllByCategoryAsync(category);

            if (product.Report.Any())
                return Response.Unprocessable<List<ProductResponse>>(product.Report);

            var response = _mapper.Map<List<ProductResponse>>(product.Data);

            return Response.OK(response);
        }

        public async Task<Response<ProductResponse>> GetByIdAsync(int Id)
        {
            Response<ProductModel> product = await _productService.GetByIdAsync(Id);

            if (product.Report.Any())
                return Response.Unprocessable<ProductResponse>(product.Report);

            var response = _mapper.Map<ProductResponse>(product.Data);

            return Response.OK(response);
        }
    }
}
