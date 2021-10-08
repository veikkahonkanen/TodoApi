using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

        public override int SaveChanges()
        {
            AddTimeStamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddTimeStamps();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void AddTimeStamps()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseModel && (x.State == EntityState.Added || x.State == EntityState.Modified));

            if (entities.Any())
            {
                return;
            }

            var now = DateTime.UtcNow;

            foreach (var entity in entities)
            {
                var baseModel = (BaseModel)entity.Entity;

                if (entity.State == EntityState.Added)
                {
                    baseModel.CreatedAt = now;
                }

                baseModel.UpdatedAt = now;
            }
        }
    }
}
