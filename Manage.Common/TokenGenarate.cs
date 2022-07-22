using Manage.Model.DTO.Authentication;
using Manage.Model.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Common
{
    public class TokenGenarate
    {
        public IConfiguration _configuration { get; }
        public TokenGenarate(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public SeToken GenerateToken(SeUser user)
        {
            var userClaim = new List<Claim>
            {
                new Claim("Username",user.Username),
                new Claim("ID",Convert.ToString(user.Id)),
                new Claim("Role",user.Role)
            };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity();
            claimsIdentity.AddClaims(userClaim);
            var jwtTokenHandle = new JwtSecurityTokenHandler();
            var secretkeyBytes = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretkeyBytes), SecurityAlgorithms.HmacSha256Signature)
            };
            SeToken tokens = new SeToken();
            var accessToken = jwtTokenHandle.CreateToken(tokenDescription);
            tokens.access_token = jwtTokenHandle.WriteToken(accessToken);
            tokens.refresh_token = GenerateRefreshToken();
            return tokens;
        }
        public string GenerateRefreshToken()
        {
            var random = new byte[64];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(random);
                return Convert.ToBase64String(random);
            }
        }
        public ClaimsPrincipal DecodeAccessToken(string Input)
        {
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            var handler = new JwtSecurityTokenHandler();
            var tokenSecure = handler.ReadToken(Input) as SecurityToken;
            var validations = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
            ClaimsPrincipal claims = handler.ValidateToken(Input, validations, out tokenSecure);
            return claims;
        }
    }
}
