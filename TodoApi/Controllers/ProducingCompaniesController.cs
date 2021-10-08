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
    public class ProducingCompaniesController : ControllerBase
    {
        private readonly MovieContext _context;
        private readonly IMapper _mapper;

        public ProducingCompaniesController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ProducingCompanies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProducingCompanyDto>>> GetProducingCompanies()
        {
            return await _context.ProducingCompanies
                .Include(x => x.Movies)
                .AsNoTracking()
                .ProjectTo<ProducingCompanyDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        // GET: api/ProducingCompanies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProducingCompanyDto>> GetProducingCompany(long id)
        {
            var producingCompany = await _context.ProducingCompanies
                .Include(x => x.Movies)
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);

            if (producingCompany == null)
            {
                return NotFound();
            }

            var producingCompanyDto = _mapper.Map<ProducingCompanyDto>(producingCompany);

            return producingCompanyDto;
        }

        // PUT: api/ProducingCompanies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducingCompany(long id, ProducingCompanyDtoIn producingCompany)
        {
            if (id != producingCompany.Id)
            {
                return BadRequest();
            }

            _context.Entry(producingCompany).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProducingCompanyExists(id))
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

        // POST: api/ProducingCompanies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProducingCompanyDtoIn>> PostProducingCompany(ProducingCompanyDtoIn producingCompany)
        {
            var entityProducingCompany = _mapper.Map<ProducingCompany>(producingCompany);

            _context.ProducingCompanies.Add(entityProducingCompany);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProducingCompany", new { id = entityProducingCompany.Id }, producingCompany);
        }

        // DELETE: api/ProducingCompanies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducingCompany(long id)
        {
            var producingCompany = await _context.ProducingCompanies.FindAsync(id);
            if (producingCompany == null)
            {
                return NotFound();
            }

            _context.ProducingCompanies.Remove(producingCompany);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProducingCompanyExists(long id)
        {
            return _context.ProducingCompanies.Any(e => e.Id == id);
        }
    }
}
