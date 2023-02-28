using Ecommerce.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ecommerce.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IUserRepository _userRepository;

        public enum Status
        {
            Error,
            Success,
            Nothing
        }

        public Status LoginStatus = Status.Nothing; 

        public LoginModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            string username = Request.Form["username"];
            string password = Request.Form["password"];

#if (DEBUG)
            username = "mor_2314";
            password = "83r5^_";
#endif

            try
            {
                var user = _userRepository.AuthenticationAsync(username, password).Result;

                if (!string.IsNullOrEmpty(user.token))
                {
                    HttpContext.Session.SetString("Ecommerce_token", user.token);
                    HttpContext.Session.SetString("Ecommerce_username", username);
                    HttpContext.Session.SetInt32("Ecommerce_userId", user.userId);

                    Response.Redirect("/Cart");
                }

                else
                    LoginStatus = Status.Error;
            }

            catch
            {
                LoginStatus = Status.Error;
            }
        }
    }
}
