namespace Ecommerce.API.Application.DataContract.Request.Cart
{
    public class UpdateCartRequest
    {
        public int id { get; set; }
        public int userId { get; set; }
        public DateTime date { get; set; }
        public List<CartProductRequest> products { get; set; }
    }
}
