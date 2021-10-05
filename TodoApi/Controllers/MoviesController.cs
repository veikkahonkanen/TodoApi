using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.DataTransferObjects.Outgoing;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        // Dependency injection
        private readonly MovieContext _context;
        private readonly IMapper _mapper;

        public MoviesController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetMovies()
        {
            //var movies = await _context.Movies.ToListAsync();

            // return _mapper.Map<IEnumerable<MovieDto>>(movies);

            // Same as below
            // var movieDtos = _mapper.Map<List<MovieDto>>(movies);

            // return movies;

            return await _context.Movies
                // .Include(x => x.Crews).ThenInclude(x => x.Actor).ThenInclude(x => x.Person)
                .AsNoTracking()
                .ProjectTo<MovieDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDto>> GetMovie(long id, bool showOnlyCriticReviews)
        {
            // SingleAsync returns an item, and crashes if not found. SingleOrDefault returns null, if not found. FirstOrDefault return the first matching item.
            // Do not use:
            // var otherMovie = await _context.Movies.SingleAsync(x => x.Id == id);
            // var firstMovie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);

            // var allMovieActors = _context.Movies.Include(x => x.Crews).ThenInclude(x => x.Actor);
            // var allReviewTexts = _context.Movies.Include(x => x.Reviews).SingleOrDefault(m => m.Id == id)?.Reviews.Where(r => r.IsCriticRated == showOnlyCriticReviews).Select(x => x.Text);
            // movie = await _context.Movies.Include(x => x.Reviews.Where(r => r.IsCriticRated == showOnlyCriticReviews)).SingleOrDefaultAsync(x => x.Id == id);
            // var review = _context.Reviews.Include(x => x.Movie).ThenInclude(x => x.Crews).ToList();

            var movie = await _context.Movies
                .Include(x => x.Genres)
                .Include(x => x.ProducingCompany)
                // .Include(x => x.Crews).ThenInclude(x => x.Actor).ThenInclude(x => x.Person)
                // .Include(x => x.Crews).ThenInclude(x => x.Director).ThenInclude(x => x.Person)
                .Include(x => x.Reviews.Where(r => r.IsCriticRated == showOnlyCriticReviews))
                .AsNoTracking() // No need to track the searched items. Speeds up the search and improves performance. Only use when not changing the values of the items in DB, just returning them
                .SingleOrDefaultAsync(x => x.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            /*var movieDto = new MovieDto()
            {
                Name = movie.Name,
                Description = movie.Description,
                ReleaseDate = movie.ReleaseDate,
                Genres = movie.Genres,
                ProducingCompanyId = movie.ProducingCompanyId,
                ProducingCompany = movie.ProducingCompany,
            };

            foreach (var review in movie.Reviews)
            {
                var reviewDto = new ReviewDto()
                {
                    Id = review.Id,
                    Rating = review.Rating,
                    IsCriticRated = review.IsCriticRated,
                    Text = review.Text,
                    MovieId = review.MovieId
                };
            
                movieDto.Reviews.Add(reviewDto);
            }*/

            // var reviewId = movie.Reviews.Select(x => x.Id);

            var movieDto = _mapper.Map<MovieDto>(movie);

            // movieDto.Actors = _mapper.Map<List<PersonDto>>(movie.Crews.Where(x => x.Actor != null).Select(x => x.Actor.Person)).ToList();

            // movieDto.Directors = _mapper.Map<List<PersonDto>>(movie.Crews.Where(x => x.Director != null).Select(x => x.Director.Person)).ToList();

            // movieDto.Reviews = _mapper.Map<List<ReviewDto>>(movie.Reviews).ToList();

            return movieDto;
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(long id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(long id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieExists(long id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}
