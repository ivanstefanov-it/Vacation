using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacation.Services.Vacation.Models;

namespace Vacation.Services.Vacation
{
    public interface IVacationService
    {
        void Create(VacationCreateModel vacation);
    }
}
