using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacation.Data.Models;

namespace Vacation.Services.Vacation.Models
{
    public class VacationCreateModel
    {
        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public VacationType Type { get; set; }

        public int UserId { get; set; }
    }
}
