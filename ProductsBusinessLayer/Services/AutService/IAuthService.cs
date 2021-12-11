using MyProductsService.Controllers;
using ProductsCore.Models;
using System.Threading.Tasks;

namespace ProductsBusinessLayer.AutService
{
    public interface IAuthService
    {
        string CreteAuthToken(UserInfo userInfo);

        UserInfo GetUserInfoFromToken(string hederToken);
    }
} 