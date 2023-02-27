using AutoMapper;
using Ecommerce.API.Application.DataContract.Request.User;
using Ecommerce.API.Application.DataContract.Response.User;
using Ecommerce.API.Application.Interfaces;
using Ecommerce.API.Domain.Interfaces.Services;
using Ecommerce.API.Domain.Models;
using Ecommerce.API.Domain.Validations.Base;

namespace Ecommerce.API.Application.Applications
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserApplication(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<Response<AuthResponse>> AuthenticationAsync(AuthRequest auth)
        {
            var isAuthenticated = await _userService.AuthenticationAsync(auth.Password, auth.Username);

            if (string.IsNullOrEmpty(isAuthenticated.Data))
                return Response.Unprocessable<AuthResponse>(new List<Report>() { Report.Create("Username or Password do not match") });

            var response = new Response<AuthResponse>();

            response.Data = new AuthResponse()
            {
                Token = isAuthenticated.Data
            };

            return response;
        }

        public async Task<Response<List<UserResponse>>> GetAllAsync()
        {
            Response<List<UserModel>> user = await _userService.GetAllAsync();

            if (user.Report.Any())
                return Response.Unprocessable<List<UserResponse>>(user.Report);

            var response = _mapper.Map<List<UserResponse>>(user.Data);

            return Response.OK(response);
        }

        public Task<Response<UserResponse>> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<UserResponse>> GetByUsernameAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<Response> InsertAsync(UserModel user)
        {
            throw new NotImplementedException();
        }
    }
}
