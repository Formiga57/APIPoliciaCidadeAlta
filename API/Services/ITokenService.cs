using API.Models;
namespace API.Services
{
    public interface ITokenService
    {
        public string GenerateToken(User user);
        public int? GetUserIdByToken(string token);

    }
}