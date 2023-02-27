namespace Ecommerce.API.Application.DataContract.Request.User
{
    public class UserRequest
    {
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public NameModelRequest name { get; set; }
        public AddressModelRequest address { get; set; }
    }

    public class NameModelRequest
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
    }

    public class AddressModelRequest
    {
        public string city { get; set; }
        public string street { get; set; }
        public int number { get; set; }
        public string zipcode { get; set; }
        public GeolocationModelRequest geolocation { get; set; }
    }

    public class GeolocationModelRequest
    {
        public string lat { get; set; }
        public string longitude { get; set; }
    }
}
