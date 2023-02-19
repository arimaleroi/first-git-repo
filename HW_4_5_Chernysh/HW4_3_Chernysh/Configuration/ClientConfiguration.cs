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
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(x => x.ClientId);
            builder.Property(x => x.FirstName).HasMaxLength(50);
            builder.Property(x => x.LastName).HasMaxLength(50);
            builder.Property(x => x.PhoneNumber).HasMaxLength(50);

            builder.HasData(new Client { ClientId = 1, FirstName = "Alex", LastName = "Waero", PhoneNumber = "+380995511155", Email = "alexwaero@gmail.com" });
            builder.HasData(new Client { ClientId = 2, FirstName = "Tommy", LastName = "McShow", PhoneNumber = "+380506883490", Email = "tommymcshow@gmail.com" });
            builder.HasData(new Client { ClientId = 3, FirstName = "Santiago", LastName = "Welaso", PhoneNumber = "+380994719549", Email = "santiagowelaso@gmail.com" });
            builder.HasData(new Client { ClientId = 4, FirstName = "John", LastName = "Jones", PhoneNumber = "+380506883490", Email = "johnjones@gmail.com" });
            builder.HasData(new Client { ClientId = 5, FirstName = "Maximilliano", LastName = "Garcia", PhoneNumber = "+380665890477", Email = "maximillianogarcia@gmail.com" });

        }


    }
}
