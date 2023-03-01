namespace Ecommerce.Models
{
    public class CartModel : BaseModel
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

    public class CartRequestModel
    {
        public int userId { get; set; }
        public DateTime date { get; set; }

        public List<CartProductRequestModel> products { get; set; }
    }

    public class CartProductRequestModel
    {
        public int productId { get; set; }
        public int quantity { get; set; }
    }

    public class CartUpdateRequestModel
    {
        public int id { get; set; }
        public int userId { get; set; }
        public DateTime date { get; set; }

        public List<CartProductRequestModel> products { get; set; }
    }
}
