namespace Ecommerce.API.Domain.Models
{
    public class CartModel : EntityBase
    {
        public int userId { get; set; }
        public DateTime date { get; set; }
        public List<CartProductModel> products { get; set; }
    }

    public class CartProductModel
    {
        public int productId { get; set; }
        public int quantity { get; set; }
        public ProductModel product { get; set; }
    }
}
