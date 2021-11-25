using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsBusinessLayer.AutService;
using ProductsCore.Models;
using ProductsCore.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyProductsService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("manager")]
        public async Task<IActionResult> CreateManager(AccountInfo account)
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpPut("mrk_obsolete")]
        public async Task<IActionResult> MarkAccountPasswordObsolete(List<Guid> accountsIds)
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpPut("password")]
        public async Task<IActionResult> UpdatePassword(string oldPassword, string oldPssword)
        {
            await Task.CompletedTask;
            return Ok();
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
            
            return Ok(_authService.Login(loginInfo));

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(AccountInfo accountInfo)
        {
            await Task.CompletedTask;
            return Ok();
        }
    }
}
