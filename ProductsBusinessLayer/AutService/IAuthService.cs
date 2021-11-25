using MyProductsService.Controllers;

namespace ProductsBusinessLayer.AutService
{
    public interface IAuthService
    {
        string Login(LoginInfo loginInfo);
    }
}