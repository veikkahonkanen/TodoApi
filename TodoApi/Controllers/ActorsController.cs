using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.DataTransferObjects.Incoming;
using TodoApi.DataTransferObjects.Outgoing;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly MovieContext _context;
        private readonly IMapper _mapper;

        public ActorsController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Actors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieActorDto>>> GetActors()
        {
            return await _context.Actors
                // .Include(x => x.Crews)?.ThenInclude(x => x.Movie)
                .Include(x => x.Person)?
                .AsNoTracking()
                .ProjectTo<MovieActorDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        [HttpGet("/GetActorsOfMovie/{id}")]
        public async Task<ActionResult<IEnumerable<MovieActorDto>>> GetActorsOfMovie(long id)
        {
            /*var crews = await _context.Crews
                .Where(x => x.MovieId == id)
                .Include(x => x.Actor).ThenInclude(x => x.Person)
                .ToListAsync();*/

            var actors = new List<MovieActorDto>();

            /*foreach (var crew in crews)
            {
                if (crew.Actor != null)
                {
                    var actorDto = new MovieActorDto()
                    {
                        Id = crew.Id,
                        Person = _mapper.Map<PersonDto>(crew.Actor.Person)
                    };

                    actors.Add(actorDto);
                }
            }*/

            actors = actors.OrderBy(x => x.LastName).ToList();

            return actors;
        }

        // GET: api/Actors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieActorDto>> GetActor(long id)
        {
            var actor = await _context.Actors
                // .Include(x => x.Crews).ThenInclude(x => x.Movie)
                .Include(x => x.Person)
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);

            if (actor == null)
            {
                return NotFound();
            }

            var actorDto = _mapper.Map<MovieActorDto>(actor);

            return actorDto;
        }

        // PUT: api/Actors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActor(long id, MovieActorDtoIn actor)
        {
            if (id != actor.Id)
            {
                return BadRequest();
            }

            _context.Entry(actor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActorExists(id))
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

        // POST: api/Actors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MovieActorDtoIn>> PostActor(MovieActorDtoIn actor)
        {
            var entityActor = _mapper.Map<Actor>(actor);

            _context.Actors.Add(entityActor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActor", new { id = entityActor.Id }, actor);
        }

        // DELETE: api/Actors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActor(long id)
        {
            var actor = await _context.Actors.FindAsync(id);
            if (actor == null)
            {
                return NotFound();
            }

            _context.Actors.Remove(actor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActorExists(long id)
        {
            return _context.Actors.Any(e => e.Id == id);
        }
    }
}
