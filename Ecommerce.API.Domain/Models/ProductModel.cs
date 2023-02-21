namespace Ecommerce.API.Domain.Models
{
    public class ProductModel : EntityBase
    {
        public string description { get; set; }
        public string brand { get; set; }
        public double price{ get; set; }
        public string category { get; set; }
    }
}
