using Ecommerce.API.Domain.Models;
using FluentValidation;

namespace Ecommerce.API.Domain.Validations
{
    public class UserValidation : AbstractValidator<UserModel>
    {
        /// <summary>
        /// Validate user fields
        /// </summary>
        public UserValidation()
        {
            RuleFor(x => x.email)
                .NotNull()
                .NotEmpty()
                .MinimumLength(5);

            RuleFor(x => x.name.lastname)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3);

            RuleFor(x => x.name.firstname)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3);
        }
    }
}
