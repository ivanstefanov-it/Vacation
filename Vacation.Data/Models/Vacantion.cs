using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacation.Data.Models
{
    public class Vacantion
    {
        public DateOnly From { get; set; }

        public DateOnly To { get; set; }

        public VacationType Type { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }

}
