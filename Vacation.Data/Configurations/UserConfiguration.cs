using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacation.Data.Models;

namespace Vacation.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        private ModelBuilder modelBuilder;
        public UserConfiguration(ModelBuilder builder)
        {
            modelBuilder = builder;

            //builder.Entity<User>().HasData(
            //     new User
            //     {
            //         Id = 123,
            //         FirstName = "System",
            //         LastName = "Admin",
            //         Password = "123456",
            //         MiddleName = "admin",
            //         BirthPlace = "Sofia",
            //         WorkExperienceInDays = 10,
            //         StartDate = DateTime.Now,
            //         VacationHours = 10
            //     },
            //     new User
            //     {

            //         Id = 1234,
            //         FirstName = "user",
            //         LastName = "Admin",
            //         Password = "123456",
            //         MiddleName = "admin",
            //         BirthPlace = "Sofia",
            //         WorkExperienceInDays = 10,
            //         StartDate = DateTime.Now,
            //         VacationHours = 10
            //     }
            //);
        }
        public void Configure(ModelBuilder builder)
        {
            //builder.Entity<User>().HasData(
            //     new User
            //     {
            //         Id = 123,
            //         FirstName = "System",
            //         LastName = "Admin",
            //         Password = "123456",
            //         MiddleName = "admin",
            //         BirthPlace = "Sofia",
            //         WorkExperienceInDays = 10,
            //         StartDate = DateTime.Now,
            //         VacationHours = 10
            //     },
            //     new User
            //     {

            //         Id = 1234,
            //         FirstName = "user",
            //         LastName = "Admin",
            //         Password = "123456",
            //         MiddleName = "admin",
            //         BirthPlace = "Sofia",
            //         WorkExperienceInDays = 10,
            //         StartDate = DateTime.Now,
            //         VacationHours = 10
            //     }
            //);
        }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            //builder.HasData(
            //      new User
            //      {
            //          Id = 123,
            //          FirstName = "System",
            //          LastName = "Admin",
            //          Password = "123456",
            //          MiddleName = "admin",
            //          BirthPlace = "Sofia",
            //          WorkExperienceInDays = 10,
            //          StartDate = DateTime.Now,
            //          VacationHours = 10
            //      },
            //      new User
            //      {

            //          Id = 1234,
            //          FirstName = "user",
            //          LastName = "Admin",
            //          Password = "123456",
            //          MiddleName = "admin",
            //          BirthPlace = "Sofia",
            //          WorkExperienceInDays = 10,
            //          StartDate = DateTime.Now,
            //          VacationHours = 10
            //      }
            // );
        }
    }
}
