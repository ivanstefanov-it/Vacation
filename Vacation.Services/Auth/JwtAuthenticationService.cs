using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
using Vacation.Data.Models;

namespace Vacation.Services.Auth
{
    public class JwtAuthenticationService : IJwtAuthenticationService
    {

        private readonly VacationDbContext _vacationDbContext;


        public JwtAuthenticationService( VacationDbContext vacationDbContext)
        {
            _vacationDbContext = vacationDbContext;
        }

        public BaseCommandResponse Authenticate(string username, string password)
        {
            if (!_vacationDbContext.Users.Any(x => x.FirstName == username && x.Password == password))
            {
                return null;
            }

            var user = _vacationDbContext.Users.Where(x => x.FirstName.Equals(username)).FirstOrDefault();

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

            var response = new BaseCommandResponse();
            response.Success = true;
            response.Token = tokenHandler.WriteToken(token);
            response.Id = user.Id;

            return response;
        }

        public User GetUserById(int id)
        {
            var user = _vacationDbContext.Users.Find(id);
            //var user = _vacationDbContext.Users.Where(x => x.Id == id).FirstOrDefault();

            return user;
        }

        public async Task<bool> Register(string firstName, string password)
        {
            if (firstName == null || password == null)
            {
                return false;
            }

            var user = new User()
            {
                //Id = 123,
                FirstName = firstName,
                LastName = "Admin",
                Password = password,
                MiddleName = "admin",
                BirthPlace = "Sofia",
                WorkExperienceInDays = 10,
                StartDate = DateTime.Now,
                VacationHours = 10
            };
            await _vacationDbContext.Users.AddAsync(user);
            _vacationDbContext.SaveChanges();


            return true;
        }

        public async Task<IReadOnlyList<User>> GetAllUsersAsync()
        {
            var users = await _vacationDbContext.Users.ToListAsync();

            return users;
        }
    }
}
