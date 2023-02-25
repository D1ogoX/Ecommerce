namespace Ecommerce.API.Application.DataContract.Response.Product
{
    public sealed class ProductResponse
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public string category { get; set; }
        public string image { get; set; }
        public RatingResponse rating { get; set; }
    }
}
