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
    public class DirectorsController : ControllerBase
    {
        private readonly MovieContext _context;
        private readonly IMapper _mapper;

        public DirectorsController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Directors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDirectorDto>>> GetDirectors()
        {
            // return await _context.Directors.ToListAsync();

            return await _context.Directors
                .Include(x => x.Person)
                // .Include(x => x.Crews).ThenInclude(x => x.Movie)
                .AsNoTracking()
                .ProjectTo<MovieDirectorDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        // GET: api/Directors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDirectorDto>> GetDirector(long id)
        {
            var director = await _context.Directors
                // .Include(x => x.Crews).ThenInclude(x => x.Movie)
                .Include(x => x.Person)
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);

            if (director == null)
            {
                return NotFound();
            }

            var directorDto = _mapper.Map<MovieDirectorDto>(director);

            return directorDto;
        }

        // PUT: api/Directors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDirector(long id, MovieDirectorDtoIn director)
        {
            if (id != director.Id)
            {
                return BadRequest();
            }

            _context.Entry(director).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DirectorExists(id))
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

        // POST: api/Directors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MovieDirectorDtoIn>> PostDirector(MovieDirectorDtoIn director)
        {
            var entityDirector = _mapper.Map<Director>(director);

            _context.Directors.Add(entityDirector);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDirector", new { id = entityDirector.Id }, director);
        }

        // DELETE: api/Directors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDirector(long id)
        {
            var director = await _context.Directors.FindAsync(id);
            if (director == null)
            {
                return NotFound();
            }

            _context.Directors.Remove(director);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DirectorExists(long id)
        {
            return _context.Directors.Any(e => e.Id == id);
        }
    }
}
