using Pusaka.Web.NetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pusaka.Web.NetCore.Interfaces
{
    public interface IUserService
    {
        Task<List<UserModel>> GetUserAsync(GetPostParamModel param);
        Task<UserModel> GetUserByIdAsync(int id);
        Task<UserModel> InsertUserAsync(UserModel payload);
        Task<UserModel> UpdateUserAsync(UserModel payload);
        Task<bool> DeleteUserAsync(int id);
    }
}
