using MyProductsService.Controllers;
using ProductsCore.Models;
using System.Threading.Tasks;

namespace ProductsDataLayer
{
    public interface IUserRepository
    {
        Task<Role?> GetRoleByLoginInfoAsync(LoginInfo loginInfo);
    }
}
