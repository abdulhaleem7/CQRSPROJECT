using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PracticeDDD.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDDD.Persistence.Configuration.Entities
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasData(
                new Student
                {
                    Id = 1,
                    Name = "Haleem",
                    PhoneNumber = "09151073034",
                    SchoolName = "GCI",
                    Address = "salaudeenhaleem7@gmail.com",
                    StartDate = DateTime.Parse("10/12/2022 10:43:32"),
                    EndDate = DateTime.Now,
                } ,
                new Student
                {
                    Id = 2,
                    Name = "Haleem1",
                    PhoneNumber = "09151073033",
                    SchoolName = "GCI Ibadan",
                    Address = "salaudeenhaleem77@gmail.com",
                    StartDate = DateTime.Parse("10/12/2022 10:43:32"),
                    EndDate = DateTime.Now,
                }

                );
        }
    }
}
