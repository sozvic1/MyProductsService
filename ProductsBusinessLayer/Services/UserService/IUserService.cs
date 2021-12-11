using MyProductsService.Controllers;
using ProductsCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductsBusinessLayer.Services.UserService
{
    public interface IUserService
    {
        Task UpdatePasswordAsync(LoginInfo loginInfo);
        Task<bool> VerifyPsswordsync(LoginInfo loginInfo);
        Task<Role?> GetRoleByLoginInfoAsync(LoginInfo loginInfo);
    }
}
