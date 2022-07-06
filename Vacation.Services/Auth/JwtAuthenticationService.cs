using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Vacation.Data;

namespace Vacation.Services.Auth
{
    public class JwtAuthenticationService : IJwtAuthenticationService
    {

        private readonly VacationDbContext _vacationDbContext;


        public JwtAuthenticationService( VacationDbContext vacationDbContext)
        {
            _vacationDbContext = vacationDbContext;
        }

        public string Authenticate(string username, string password)
        {
            if (!_vacationDbContext.Users.Any(x => x.FirstName == username && x.Password == password))
            {
                return null;
            }

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var key = Environment.GetEnvironmentVariable("JWT_SECRET");
            var tokenKey = Encoding.ASCII.GetBytes(key);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),

                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature
                    )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);



            return tokenHandler.WriteToken(token);
        }
    }
}
