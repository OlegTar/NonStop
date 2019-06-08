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
    public class SpecializationSubjectsController : ControllerBase
    {
        private readonly NonStopContext _context;

        public SpecializationSubjectsController(NonStopContext context)
        {
            _context = context;
        }

        // GET: api/SpecializationSubjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpecializationSubject>>> GetSpecializationSubjects()
        {
            return await _context.SpecializationSubjects.ToListAsync();
        }

        // GET: api/SpecializationSubjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SpecializationSubject>> GetSpecializationSubject(int id)
        {
            var specializationSubject = await _context.SpecializationSubjects.FindAsync(id);

            if (specializationSubject == null)
            {
                return NotFound();
            }

            return specializationSubject;
        }

        // PUT: api/SpecializationSubjects/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpecializationSubject(int id, SpecializationSubject specializationSubject)
        {
            if (id != specializationSubject.Id)
            {
                return BadRequest();
            }

            _context.Entry(specializationSubject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecializationSubjectExists(id))
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

        // POST: api/SpecializationSubjects
        [HttpPost]
        public async Task<ActionResult<SpecializationSubject>> PostSpecializationSubject(SpecializationSubject specializationSubject)
        {
            _context.SpecializationSubjects.Add(specializationSubject);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpecializationSubject", new { id = specializationSubject.Id }, specializationSubject);
        }

        // DELETE: api/SpecializationSubjects/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SpecializationSubject>> DeleteSpecializationSubject(int id)
        {
            var specializationSubject = await _context.SpecializationSubjects.FindAsync(id);
            if (specializationSubject == null)
            {
                return NotFound();
            }

            _context.SpecializationSubjects.Remove(specializationSubject);
            await _context.SaveChangesAsync();

            return specializationSubject;
        }

        private bool SpecializationSubjectExists(int id)
        {
            return _context.SpecializationSubjects.Any(e => e.Id == id);
        }
    }
}
