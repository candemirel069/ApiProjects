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
    public class SehirlerController : ControllerBase
    {
        private readonly LocationDbContext _context;

        public SehirlerController(LocationDbContext context)
        {
            _context = context;
        }

        // GET: api/Sehirler
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sehir>>> GetSehirs()
        {
          if (_context.Sehir == null)
          {
              return NotFound();
          }
            return await _context.Sehir.Include(it => it.Ilce).ToListAsync();
        }

        // GET: api/Sehirler/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sehir>> GetSehir(int id)
        {
          if (_context.Sehir == null)
          {
              return NotFound();
          }
            var sehir = await _context.Sehir.Include(it => it.Ilce).FirstOrDefaultAsync(x=>x.Id==id);

            if (sehir == null)
            {
                return NotFound();
            }

            return sehir;
        }

        // PUT: api/Sehirler/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSehir(int id, Sehir sehir)
        {
            if (id != sehir.Id)
            {
                return BadRequest();
            }

            _context.Entry(sehir).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SehirExists(id))
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

        // POST: api/Sehirler
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sehir>> PostSehir(Sehir sehir)
        {
          if (_context.Sehir == null)
          {
              return Problem("Entity set 'LocationDbContext.Sehirs'  is null.");
          }
            _context.Sehir.Add(sehir);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSehir", new { id = sehir.Id }, sehir);
        }

        // DELETE: api/Sehirler/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSehir(int id)
        {
            if (_context.Sehir == null)
            {
                return NotFound();
            }
            var sehir = await _context.Sehir.FindAsync(id);
            if (sehir == null)
            {
                return NotFound();
            }

            _context.Sehir.Remove(sehir);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SehirExists(int id)
        {
            return (_context.Sehir?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
