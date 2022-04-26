using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Services;

namespace API.Controllers
{
    [Route("v1/[Controller]")]
    public class SigninController : Controller
    {
        /// <summary>
        /// Add username and password into the database
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     {
        ///        "UserName": "Desired Username",
        ///        "Password": "Desired Password"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns the user's Bearer Token</response>
        /// <response code="400">Returns the error generated</response>
        [HttpPost]
        public ActionResult<dynamic> HandleSignIn([FromBody] User user, [FromServices] IUserService userService)
        {
            if (user.UserName.Length <= 3 || user.Password.Length <= 3)
            {
                return BadRequest("Username and password length must be more than 3!");
            }
            if (user.UserName.Length >= 30 || user.Password.Length >= 30)
            {
                return BadRequest("Username and password length must be lower than 30!");
            }
            string? token = userService.RegisterUser(user);
            if (token == null)
            {
                return BadRequest("Username already taken!");
            }
            return token;
        }
    }
}