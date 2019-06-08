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
    public class UnivercitySpecializationsController : ControllerBase
    {
        private readonly NonStopContext _context;

        public UnivercitySpecializationsController(NonStopContext context)
        {
            _context = context;
        }

        // GET: api/UnivercitySpecializations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnivercitySpecialization>>> GetUnivercitySpecialization()
        {
            return await _context.UnivercitySpecializations.ToListAsync();
        }

        // GET: api/UnivercitySpecializations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UnivercitySpecialization>> GetUnivercitySpecialization(int id)
        {
            var univercitySpecialization = await _context.UnivercitySpecializations.FindAsync(id);

            if (univercitySpecialization == null)
            {
                return NotFound();
            }

            return univercitySpecialization;
        }

        // PUT: api/UnivercitySpecializations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnivercitySpecialization(int id, UnivercitySpecialization univercitySpecialization)
        {
            if (id != univercitySpecialization.UnivercityId)
            {
                return BadRequest();
            }

            _context.Entry(univercitySpecialization).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnivercitySpecializationExists(id))
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

        // POST: api/UnivercitySpecializations
        [HttpPost]
        public async Task<ActionResult<UnivercitySpecialization>> PostUnivercitySpecialization(UnivercitySpecialization univercitySpecialization)
        {
            _context.UnivercitySpecializations.Add(univercitySpecialization);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UnivercitySpecializationExists(univercitySpecialization.UnivercityId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUnivercitySpecialization", new { id = univercitySpecialization.UnivercityId }, univercitySpecialization);
        }

        // DELETE: api/UnivercitySpecializations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UnivercitySpecialization>> DeleteUnivercitySpecialization(int id)
        {
            var univercitySpecialization = await _context.UnivercitySpecializations.FindAsync(id);
            if (univercitySpecialization == null)
            {
                return NotFound();
            }

            _context.UnivercitySpecializations.Remove(univercitySpecialization);
            await _context.SaveChangesAsync();

            return univercitySpecialization;
        }

        private bool UnivercitySpecializationExists(int id)
        {
            return _context.UnivercitySpecializations.Any(e => e.UnivercityId == id);
        }
    }
}
