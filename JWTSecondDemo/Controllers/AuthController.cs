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

        [AllowAnonymous]
        [HttpPut]
        public async Task<IActionResult> RegisterUser([FromBody] UserDto user)
        {
            var result = await jwtAutheticationService.Register(user.FirstName, user.Password);
            if (result == false)
            {
                return BadRequest();
            }

            return Ok();
        }
    } 
}