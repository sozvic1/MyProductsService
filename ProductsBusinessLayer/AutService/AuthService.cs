using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyProductsService.Controllers;
using ProductsCore.Options;
using ProductsDataLayer;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProductsBusinessLayer.AutService
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly AuthOptions _authOptions;
        public AuthService(
            IOptions<AuthOptions> authOptions,
            IUserRepository userRepository)
        {
            _authOptions = authOptions.Value;
            _userRepository = userRepository;
        }
        public async Task<string> LoginAsync(LoginInfo loginInfo)
        {
           var role = await _userRepository.GetRoleByLoginInfoAsync(loginInfo);
            if (role == null)
            {
                return string.Empty;
            }

            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, loginInfo.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, role.ToString())
                }; 

            var token = new JwtSecurityToken(
                    issuer: _authOptions.Issuer,
                    audience: _authOptions.Audience,
                    notBefore: DateTime.UtcNow,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(_authOptions.TokenLifeTime)),
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey
                    (Encoding.ASCII.GetBytes(_authOptions.SecretKey)),
                    SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
     
    }
}
