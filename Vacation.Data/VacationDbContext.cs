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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=4WJ8LH2;Database=master;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }

}