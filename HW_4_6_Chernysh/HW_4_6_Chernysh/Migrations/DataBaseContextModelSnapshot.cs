﻿// <auto-generated />
using System;
using HW_4_6_Chernysh;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HW_4_6_Chernysh.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ArtistSong", b =>
                {
                    b.Property<int>("ArtistsId")
                        .HasColumnType("int");

                    b.Property<int>("SongsId")
                        .HasColumnType("int");

                    b.HasKey("ArtistsId", "SongsId");

                    b.HasIndex("SongsId");

                    b.ToTable("ArtistSong");

                    b.HasData(
                        new
                        {
                            ArtistsId = 1,
                            SongsId = 3
                        },
                        new
                        {
                            ArtistsId = 2,
                            SongsId = 2
                        },
                        new
                        {
                            ArtistsId = 3,
                            SongsId = 5
                        },
                        new
                        {
                            ArtistsId = 4,
                            SongsId = 1
                        },
                        new
                        {
                            ArtistsId = 5,
                            SongsId = 4
                        });
                });

            modelBuilder.Entity("HW_4_6_Chernysh.Models.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfDeath")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("InstagramUrl")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Phone")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Artists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfBirth = new DateTime(1994, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Сплин"
                        },
                        new
                        {
                            Id = 2,
                            DateOfBirth = new DateTime(1994, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InstagramUrl = "https://www.instagram.com/okeanelzy_official",
                            Name = "Океан Эльзы"
                        },
                        new
                        {
                            Id = 3,
                            DateOfBirth = new DateTime(2000, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InstagramUrl = "https://www.instagram.com/yeat",
                            Name = "Yeat"
                        },
                        new
                        {
                            Id = 4,
                            DateOfBirth = new DateTime(1988, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Deftones"
                        },
                        new
                        {
                            Id = 5,
                            DateOfBirth = new DateTime(1987, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfDeath = new DateTime(2000, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Сектор Газа"
                        });
                });

            modelBuilder.Entity("HW_4_6_Chernysh.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Alternative rock"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Punk rock"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Post-punk"
                        },
                        new
                        {
                            Id = 4,
                            Title = "Hip hop"
                        },
                        new
                        {
                            Id = 5,
                            Title = "Indie rock"
                        });
                });

            modelBuilder.Entity("HW_4_6_Chernysh.Models.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReleasedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("Songs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Duration = new TimeSpan(0, 0, 6, 53, 0),
                            GenreId = 1,
                            ReleasedDate = new DateTime(2012, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Rosemary"
                        },
                        new
                        {
                            Id = 2,
                            Duration = new TimeSpan(0, 0, 4, 30, 0),
                            GenreId = 1,
                            ReleasedDate = new DateTime(2005, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Без бою"
                        },
                        new
                        {
                            Id = 3,
                            Duration = new TimeSpan(0, 0, 4, 10, 0),
                            GenreId = 5,
                            ReleasedDate = new DateTime(2014, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Танцуй!"
                        },
                        new
                        {
                            Id = 4,
                            Duration = new TimeSpan(0, 0, 3, 44, 0),
                            GenreId = 2,
                            ReleasedDate = new DateTime(1992, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Бомж"
                        },
                        new
                        {
                            Id = 5,
                            Duration = new TimeSpan(0, 0, 2, 54, 0),
                            GenreId = 4,
                            ReleasedDate = new DateTime(2022, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Talk"
                        });
                });

            modelBuilder.Entity("ArtistSong", b =>
                {
                    b.HasOne("HW_4_6_Chernysh.Models.Artist", null)
                        .WithMany()
                        .HasForeignKey("ArtistsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HW_4_6_Chernysh.Models.Song", null)
                        .WithMany()
                        .HasForeignKey("SongsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HW_4_6_Chernysh.Models.Song", b =>
                {
                    b.HasOne("HW_4_6_Chernysh.Models.Genre", "Genre")
                        .WithMany("Songs")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("HW_4_6_Chernysh.Models.Genre", b =>
                {
                    b.Navigation("Songs");
                });
#pragma warning restore 612, 618
        }
    }
}
