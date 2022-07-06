﻿using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Create(VacationCreateModel vacation)
        {
            try
            {
                _vacationService.Create(vacation);
            }
            catch (Exception )
            {

                return BadRequest();
            }

            return Ok();
        }
    }
}