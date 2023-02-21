using Ecommerce.API.Domain.Interfaces.Repositories;
using Ecommerce.API.Domain.Interfaces.Services;
using Ecommerce.API.Domain.Models;
using Ecommerce.API.Domain.Validations;
using Ecommerce.API.Domain.Validations.Base;

namespace Ecommerce.API.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Response<List<UserModel>>> GetAllAsync()
        {
            var response = new Response<List<UserModel>>();

            response.Data = await _userRepository.GetAllAsync();

            return response;
        }

        public async Task<Response<UserModel>> GetByIdAsync(int Id)
        {
            var response = new Response<UserModel>();

            response.Data = await _userRepository.GetByIdAsync(Id);

            return response;
        }

        public async Task<Response> InsertAsync(UserModel user)
        {
            var response = new Response();

            var validation = new UserValidation();

            response = validation.Validate(user).CheckErrors();

            if (response.Report.Count > 0)
                return response;

            await _userRepository.InsertAsync(user);

            return response;
        }
    }
}
