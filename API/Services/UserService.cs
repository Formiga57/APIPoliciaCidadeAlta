using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using API.Models;
using API.Repo;

namespace API.Services
{
    public class UserService : IUserService
    {
        private readonly CodigosPenaisContext _CodigosPenaisContext;
        private readonly ITokenService _TokenService;
        private readonly IConfiguration _Configuration;
        public UserService(CodigosPenaisContext dbContext, ITokenService tokenService, IConfiguration configuration)
        {
            _CodigosPenaisContext = dbContext;
            _TokenService = tokenService;
            _Configuration = configuration;
        }

        public string? RegisterUser(User user)
        {
            // Checks if username is already being used
            if (_CodigosPenaisContext.Users.SingleOrDefault(x => x.UserName.Equals(user.UserName)) != null)
            {
                return null;
            }
            // Hash password
            string hashedPassword = PasswordHasher(user.Password);
            // Add User to Database
            User newUser = new() { UserName = user.UserName, Password = hashedPassword };
            _CodigosPenaisContext.Users.Add(newUser);
            _CodigosPenaisContext.SaveChanges();
            // Generate JWT key for this User
            String token = _TokenService.GenerateToken(newUser);
            return token;
        }
        public string? VerifyUserLogin(User userReceived)
        {
            User? user = _CodigosPenaisContext.Users.SingleOrDefault(x => x.UserName.Equals(userReceived.UserName));
            // Checks if username doesn't exists
            if (user == null)
            {
                return null;
            }
            // Checking if passwords matches
            string hashedReceivedPassword = PasswordHasher(userReceived.Password);
            if (!hashedReceivedPassword.Equals(user.Password))
            {
                return null;
            }
            // Return jwt if password is correct
            string token = _TokenService.GenerateToken(user);
            return token;
        }
        private string PasswordHasher(string password)
        {
            // Generating Salt for Password Hash
            byte[] salt = Encoding.ASCII.GetBytes(_Configuration["Auth:Salt"]);
            // Generating Hashed Password
            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));
            return hashedPassword;
        }
    }
}