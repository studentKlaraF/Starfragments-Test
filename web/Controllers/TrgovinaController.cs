using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeminarskaNaloga.Data;
using SeminarskaNaloga.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;


namespace SeminarskaNaloga.Controllers
{
    public class TrgovinaController : Controller
    {
        private readonly TrgovinaContext _context;

        private readonly UserManager<AppUser> _usermanager;

        public TrgovinaController(TrgovinaContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _usermanager = userManager;
        }
        // GET: Trgovina
        public async Task<IActionResult> Index()
        {
              return View(await _context.Trgovina.ToListAsync());
        }

        // GET: Trgovina/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Trgovina == null)
            {
                return NotFound();
            }

            var trgovina = await _context.Trgovina
                .FirstOrDefaultAsync(m => m.TrgovinaId == id);
            if (trgovina == null)
            {
                return NotFound();
            }

            return View(trgovina);
        }

        // GET: Trgovina/Create
        [Authorize(Roles = "Admin, Lastnik")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ForAdmin()
        {
            return View(await _context.Trgovina.ToListAsync());
        }

        // POST: Trgovina/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Lastnik")]
        public async Task<IActionResult> Create([Bind("img,ime")] Trgovina trgovina)
        {   
            var trenutniUporabnik = await _usermanager.GetUserAsync(User); //zapiše kdo je prijavljen v aplikacijo
            if (ModelState.IsValid && trenutniUporabnik.TrgovinaId==null)
            {   
                trgovina.lastnik = trenutniUporabnik.Email;
                trenutniUporabnik.Trgovina = trgovina.ime;
                trenutniUporabnik.TrgovinaId = trgovina.TrgovinaId;
                _context.Add(trgovina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //return RedirectToAction(nameof(Index));
            return View(trgovina);
        }

        // GET: Trgovina/Edit/5
        [Authorize(Roles = "Admin, Lastnik")]
        public async Task<IActionResult> Edit(int? id)
        {   var trenutniUporabnik = await _usermanager.GetUserAsync(User); //zapiše kdo je prijavljen v aplikacijo
            if (trenutniUporabnik.TrgovinaId==id && (id == null || _context.Trgovina == null))
            {
                return NotFound();
            }

            var trgovina = await _context.Trgovina.FindAsync(id);
            if (trgovina == null)
            {
                return NotFound();
            }
            return View(trgovina);
        }

        // POST: Trgovina/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Lastnik")]
        public async Task<IActionResult> Edit(int id, [Bind("TrgovinaId,img,ime")] Trgovina trgovina)
        {
            if (id != trgovina.TrgovinaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trgovina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrgovinaExists(trgovina.TrgovinaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(trgovina);
        }

        // GET: Trgovina/Delete/5
        [Authorize(Roles = "Admin, Lastnik")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Trgovina == null)
            {
                return NotFound();
            }

            var trgovina = await _context.Trgovina
                .FirstOrDefaultAsync(m => m.TrgovinaId == id);
            if (trgovina == null)
            {
                return NotFound();
            }

            return View(trgovina);
        }

        // POST: Trgovina/Delete/5
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Lastnik")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Trgovina == null)
            {
                return Problem("Entity set 'TrgovinaContext.Trgovina'  is null.");
            }
            var trgovina = await _context.Trgovina.FindAsync(id);
            if (trgovina != null)
            {
                _context.Trgovina.Remove(trgovina);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrgovinaExists(int id)
        {
          return _context.Trgovina.Any(e => e.TrgovinaId == id);
        }
    }
}
