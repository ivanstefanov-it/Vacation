using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacation.Data.Models
{
    public class BaseCommandResponse
    {
        public bool Success { get; set; }
        public string Token { get; set; }
        public int Id { get; set; }
    }
}
