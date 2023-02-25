using AutoMapper;
using Ecommerce.API.Application.DataContract.Response.Product;
using Ecommerce.API.Application.Interfaces;
using Ecommerce.API.Domain.Interfaces.Services;
using Ecommerce.API.Domain.Models;
using Ecommerce.API.Domain.Validations.Base;

namespace Ecommerce.API.Application.Applications
{
    public class CategoryApplication : ICategoryApplication
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryApplication(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<Response<List<string>>> GetAllAsync()
        {
            Response<List<string>> product = await _categoryService.GetAllAsync();

            if (product.Report.Any())
                return Response.Unprocessable<List<string>>(product.Report);

            var response = _mapper.Map<List<string>>(product.Data);

            return Response.OK(response);
        }
    }
}
