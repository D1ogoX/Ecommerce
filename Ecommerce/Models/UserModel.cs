namespace Ecommerce.Models
{
    public class UserModel : BaseModel
    {
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public NameModel name { get; set; }
        public AddressModel address { get; set; }
    }
    public class NameModel
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
    }

    public class AddressModel
    {
        public string city { get; set; }
        public string street { get; set; }
        public int number { get; set; }
        public string zipcode { get; set; }
        public GeolocationModel geolocation { get; set; }
    }

    public class GeolocationModel
    {
        public string lat { get; set; }
        public string longitude { get; set; }
    }
}
