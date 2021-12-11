using MyProductsService.Controllers;
using ProductsCore.Models;
using System.Threading.Tasks;

namespace ProductsDataLayer.Repository.UserRepository
{
    public interface IUserRepository
    {
        Task<Role?> GetRoleByLoginInfoAsync(LoginInfo loginInfo);
        Task UpdatePasswordAsync(LoginInfo loginInfo);
        Task<bool> VerifyLoginAsync(LoginInfo loginInfo);
    }
}
