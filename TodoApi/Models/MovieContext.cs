using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Actor> Actors { get; set; }

        public DbSet<Director> Directors { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<ProducingCompany> ProducingCompanies { get; set; }
    }
}
