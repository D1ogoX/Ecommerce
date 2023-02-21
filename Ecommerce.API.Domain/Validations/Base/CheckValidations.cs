namespace Ecommerce.API.Domain.Validations.Base
{
    public static class CheckValidations
    {
        public static Response CheckErrors(this FluentValidation.Results.ValidationResult result)
        {
            var response = new Response();

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    response.Report.Add(new Report()
                    {
                        code = error.PropertyName,
                        message = error.ErrorMessage
                    });
                }

                return response;
            }

            return response;
        }
    }
}
