using Ecommerce.API.Application.DataContract.Request.Product;

namespace Ecommerce.API.Application.DataContract.Request.Cart
{
    public class CartRequest
    {
        public int userId { get; set; }
        public DateTime date { get; set; }
        public List<CartProductRequest> products { get; set; }
    }

    public class CartProductRequest
    {
        public int productId { get; set; }
        public int quantity { get; set; }
    }
}
