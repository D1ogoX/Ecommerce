namespace Ecommerce.API.Application.DataContract.Request.Product
{
    /// <summary>
    /// Not implemented
    /// </summary>
    public sealed class ProductRequest
    {
        public string title { get; set; }
        public string description { get; set; }
        public string brand { get; set; }
        public double price { get; set; }
        public string category { get; set; }
        public string image { get; set; }

        public RatingRequest rating { get; set; }
    }
}
