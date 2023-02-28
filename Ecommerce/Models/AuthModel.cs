namespace Ecommerce.Models
{
    public class AuthModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class AuthResponseModel
    {
        public string token { get; set; }
        public int userId { get; set; }
    }
}
