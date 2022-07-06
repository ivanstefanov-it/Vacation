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
        public ActionResult<BaseCommandResponse> AuthUser([FromBody]UserDto user)
        {
            var response = jwtAutheticationService.Authenticate(user.FirstName, user.Password);
            if (response.Success == false)
            {
                return Unauthorized();
            }

            return Ok(response);
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