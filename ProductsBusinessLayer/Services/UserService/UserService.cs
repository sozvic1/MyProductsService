using MyProductsService.Controllers;
using ProductsBusinessLayer.Services.HashService;
using ProductsCore.Models;
using ProductsDataLayer.Repository.UserRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductsBusinessLayer.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHashService _hashService;
        public UserService(IUserRepository userRepository, IHashService hashService)
        {
            _userRepository = userRepository;
            _hashService = hashService;
        }
        public async Task<Role?> GetRoleByLoginInfoAsync(LoginInfo loginInfo)
        {
            loginInfo.Password = _hashService.HashString(loginInfo.Password);

           return await _userRepository.GetRoleByLoginInfoAsync(loginInfo);
        }

        public async Task UpdatePasswordAsync(LoginInfo loginInfo)
        {
            loginInfo.Password = _hashService.HashString(loginInfo.Password);

            await _userRepository.UpdatePasswordAsync(loginInfo);
        }

        public async Task<bool> VerifyPsswordsync(LoginInfo loginInfo)
        {
            loginInfo.Password = _hashService.HashString(loginInfo.Password);

            return await _userRepository.VerifyLoginAsync(loginInfo);
        }
    }
}
