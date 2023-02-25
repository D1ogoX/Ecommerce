namespace Ecommerce.Models
{
    public class ProductModel : BaseModel
    {
        public string title { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public string category { get; set; }
        public string image { get; set; }
    }
}
