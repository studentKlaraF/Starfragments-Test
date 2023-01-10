using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeminarskaNaloga.Data;
using SeminarskaNaloga.Models;

namespace web.Controllers_Api
{
    [Route("api/v1/Artikel")]
    [ApiController]
    public class ArtikelApiController : ControllerBase
    {
        private readonly TrgovinaContext _context;

        public ArtikelApiController(TrgovinaContext context)
        {
            _context = context;
        }

        // GET: api/ArtikelApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artikel>>> GetArtikel()
        {
            return await _context.Artikel.ToListAsync();
        }

        // GET: api/ArtikelApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artikel>> GetArtikel(int id)
        {
            var artikel = await _context.Artikel.FindAsync(id);

            if (artikel == null)
            {
                return NotFound();
            }

            return artikel;
        }

        // PUT: api/ArtikelApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtikel(int id, Artikel artikel)
        {
            if (id != artikel.ArtikelId)
            {
                return BadRequest();
            }

            _context.Entry(artikel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtikelExists(id))
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

        // POST: api/ArtikelApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Artikel>> PostArtikel(Artikel artikel)
        {
            _context.Artikel.Add(artikel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArtikel", new { id = artikel.ArtikelId }, artikel);
        }

        // DELETE: api/ArtikelApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtikel(int id)
        {
            var artikel = await _context.Artikel.FindAsync(id);
            if (artikel == null)
            {
                return NotFound();
            }

            _context.Artikel.Remove(artikel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArtikelExists(int id)
        {
            return _context.Artikel.Any(e => e.ArtikelId == id);
        }
    }
}
