using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductsBusinessLayer.AutService;
using ProductsBusinessLayer.DTOs;
using ProductsBusinessLayer.Services.RegistrationService;
using ProductsBusinessLayer.Services.UserService;
using ProductsCore.Models;
using ProductsCore.Models.Requests;
using ProductsCore.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace MyProductsService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly ILogger<AccountController> _logger;
        private readonly IRegistrationService _registrationService;
        public AccountController(IAuthService authService,
            IUserService userService,
            ILogger<AccountController> logger,
            IRegistrationService registrationService)
        {
            _authService = authService;
            _userService = userService;
            _logger = logger;
            _registrationService = registrationService;
        }

        [HttpPost("manager")]
        public async Task<IActionResult> CreateManager(AccountInfo account)
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpPut("mark_obsolete")]
        public async Task<IActionResult> MarkAccountPasswordObsolete(List<Guid> accountsIds)
        {
            await Task.CompletedTask;
            return Ok();
        }

        [Authorize(Roles = nameof(Role.Admin))]
        [HttpPut("password")]
        public async Task<IActionResult> UpdatePassword([FromBody]PasswordChangeRequest request)
        {
            var authHeader = Request.Headers["Authorition"][0];
           var userInfo =  _authService.GetUserInfoFromToken(authHeader);
            var loginInfo = new LoginInfo { Login = userInfo.Login, Password = request.OldPassword };

          var passwordCorrect=  await _userService.VerifyPsswordsync(loginInfo);
            if(passwordCorrect)
            {
                loginInfo.Password = request.NewPassword;
                await  _userService.UpdatePasswordAsync(loginInfo);
            return Ok("Password updated");
            }
            return BadRequest("Invalid login or password");
        }

        [HttpPut("info")]
        public async Task<IActionResult> UpdateInfo(AccountInfo accountInfo)
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginInfo loginInfo)
        {
            var userRole  = await _userService.GetRoleByLoginInfoAsync(loginInfo);
            if(userRole!=null)
            {
              var tokken =  _authService.CreteAuthToken(new UserInfo
              {
                  Login = loginInfo.Login,
                  Role = userRole.Value
              });
                _logger.LogInformation($"User logged in:{loginInfo.Login}");
              return Ok(tokken);
            }
            _logger.LogInformation($"User loggin failed:{loginInfo.Login}");
            return BadRequest("Invlid usernme or password" );

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(AccountInfoDTO accountInfo)
        {
          return Ok(await _registrationService.RegisterUser(accountInfo));
        }
    }
}
