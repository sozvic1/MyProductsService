using Microsoft.EntityFrameworkCore;
using MyProductsService.Controllers;
using ProductsCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsDataLayer.Repository.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly EFCoreContext _dbContext;
        public UserRepository(EFCoreContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid>AddUserAsync(AccountInfo accountInfo)
        {
            accountInfo.Id = Guid.NewGuid();
            _dbContext.Users.Add(accountInfo);
            var result =    await _dbContext.SaveChangesAsync();

            return result!=0 ?accountInfo.Id:Guid.Empty;
        }
        public async Task<Role?> GetRoleByLoginInfoAsync(LoginInfo loginInfo)
        {
            var account = await GetAccountInfoByLoginInfoAsync(loginInfo);

            return account?.Role;
        }
        public async Task UpdatePasswordAsync(LoginInfo loginInfo)
        {
            var user = await GetAccountInfoByLoginInfoAsync(loginInfo);
            user.LoginInfo.Password = loginInfo.Password;
            await _dbContext.SaveChangesAsync();
        }
        public async Task<bool>VerifyLoginAsync(LoginInfo loginInfo)
        {
          var account =  await GetAccountInfoByLoginInfoAsync(loginInfo);
            return account != null;
        }

        private async Task<AccountInfo> GetAccountInfoByLoginInfoAsync(LoginInfo loginInfo)
        {
         return await _dbContext.Users.FirstOrDefaultAsync(x =>
           x.LoginInfo.Login == loginInfo.Login &
            x.LoginInfo.Password == loginInfo.Password);
        }
    }
}
