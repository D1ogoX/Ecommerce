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

        /// <summary>
        /// Get a single cart by is ID
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{cartId}")]
        public async Task<IActionResult> Get(int cartId)
        {
            var response = await _cartApplication.GetCartByIdAsync(cartId);

            if (response.Report.Any())
                return UnprocessableEntity(response);

            return Ok(response);
        }

        /// <summary>
        /// Get all user carts
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("user/{userId}")]
        public async Task<IActionResult> GetByUser(int userId)
        {
            var response = await _cartApplication.GetUserCartAsync(userId);

            if (response.Report.Any())
                return UnprocessableEntity(response);

            return Ok(response);
        }

        /// <summary>
        /// Add cart
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] CartRequest cart)
        {
            var response = await _cartApplication.AddCartAsync(cart);

            if (response.Report.Any())
                return UnprocessableEntity(response);

            return Ok(response);
        }

        /// <summary>
        /// Update a cart
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] UpdateCartRequest cart)
        {
            var response = await _cartApplication.UpdateCartAsync(cart);

            if (response.Report.Any())
                return UnprocessableEntity(response);

            return Ok();
        }
    }
}
