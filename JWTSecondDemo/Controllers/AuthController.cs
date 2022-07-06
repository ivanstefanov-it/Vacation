using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Vacation.Data.Models;
using Vacation.Services.Auth;
using JWTSecondDemo.Models;

namespace JWTSecondDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtAuthenticationService jwtAutheticationService;

        public AuthController(IJwtAuthenticationService jwtAutheticationManager)
        {
            this.jwtAutheticationService = jwtAutheticationManager;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult AuthUser([FromBody]UserDto user)
        {
            var token = jwtAutheticationService.Authenticate(user.FirstName, user.Password);
            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    } 
}