using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using API.Models;
using API.Repo;

namespace API.Services
{
    public interface IUserService
    {
        public string? RegisterUser(User user);
        public string? VerifyUserLogin(User user);
    }
}