using MyProductsService.Controllers;
using System.Threading.Tasks;

namespace ProductsBusinessLayer.AutService
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginInfo loginInfo);
    }
}