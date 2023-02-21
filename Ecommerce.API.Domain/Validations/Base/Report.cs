using System.Reflection.Metadata.Ecma335;

namespace Ecommerce.API.Domain.Validations.Base
{
    public class Report
    {
        public Report()
        { }

        public Report(string message)
        {
            this.message = message;
        }

        public string code { get; set; }
        public string message { get; set; }

        public static Report Create(string message) => new Report(message);
    }
}
