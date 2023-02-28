using Ecommerce.API.Application.Applications;
using Ecommerce.API.Application.DataContract.Request.User;
using Ecommerce.API.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserApplication _userApplication;

        public UserController(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> Get()
        {
            var response = await _userApplication.GetAllAsync();

            if (response.Report.Any())
                return UnprocessableEntity(response);

            return Ok(response);
        }

        [HttpPost("auth")]
        [AllowAnonymous]
        public async Task<ActionResult> Auth([FromBody] AuthRequest auth)
        {
            var response = await _userApplication.AuthenticationAsync(new AuthRequest() { Username = auth.Username, Password = auth.Password });

            if (response.Report.Any())
                return UnprocessableEntity(response.Report);

            return Ok(response);
        }
    }
}
