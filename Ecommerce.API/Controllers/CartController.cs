using Ecommerce.API.Application.DataContract.Request.Cart;
using Ecommerce.API.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/Cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartApplication _cartApplication;

        public CartController(ICartApplication cartApplication)
        {
            _cartApplication = cartApplication;
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> Get(int userId)
        {
            var response = await _cartApplication.GetUserCartAsync(userId);

            if (response.Report.Any())
                return UnprocessableEntity(response);

            return Ok(response);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] CartRequest cart)
        {
            var response = await _cartApplication.AddCartAsync(cart);

            if (response.Report.Any())
                return UnprocessableEntity(response);

            return Ok(response);
        }
    }
}
