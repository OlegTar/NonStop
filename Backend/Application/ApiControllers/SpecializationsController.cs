using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Application.Context;
using Application.Models;

namespace Application.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializationsController : ControllerBase
    {
        private readonly NonStopContext _context;

        public SpecializationsController(NonStopContext context)
        {
            _context = context;
        }

        // GET: api/Specializations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Specialization>>> GetSpecializations()
        {
            return await _context.Specializations.ToListAsync();
        }

        // GET: api/Specializations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Specialization>> GetSpecialization(int id)
        {
            var specialization = await _context.Specializations.FindAsync(id);

            if (specialization == null)
            {
                return NotFound();
            }

            return specialization;
        }

        // PUT: api/Specializations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpecialization(int id, Specialization specialization)
        {
            if (id != specialization.Id)
            {
                return BadRequest();
            }

            _context.Entry(specialization).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecializationExists(id))
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

        // POST: api/Specializations
        [HttpPost]
        public async Task<ActionResult<Specialization>> PostSpecialization(Specialization specialization)
        {
            _context.Specializations.Add(specialization);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpecialization", new { id = specialization.Id }, specialization);
        }

        // DELETE: api/Specializations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Specialization>> DeleteSpecialization(int id)
        {
            var specialization = await _context.Specializations.FindAsync(id);
            if (specialization == null)
            {
                return NotFound();
            }

            _context.Specializations.Remove(specialization);
            await _context.SaveChangesAsync();

            return specialization;
        }

        private bool SpecializationExists(int id)
        {
            return _context.Specializations.Any(e => e.Id == id);
        }
    }
}
