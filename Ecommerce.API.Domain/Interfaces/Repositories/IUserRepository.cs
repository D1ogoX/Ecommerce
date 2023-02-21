using Ecommerce.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.API.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task InsertAsync(UserModel user);
        Task<UserModel> GetByIdAsync(int Id);
        Task<List<UserModel>> GetAllAsync();
    }
}
