using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Locataion.Data.Entities;

namespace Location.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IlcelerController : ControllerBase
    {
        private readonly LocationDbContext _context;

        public IlcelerController(LocationDbContext context)
        {
            _context = context;
        }

        // GET: api/Ilceler
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ilce>>> GetIlces()
        {
          if (_context.Ilce == null)
          {
              return NotFound();
          }
            return await _context.Ilce.ToListAsync();
        }

        // GET: api/Ilceler/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ilce>> GetIlce(int id)
        {
          if (_context.Ilce == null)
          {
              return NotFound();
          }
            var ilce = await _context.Ilce.FindAsync(id);

            if (ilce == null)
            {
                return NotFound();
            }

            return ilce;
        }

        // PUT: api/Ilceler/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIlce(int id, Ilce ilce)
        {
            if (id != ilce.Id)
            {
                return BadRequest();
            }

            _context.Entry(ilce).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IlceExists(id))
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

        // POST: api/Ilceler
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ilce>> PostIlce(Ilce ilce)
        {
          if (_context.Ilce == null)
          {
              return Problem("Entity set 'LocationDbContext.Ilces'  is null.");
          }
            _context.Ilce.Add(ilce);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIlce", new { id = ilce.Id }, ilce);
        }

        // DELETE: api/Ilceler/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIlce(int id)
        {
            if (_context.Ilce == null)
            {
                return NotFound();
            }
            var ilce = await _context.Ilce.FindAsync(id);
            if (ilce == null)
            {
                return NotFound();
            }

            _context.Ilce.Remove(ilce);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IlceExists(int id)
        {
            return (_context.Ilce?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
