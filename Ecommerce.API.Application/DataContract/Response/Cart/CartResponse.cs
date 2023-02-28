using Ecommerce.API.Application.DataContract.Response.Product;

namespace Ecommerce.API.Application.DataContract.Response.Cart
{
    public class CartResponse
    {
        public int id { get; set; }
        public int userId { get; set; }
        public DateTime date { get; set; }

        public List<CartProductResponse> products { get; set; }
    }

    public class CartProductResponse
    {
        public int productId { get; set; }
        public int quantity { get; set; }
        public ProductResponse product { get; set; }
    }
}
