using HW_4_6_Chernysh.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4_6_Chernysh.Migrations
{
    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasMaxLength(50);

            builder.HasOne(x => x.Genre)
                .WithMany(x => x.Songs)
                .HasForeignKey(x => x.GenreId);

        }
    }
}
