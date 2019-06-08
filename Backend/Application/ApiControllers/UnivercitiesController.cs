using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Application.Context;
using Application.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace Application.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnivercitiesController : ControllerBase
    {
        private readonly NonStopContext _context;

        public UnivercitiesController(NonStopContext context)
        {
            _context = context;
        }

        // GET: api/Univercities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Univercity>>> GetUnivercities()
        {
            var specs = new Dictionary<int, List<Specialization>>();
            var univercitiesSet = new HashSet<int>();
            var univercities = new List<Univercity>();

            var univercitySpecializations = await (from u in _context.Univercities
                                join us in _context.UnivercitySpecializations on u.Id equals us.UnivercityId
                                join s in _context.Specializations on us.SpecializationId equals s.Id
                                select new
                                {
                                    Univercity = u,
                                    Specialization = s,
                                }).ToListAsync();
            foreach (var univercitySpecialization in univercitySpecializations) {
                if (!specs.ContainsKey(univercitySpecialization.Univercity.Id))
                {
                    specs.Add(univercitySpecialization.Univercity.Id, new List<Specialization>());
                }
                specs[univercitySpecialization.Univercity.Id].Add(univercitySpecialization.Specialization);
                if (!univercitiesSet.Contains(univercitySpecialization.Univercity.Id))
                {
                    univercitiesSet.Add(univercitySpecialization.Univercity.Id);
                    univercities.Add(univercitySpecialization.Univercity);
                }
            }

            foreach (var univercity in univercities)
            {
                univercity.Specializations = specs[univercity.Id];
            }

            return univercities;
        }

        // GET: api/Univercities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Univercity>> GetUnivercity(int id)
        {
            var univercity = await _context.Univercities.FindAsync(id);

            if (univercity == null)
            {
                return NotFound();
            }

            return univercity;
        }

        // PUT: api/Univercities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnivercity(int id, Univercity univercity)
        {
            if (id != univercity.Id)
            {
                return BadRequest();
            }

            _context.Entry(univercity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnivercityExists(id))
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

        // POST: api/Univercities
        [HttpPost]
        public async Task<ActionResult<Univercity>> PostUnivercity(Univercity univercity)
        {
            _context.Univercities.Add(univercity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUnivercity", new { id = univercity.Id }, univercity);
        }

        // DELETE: api/Univercities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Univercity>> DeleteUnivercity(int id)
        {
            var univercity = await _context.Univercities.FindAsync(id);
            if (univercity == null)
            {
                return NotFound();
            }

            _context.Univercities.Remove(univercity);
            await _context.SaveChangesAsync();

            return univercity;
        }

        private bool UnivercityExists(int id)
        {
            return _context.Univercities.Any(e => e.Id == id);
        }
    }
}
