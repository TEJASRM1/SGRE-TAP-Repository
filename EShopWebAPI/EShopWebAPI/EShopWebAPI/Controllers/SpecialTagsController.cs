using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EShopWebAPI.Data;
using EShopWebAPI.Models;

namespace EShopWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialTagsController : ControllerBase
    {
        private readonly EShopWebAPIContext _context;

        public SpecialTagsController(EShopWebAPIContext context)
        {
            _context = context;
        }

        // GET: api/SpecialTags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpecialTag>>> GetSpecialTag()
        {
          if (_context.SpecialTag == null)
          {
              return NotFound();
          }
            return await _context.SpecialTag.ToListAsync();
        }

        // GET: api/SpecialTags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SpecialTag>> GetSpecialTag(int id)
        {
          if (_context.SpecialTag == null)
          {
              return NotFound();
          }
            var specialTag = await _context.SpecialTag.FindAsync(id);

            if (specialTag == null)
            {
                return NotFound();
            }

            return specialTag;
        }

        // PUT: api/SpecialTags/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpecialTag(int id, SpecialTag specialTag)
        {
            if (id != specialTag.Id)
            {
                return BadRequest();
            }

            _context.Entry(specialTag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecialTagExists(id))
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

        // POST: api/SpecialTags
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SpecialTag>> PostSpecialTag(SpecialTag specialTag)
        {
          if (_context.SpecialTag == null)
          {
              return Problem("Entity set 'EShopWebAPIContext.SpecialTag'  is null.");
          }
            _context.SpecialTag.Add(specialTag);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpecialTag", new { id = specialTag.Id }, specialTag);
        }

        // DELETE: api/SpecialTags/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecialTag(int id)
        {
            if (_context.SpecialTag == null)
            {
                return NotFound();
            }
            var specialTag = await _context.SpecialTag.FindAsync(id);
            if (specialTag == null)
            {
                return NotFound();
            }

            _context.SpecialTag.Remove(specialTag);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SpecialTagExists(int id)
        {
            return (_context.SpecialTag?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
