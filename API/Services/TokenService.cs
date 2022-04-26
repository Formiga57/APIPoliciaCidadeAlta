using System.Linq;
using API.Repo;
using System.Text;
using API.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
namespace API.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _Configuration;
        private readonly CodigosPenaisContext _CodigosPenaisContext;
        public TokenService(IConfiguration configuration, CodigosPenaisContext dbContext)
        {
            _Configuration = configuration;
            _CodigosPenaisContext = dbContext;
        }
        public int? GetUserIdByToken(string token)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] jwtKey = Encoding.ASCII.GetBytes(_Configuration["Jwt:Key"]);
            JwtSecurityToken tokenObject = tokenHandler.ReadJwtToken(token);
            string UserName = tokenObject.Claims.First(x => x.Type == "name").Value;
            User? user = _CodigosPenaisContext.Users.FirstOrDefault(x => x.UserName.Equals(UserName));
            if (user == null)
            {
                return null;
            }
            return user.Id;
        }
        public string GenerateToken(User user)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] jwtKey = Encoding.ASCII.GetBytes(_Configuration["Jwt:Key"]);
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