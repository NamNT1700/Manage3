using Manage.Model.DTO.User;
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
        public string GenerateAccessToken(SeUser user)
        {
            var userClaim = new List<Claim>
            {
                new Claim("username",user.Username),
                new Claim("id",Convert.ToString(user.Id)),
                new Claim("Role",user.Role)
            };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity();
            claimsIdentity.AddClaims(userClaim);
            var jwtTokenHandle = new JwtSecurityTokenHandler();
            var secretkeyBytes = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretkeyBytes), SecurityAlgorithms.HmacSha256Signature)
            };
            var accessToken = jwtTokenHandle.CreateToken(tokenDescription);           
            return jwtTokenHandle.WriteToken(accessToken);
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
        public TokenDecode TokenInfo(string token)
        {
            TokenDecode tokenDecode = new TokenDecode();
            ClaimsPrincipal claimsPrincipal = DecodeAccessToken(token);
            tokenDecode.role = claimsPrincipal.Claims.FirstOrDefault(u => u.Type.Equals("Role")).Value;
            tokenDecode.username = claimsPrincipal.Claims.FirstOrDefault(u => u.Type.Equals("username")).Value;
            tokenDecode.exp = long.Parse(claimsPrincipal.Claims.FirstOrDefault(u => u.Type.Equals("exp")).Value);
            return tokenDecode;
        }
        public Response CheckToken(TokenDecode token)
        {
            Response response = new Response();
            DateTime expTimeConverted = ConvertToDateTime(token.exp);
            if (expTimeConverted < DateTime.UtcNow)
            {
                response.status = "406";
                response.success = false;
                response.message = "token is expiration";
                return response;
            }
            if (token.role != "Admin")
            {
                response.status = "403";
                response.success = false;
                response.message = "forbidden";
                return response;
            }
            return null;
        }
        private DateTime ConvertToDateTime(long expDate)
        {
            DateTime dateTimeInterval = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTimeInterval = dateTimeInterval.AddSeconds(expDate).ToUniversalTime();
            return dateTimeInterval;
        }
        public SeToken GenerateTokens (SeUser seUser)
        {
            SeToken tokens = new SeToken();
            tokens.access_token = GenerateAccessToken(seUser);
            tokens.refresh_token = GenerateRefreshToken();
            return tokens;
        }
    }
}
 