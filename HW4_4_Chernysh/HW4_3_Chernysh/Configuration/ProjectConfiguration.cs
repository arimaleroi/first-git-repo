using HW4_3_Chernysh.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4_3_Chernysh.Configuration
{
    internal class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(x => x.ProjectId);
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.Budget).HasColumnType("money");

            builder.HasOne(x => x.Client).WithMany(x => x.Projects).HasForeignKey(x => x.ClientId);

            builder.HasData(new Project { ProjectId = 1, Name = "FirstProject", Budget = 100000, StartedDate = new DateTime(2022,02,02), ClientId = 1 });
            builder.HasData(new Project { ProjectId = 2, Name = "SecondProject", Budget = 200000, StartedDate = new DateTime(2022,05,12), ClientId = 2 });
            builder.HasData(new Project { ProjectId = 3, Name = "ThirdProject", Budget = 300000, StartedDate = new DateTime(2022,07,01), ClientId = 3 });
            builder.HasData(new Project { ProjectId = 4, Name = "FourthProject", Budget = 400000, StartedDate = new DateTime(2023,01,01), ClientId = 4 });
            builder.HasData(new Project { ProjectId = 5, Name = "FifthProject", Budget = 500000, StartedDate = new DateTime(2023,07,17), ClientId = 5 });
        }
    }
}
