namespace Ecommerce.API.Application.DataContract.Response.User
{
    public sealed class AuthResponse
    {
        public string Token { get; set; }
        public int ExpireIn { get; set; }
        public string Type { get; set; }
    }
}
