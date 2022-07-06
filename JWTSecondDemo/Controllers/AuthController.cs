using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Vacation.Data.Models;

namespace JWTSecondDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtAutheticationManager jwtAutheticationManager;

        public AuthController(JwtAutheticationManager jwtAutheticationManager)
        {
            this.jwtAutheticationManager = jwtAutheticationManager;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult AuthUser([FromBody]User user)
        {
            var token = jwtAutheticationManager.Authtenticate(user.FirstName, user.Password);
            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    } 
}