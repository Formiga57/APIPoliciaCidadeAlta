using System.Text;
using API.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
namespace API.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(User user)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] jwtKey = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(jwtKey), SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(new[]{
                    new Claim(ClaimTypes.Name,user.UserName)
                })
            };
            SecurityToken tokenObject = tokenHandler.CreateToken(tokenDescriptor);
            String token = tokenHandler.WriteToken(tokenObject);
            return token;
        }
    }
}