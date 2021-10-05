using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<MovieContext>();

                // Add some objects to in memory database, so you hae some data when starting up the project
                GenerateMovieData(context);

                GenerateCrewData(context, 1);

                context.SaveChanges();
            }

            host.Run();
        }


        private static void GenerateMovieData(MovieContext context)
        {
            var genre = new Genre() { Name = "Komedia" };

            var genre2 = new Genre() { Name = "Tragedia" };

            var company = new ProducingCompany()
            {
                Name = "Joku yhtiö",
                Nationality = "FI"
            };

            var movie = new Movie()
            {
                Name = "Testielokuva",
                Description = "Testikuvaus",
                Reviews = new List<Review>() {
                        new Review() { Rating = 5, Text = "Viisi tähteä" },
                        new Review() { Rating = 3, Text = "Kolme tähteä" }
                    },
                Genres = new List<Genre>() {
                        genre,
                        genre2
                    },
                ProducingCompany = company,
                SecretInfo = "Ei asiakkaille nähtäväksi"
            };

            context.Movies.Add(movie);

            var movie2 = new Movie()
            {
                Name = "Testielokuva2",
                Description = "Testikuvaus2",
                Reviews = new List<Review>() {
                        new Review() { Rating = 2, Text = "Kaksi tähteä", IsCriticRated = true }
                    },
                Genres = new List<Genre>() {
                        genre
                    },
                ProducingCompany = company,
                SecretInfo = "Ei asiakkaille nähtäväksi"
            };

            context.Movies.Add(movie2);

            genre.Movies = new List<Movie>() { movie, movie2 };

            context.Genres.Add(genre);

            genre2.Movies = new List<Movie>() { movie };

            context.Genres.Add(genre2);

            company.Movies.Add(movie);

            company.Movies.Add(movie2);

            context.ProducingCompanies.Add(company);
        }

        /// <summary>
        /// Generates given data to given movie
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="movieId">Movie Id</param>
        private static void GenerateCrewData(MovieContext context, long movieId)
        {
            var personId = 12;
            var personId2 = 13;

            var actor = new Actor()
            {
                PersonId = personId,
                Crews = new List<Crew>()
            };

            var actor2 = new Actor()
            {
                PersonId = personId2,
                Crews = new List<Crew>()
            };

            var person = new Person()
            {
                Id = personId,
                FirstName = "Pena",
                LastName = "Koponen",
                BirthDate = DateTime.Now,
                Actor = actor
            };

            var person2 = new Person()
            {
                Id = personId2,
                FirstName = "Konrad",
                LastName = "Korppi",
                BirthDate = DateTime.Now,
                Actor = actor2
            };

            var actorCrew = new Crew()
            {
                ActorId = actor.Id,
                MovieId = movieId
            };

            actor.Crews.Add(actorCrew);

            var actorCrew2 = new Crew()
            {
                ActorId = actor2.Id,
                MovieId = movieId
            };

            actor.Crews.Add(actorCrew2);

            var directorPerson = new Person()
            {
                Id = 2,
                FirstName = "Ohjaaja",
                LastName = "Mies"
            };

            var director = new Director()
            {
                Id = 1,
                PersonId = directorPerson.Id
            };

            var directorCrew = new Crew()
            {
                DirectorId = directorPerson.Id,
                Director = director,
                MovieId = movieId
            };

            context.Directors.Add(director);

            context.Crews.Add(actorCrew);

            context.Crews.Add(directorCrew);

            context.Actors.Add(actor);

            context.Actors.Add(actor2);

            context.Persons.Add(person);

            context.Persons.Add(person2);
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
