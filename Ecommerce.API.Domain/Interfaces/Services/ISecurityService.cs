using Ecommerce.API.Domain.Models;
using Ecommerce.API.Domain.Validations.Base;

namespace Ecommerce.API.Domain.Interfaces.Services
{
    public interface ISecurityService
    {
        Task<Response<bool>> ComparePassword(string password, string confirmPassword);
        Task<Response<bool>> VerifyPassword(string password, UserModel user);
    }
}
