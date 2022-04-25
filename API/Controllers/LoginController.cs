using Microsoft.AspNetCore.Mvc;
using API.Services;
using API.Models;

namespace API.Controllers
{
    [Route("v1/[Controller]")]
    public class LoginController : Controller
    {
        [HttpPost]
        public async Task<ActionResult<string>> LoginTask([FromBody] User user, [FromServices] IUserService userService)
        {
            if (user.UserName.Length <= 3 || user.Password.Length <= 3)
            {
                return BadRequest("Username and password length must be more than 3!");
            }
            if (user.UserName.Length >= 30 || user.Password.Length >= 30)
            {
                return BadRequest("Username and password length must be lower than 30!");
            }
            string? token = userService.VerifyUserLogin(user);
            if (token == null)
            {
                return BadRequest("Username or password doesn't matches!");
            }
            return token;
        }
    }
}