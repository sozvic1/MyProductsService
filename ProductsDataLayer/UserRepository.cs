using Microsoft.EntityFrameworkCore;
using MyProductsService.Controllers;
using ProductsCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsDataLayer
{
    public class UserRepository : IUserRepository
    {
        private readonly EFCoreContext _dbContext;
        public UserRepository(EFCoreContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Role?> GetRoleByLoginInfoAsync(LoginInfo loginInfo)
        {
           var account =await _dbContext.Users.Where(x =>
           x.LoginInfo.Login == loginInfo.Login &
            x.LoginInfo.Password == loginInfo.Password).FirstOrDefaultAsync();

            return account?.Role;
        }
    }
}
