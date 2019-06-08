using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Application.Context;
using Application.Models;
using AutoMapper;
using Application.ViewModels;
using System.IO;

namespace Application.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly NonStopContext _context;
        private readonly IMapper _mapper;

        public DocumentsController(NonStopContext context)
        {
            _context = context;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperProfile>();
            });
            _mapper = config.CreateMapper();
        }

        // GET: api/Documents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Document>>> GetDocuments()
        {
            var documents = await _context.Documents.ToListAsync();
            var documentViewModels = _mapper.Map<List<Document>>(documents);

            return documentViewModels;
        }

        // GET: api/Documents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Document>> GetDocument(int id)
        {
            var document = await _context.Documents.FindAsync(id);

            if (document == null)
            {
                return NotFound();
            }

            return document;
        }

        // PUT: api/Documents/5
        [HttpPost("{id}/{documentTypeId}/{personId}")]
        public async Task<IActionResult> PutDocument(int id, int documentTypeId, int personId, IFormFile file)
        {
            var document = await _context.Documents.FindAsync(id);

            _context.Entry(document).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentExists(id))
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

        // POST: api/Documents
        [HttpPost("{documentTypeId}/{personId}")]
        public async Task<ActionResult<Document>> PostDocument(int documentTypeId, int personId, IFormFile file)
        {
            await _context.SaveChangesAsync();
            var document = new Document
            {
                DocumentTypeId = documentTypeId,
                PersonId = personId,

            };

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                document.Image = memoryStream.ToArray();
            }

            _context.Documents.Add(document);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDocument", new { id = document.Id }, document);
        }

        // DELETE: api/Documents/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Document>> DeleteDocument(int id)
        {
            var document = await _context.Documents.FindAsync(id);
            if (document == null)
            {
                return NotFound();
            }

            _context.Documents.Remove(document);
            await _context.SaveChangesAsync();

            return document;
        }

        private bool DocumentExists(int id)
        {
            return _context.Documents.Any(e => e.Id == id);
        }
    }
}
