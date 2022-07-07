using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vacation.Services.Vacation;
using Vacation.Services.Vacation.Models;

namespace JWTSecondDemo.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class VacationController : ControllerBase
    {
        private readonly IVacationService _vacationService;

        public VacationController(IVacationService vacationService)
        {
            this._vacationService = vacationService;
        }

        [HttpPost]
        [Authorize]
        public ActionResult<Vacation.Data.Models.Vacation> Create(VacationCreateModel vacation)
        {
            Vacation.Data.Models.Vacation result;
            try
            {
                result = _vacationService.Create(vacation);
            }
            catch (Exception )
            {

                return BadRequest();
            }

            return Ok(result);
        }
        [HttpGet]
        public ActionResult<IReadOnlyList<Vacation.Data.Models.Vacation>> GetAllVacations()
        {
            return Ok(_vacationService.GetAllVacations());
        }
    }
}
