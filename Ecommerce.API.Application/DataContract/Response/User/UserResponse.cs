using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.API.Application.DataContract.Response.User
{
    public class UserResponse
    {
        public int id { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public NameModelResponse name { get; set; }
        public AddressModelResponse address { get; set; }
    }

    public class NameModelResponse
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
    }

    public class AddressModelResponse
    {
        public string city { get; set; }
        public string street { get; set; }
        public int number { get; set; }
        public string zipcode { get; set; }
        public GeolocationModelResponse geolocation { get; set; }
    }

    public class GeolocationModelResponse
    {
        public string lat { get; set; }
        public string longitude { get; set; }
    }
}
