using HW4_3_Chernysh.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HW4_3_Chernysh.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.EmployeeId);
            builder.Property(x => x.FirstName).HasMaxLength(50);
            builder.Property(x => x.LastName).HasMaxLength(50);
            builder.Property(x => x.DateOfBirth).HasColumnType("date");

            builder.HasOne(x => x.Title).WithMany(x => x.Employees).HasForeignKey(x => x.TitleId);
            builder.HasOne(x => x.Office).WithMany(x => x.Employees).HasForeignKey(x => x.OfficeId);


        }
    }
}
