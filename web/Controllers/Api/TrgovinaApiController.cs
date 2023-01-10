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
    [Route("api/v1/Trgovina")]
    [ApiController]
    public class TrgovinaApiController : ControllerBase
    {
        private readonly TrgovinaContext _context;

        public TrgovinaApiController(TrgovinaContext context)
        {
            _context = context;
        }

        // GET: api/TrgovinaApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trgovina>>> GetTrgovina()
        {
            return await _context.Trgovina.ToListAsync();
        }

        // GET: api/TrgovinaApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trgovina>> GetTrgovina(int id)
        {
            var trgovina = await _context.Trgovina.FindAsync(id);

            if (trgovina == null)
            {
                return NotFound();
            }

            return trgovina;
        }

        // PUT: api/TrgovinaApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrgovina(int id, Trgovina trgovina)
        {
            if (id != trgovina.TrgovinaId)
            {
                return BadRequest();
            }

            _context.Entry(trgovina).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrgovinaExists(id))
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

        // POST: api/TrgovinaApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Trgovina>> PostTrgovina(Trgovina trgovina)
        {
            _context.Trgovina.Add(trgovina);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrgovina", new { id = trgovina.TrgovinaId }, trgovina);
        }

        // DELETE: api/TrgovinaApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrgovina(int id)
        {
            var trgovina = await _context.Trgovina.FindAsync(id);
            if (trgovina == null)
            {
                return NotFound();
            }

            _context.Trgovina.Remove(trgovina);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrgovinaExists(int id)
        {
            return _context.Trgovina.Any(e => e.TrgovinaId == id);
        }
    }
}
