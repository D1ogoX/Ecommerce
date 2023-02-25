namespace Ecommerce.API.Domain.Models
{
    public class ProductModel : EntityBase
    {
        public string title { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public string category { get; set; }
        public string image { get; set; }
        public RatingModel rating { get; set; }
    }
}
