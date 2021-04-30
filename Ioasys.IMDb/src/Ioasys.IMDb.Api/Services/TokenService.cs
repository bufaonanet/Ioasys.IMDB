﻿
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Ioasys.IMDb.Domain.Models;

namespace Ioasys.IMDb.Api.Services
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GerarToken(Pessoa pessoa)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("secrect").ToString());
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, pessoa.Login.ToString()),
                    new Claim(ClaimTypes.Role, pessoa.NivelAcesso.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

            //var tokenHandler = new JwtSecurityTokenHandler();          

            //var key = Encoding.ASCII.GetBytes(_configuration.GetSection("secrect").ToString());
            //var tokenDescription = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(new Claim[]
            //    {
            //        new Claim(ClaimTypes.Name, pessoa.Login),
            //        new Claim(ClaimTypes.Role, pessoa.NivelAcesso.ToString())
            //    }),
            //    Expires = DateTime.UtcNow.AddHours(2),
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            //};

            //var token = tokenHandler.CreateToken(tokenDescription);
            //return tokenHandler.WriteToken(token);
        }
    }
}
