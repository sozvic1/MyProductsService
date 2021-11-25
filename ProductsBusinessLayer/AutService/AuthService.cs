﻿using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyProductsService.Controllers;
using ProductsCore.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductsBusinessLayer.AutService
{
    public class AuthService : IAuthService
    {
        private readonly AuthOptions _authOptions;
        public AuthService(IOptions<AuthOptions> authOptions)
        {
            _authOptions = authOptions.Value;
        }
        public string Login(LoginInfo loginInfo)
        {
            var identity = ValidateLoginInfo(loginInfo.Login, loginInfo.Password);
            if (identity == null)
            {
                return string.Empty;
            }

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: _authOptions.Issuer,
                    audience: _authOptions.Audience,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(_authOptions.TokenLifeTime)),
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey
                    (Encoding.ASCII.GetBytes(_authOptions.SecretKey)),
                    SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(jwt);

        }
        private ClaimsIdentity ValidateLoginInfo(string username, string password)
        {
            (string Login, string Role) person = ("Admin", "Admin");
            //Person person = people.FirstOrDefault(x => x.Login == username && x.Password == password);
            // if (person != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }
        }
    }
}
