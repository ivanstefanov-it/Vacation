using Microsoft.EntityFrameworkCore;
using Vacation.Data.Models;

namespace Vacation.Data
{
    public class VacationDbContext : DbContext
    {
        public VacationDbContext()
        {

        }

        public VacationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Demo { get; set; }

        public DbSet<Models.Vacation> Vacations { get; set; }
    }

}