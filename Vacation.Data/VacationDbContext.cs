using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vacation.Data.Configurations;
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
        public DbSet<User> Users { get; set; }

        public DbSet<Models.Vacation> Vacations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 123,
                FirstName = "System",
                LastName = "Admin",
                Password = "123456",
                MiddleName = "admin",
                BirthPlace = "Sofia",
                WorkExperienceInDays = 10,
                StartDate = DateTime.Now,
                VacationHours = 10
            });
            }
    }

}