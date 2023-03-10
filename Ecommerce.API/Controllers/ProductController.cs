using Ecommerce.API.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductApplication _productApplication;
        private readonly ICategoryApplication _categoryApplication;

        public ProductController(IProductApplication productApplication, ICategoryApplication categoryApplication)
        {
            _productApplication = productApplication;
            _categoryApplication = categoryApplication;
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> Get()
        {
            var response = await _productApplication.GetAllAsync();

            if (response.Report.Any())
                return UnprocessableEntity(response);

            return Ok(response);
        }

        /// <summary>
        /// Get a product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _productApplication.GetByIdAsync(id);

            if (response.Report.Any())
                return UnprocessableEntity(response);

            return Ok(response);
        }

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("categories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var response = await _categoryApplication.GetAllAsync();

            if (response.Report.Any())
                return UnprocessableEntity(response);

            return Ok(response);
        }

        /// <summary>
        /// Get all products by category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("categories/{category}")]
        public async Task<IActionResult> GetAllProductsInCategory(string category)
        {
            var response = await _productApplication.GetAllByCategoryAsync(category);

            if (response.Report.Any())
                return UnprocessableEntity(response);

            return Ok(response);
        }
    }
}
