namespace Ecommerce.API.Application.DataContract.Response.Product
{
    public sealed class ProductResponse
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string brand { get; set; }
        public double price { get; set; }
        public string category { get; set; }
    }
}
