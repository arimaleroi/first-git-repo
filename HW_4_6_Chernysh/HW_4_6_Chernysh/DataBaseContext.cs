using HW_4_6_Chernysh.Migrations;
using HW_4_6_Chernysh.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_4_6_Chernysh
{
    public class DataBaseContext : DbContext
    {
        private string _connectionString;

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Song> Songs { get; set; }

        public DataBaseContext(string connectionString = "Data Source=DESKTOP-M3J7QC4\\SQLEXPRESS; Initial Catalog = DB_HW_4_6; Integrated Security = True; TrustServerCertificate=True")
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(_connectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArtistConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new SongConfiguration());

            modelBuilder
                .Entity<Artist>()
                .HasData(
                new Artist { Id = 1, Name = "Сплин", DateOfBirth = new DateTime(1994, 05, 27) },
                new Artist { Id = 2, Name = "Океан Эльзы", DateOfBirth = new DateTime(1994, 10, 12), InstagramUrl = "https://www.instagram.com/okeanelzy_official" },
                new Artist { Id = 3, Name = "Yeat", DateOfBirth = new DateTime(2000, 02, 26), InstagramUrl = "https://www.instagram.com/yeat" },
                new Artist { Id = 4, Name = "Deftones", DateOfBirth = new DateTime(1988, 01, 01) },
                new Artist { Id = 5, Name = "Сектор Газа", DateOfBirth = new DateTime(1987, 12, 05), DateOfDeath = new DateTime(2000, 07, 04) }
                );


            modelBuilder
                .Entity<Song>()
                .HasData(
                  new Song { Id = 1, Title = "Rosemary", GenreId = 1, Duration = new TimeSpan(0, 06, 53), ReleasedDate = new DateTime(2012, 11, 12) },
                  new Song { Id = 2, Title = "Без бою", GenreId = 1, Duration = new TimeSpan(0, 04, 30), ReleasedDate = new DateTime(2005, 09, 22) },
                  new Song { Id = 3, Title = "Танцуй!", GenreId = 5, Duration = new TimeSpan(0, 04, 10), ReleasedDate = new DateTime(2014, 09, 25) },
                  new Song { Id = 4, Title = "Бомж", GenreId = 2, Duration = new TimeSpan(0, 03, 44), ReleasedDate = new DateTime(1992, 01, 01) },
                  new Song { Id = 5, Title = "Talk", GenreId = 4, Duration = new TimeSpan(0, 02, 54), ReleasedDate = new DateTime(2022, 09, 02) }
                );

            modelBuilder
                .Entity<Genre>()
                .HasData(
                 new Genre { Id = 1, Title = "Alternative rock" },
                 new Genre { Id = 2, Title = "Punk rock" },
                 new Genre { Id = 3, Title = "Post-punk" },
                 new Genre { Id = 4, Title = "Hip hop" },
                 new Genre { Id = 5, Title = "Indie rock"}
                );

            modelBuilder.Entity<Artist>()
                .HasMany(x => x.Songs)
                .WithMany(x => x.Artists)
                .UsingEntity(x => x.HasData(
                    new { ArtistsId = 1, SongsId = 3 },
                    new { ArtistsId = 2, SongsId = 2 },
                    new { ArtistsId = 3, SongsId = 5 },
                    new { ArtistsId = 4, SongsId = 1 },
                    new { ArtistsId = 5, SongsId = 4 }
                    ));
        }
    }
}
