﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoApi.Models;

namespace TodoApi.Migrations
{
    [DbContext(typeof(MovieContext))]
    partial class MovieContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.Property<long>("GenresId")
                        .HasColumnType("bigint");

                    b.Property<long>("MoviesId")
                        .HasColumnType("bigint");

                    b.HasKey("GenresId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("GenreMovie");
                });

            modelBuilder.Entity("TodoApi.Models.Actor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("MovieId")
                        .HasColumnType("bigint");

                    b.Property<long>("PersonId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("TodoApi.Models.Director", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("MovieId")
                        .HasColumnType("bigint");

                    b.Property<long>("PersonId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("TodoApi.Models.Genre", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("TodoApi.Models.Movie", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ProducingCompanyId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SecretInfo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProducingCompanyId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("TodoApi.Models.Person", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("TodoApi.Models.ProducingCompany", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProducingCompanies");
                });

            modelBuilder.Entity("TodoApi.Models.Review", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsCriticRated")
                        .HasColumnType("bit");

                    b.Property<long>("MovieId")
                        .HasColumnType("bigint");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.HasOne("TodoApi.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TodoApi.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TodoApi.Models.Actor", b =>
                {
                    b.HasOne("TodoApi.Models.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TodoApi.Models.Person", "Person")
                        .WithOne("Actor")
                        .HasForeignKey("TodoApi.Models.Actor", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("TodoApi.Models.Director", b =>
                {
                    b.HasOne("TodoApi.Models.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TodoApi.Models.Person", "Person")
                        .WithOne("Director")
                        .HasForeignKey("TodoApi.Models.Director", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("TodoApi.Models.Movie", b =>
                {
                    b.HasOne("TodoApi.Models.ProducingCompany", "ProducingCompany")
                        .WithMany("Movies")
                        .HasForeignKey("ProducingCompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProducingCompany");
                });

            modelBuilder.Entity("TodoApi.Models.Review", b =>
                {
                    b.HasOne("TodoApi.Models.Movie", "Movie")
                        .WithMany("Reviews")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("TodoApi.Models.Movie", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("TodoApi.Models.Person", b =>
                {
                    b.Navigation("Actor");

                    b.Navigation("Director");
                });

            modelBuilder.Entity("TodoApi.Models.ProducingCompany", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
