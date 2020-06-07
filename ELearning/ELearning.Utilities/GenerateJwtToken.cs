using ELearning.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ELearning.Utilities
{
    public class GenerateJwtToken : IJwtGenerate
    {
        private readonly JwtSettings jwtSetting;
        public GenerateJwtToken(JwtSettings JwtSetting)
        {
            jwtSetting = JwtSetting;
        }
        public string JwtToken(ApplicationUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtSetting.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims: new[]
               {
                   new Claim(type: JwtRegisteredClaimNames.Sub, value: user.UserName),
                   new Claim(type: JwtRegisteredClaimNames.Jti, value: Guid.NewGuid().ToString()),
                   new Claim(type: JwtRegisteredClaimNames.Email, value: user.Email),
                   new Claim(type: "Id", value: user.Id)
               }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), algorithm: SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
