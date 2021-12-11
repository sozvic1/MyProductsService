using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyProductsService.Controllers;
using ProductsCore.Models;
using ProductsCore.Options;
using ProductsDataLayer;
using ProductsDataLayer.Repository.UserRepository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProductsBusinessLayer.AutService
{
    public class AuthService : IAuthService
    {
        private readonly SigningCredentials _signingCredentials;
        private readonly AuthOptions _authOptions;
        public AuthService(
            IOptions<AuthOptions> authOptions)
        {
            _authOptions = authOptions.Value;
            _signingCredentials = new SigningCredentials(new SymmetricSecurityKey
                    (Encoding.ASCII.GetBytes(_authOptions.SecretKey)),
                    SecurityAlgorithms.HmacSha256);


        }
        public string CreteAuthToken(UserInfo userInfo)
        {  
            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, userInfo.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, userInfo.Role.ToString())
                };

            var token = new JwtSecurityToken(
                    issuer: _authOptions.Issuer,
                    audience: _authOptions.Audience,
                    notBefore: DateTime.UtcNow,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(_authOptions.TokenLifeTime)),
                    signingCredentials: _signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        public UserInfo GetUserInfoFromToken(string hederToken)
        {
            var token = hederToken.Substring(hederToken.IndexOf(' ') + 1);
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = jsonToken as JwtSecurityToken;
          return  new UserInfo
            {

                Login = tokenS.Claims.FirstOrDefault(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value,
                Role = (Role)Enum.Parse(typeof(Role),tokenS.Claims.FirstOrDefault(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value)
            };
           
        }
    }
}
