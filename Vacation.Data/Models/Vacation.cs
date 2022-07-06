using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacation.Data.Models
{
    public class Vacation
    {
        public int Id { get; set; }
        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public VacationType Type { get; set; }

        public int UserId { get; set; }

        public User? User { get; set; }
    }

}
