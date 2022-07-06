using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacation.Data;
using Vacation.Services.Auth;
using Vacation.Services.Vacation.Models;

namespace Vacation.Services.Vacation
{
    public class VacationService : IVacationService
    {
        private readonly VacationDbContext _vacationDbContext;
        private readonly IJwtAuthenticationService _jwtAuthenticationService;

        public VacationService(VacationDbContext vacationDbContext, IJwtAuthenticationService jwtAuthenticationService)
        {
            _vacationDbContext = vacationDbContext;
            _jwtAuthenticationService = jwtAuthenticationService;
        }

        public void Create(VacationCreateModel vacation)
        {
            var user = _vacationDbContext.Users.FirstOrDefault(u => u.Id == vacation.UserId);

            if (user == null)
            {
                throw new Exception("Invalid user ID");
            }

            _vacationDbContext.Vacations.Add(new Data.Models.Vacation
            {
                UserId = vacation.UserId,
                User = user,
                Type = vacation.Type,
                From = vacation.From,
                To = vacation.To
            });

            _vacationDbContext.SaveChanges();
        }

        public IReadOnlyList<Data.Models.Vacation> GetAllVacations()
        {
            var vacations = _vacationDbContext.Vacations.ToList();
            foreach (var item in vacations)
            {
                item.User = _jwtAuthenticationService.GetUserById(item.UserId);
            }

            return vacations;
        }
    }
}
