using Ecommerce.API.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductApplication _productApplication;

        public ProductController(IProductApplication productApplication)
        {
            _productApplication = productApplication;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> Get()
        {
            var response = await _productApplication.GetAllAsync();

            if (response.Report.Any())
                return UnprocessableEntity(response);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _productApplication.GetByIdAsync(id);

            if (response.Report.Any())
                return UnprocessableEntity(response);

            return Ok(response);
        }
    }
}
