using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeminarskaNaloga.Data;
using SeminarskaNaloga.Models;
using Microsoft.AspNetCore.Identity;

namespace SeminarskaNaloga.Controllers
{
    public class ArtikelController : Controller
    {
        private readonly TrgovinaContext _context;
        private readonly UserManager<AppUser> _usermanager;

        public ArtikelController(TrgovinaContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _usermanager = userManager;
        }

        // GET: Artikel
        public async Task<IActionResult> Index()
        {
              return View(await _context.Artikel.ToListAsync());
        }

        // GET: Artikel/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Artikel == null)
            {
                return NotFound();
            }

            var artikel = await _context.Artikel
                .FirstOrDefaultAsync(m => m.ArtikelId == id);
            if (artikel == null)
            {
                return NotFound();
            }

            return View(artikel);
        }
        
        [Authorize]
        public async Task<IActionResult> ForAdmin()
        {
            return View(await _context.Artikel.ToListAsync());
        }

        // GET: Artikel/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Artikel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("img,naziv,cena,opis")] Artikel artikel)
        {   
            var trenutniUporabnik = await _usermanager.GetUserAsync(User); //zapiše kdo je prijavljen v aplikacijo
            string imeTrg = trenutniUporabnik.Trgovina; 

            if (ModelState.IsValid)
            {
                artikel.lastnik = trenutniUporabnik;
                artikel.trgovina = trenutniUporabnik.Trgovina;
                _context.Add(artikel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artikel);
        }

        // GET: Artikel/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Artikel == null)
            {
                return NotFound();
            }

            var artikel = await _context.Artikel.FindAsync(id);
            if (artikel == null)
            {
                return NotFound();
            }
            return View(artikel);
        }

        // POST: Artikel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("ArtikelId,img,naziv,cena,opis")] Artikel artikel)
        {
            if (id != artikel.ArtikelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artikel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtikelExists(artikel.ArtikelId))
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
            return View(artikel);
        }

        // GET: Artikel/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Artikel == null)
            {
                return NotFound();
            }

            var artikel = await _context.Artikel
                .FirstOrDefaultAsync(m => m.ArtikelId == id);
            if (artikel == null)
            {
                return NotFound();
            }

            return View(artikel);
        }

        // POST: Artikel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Artikel == null)
            {
                return Problem("Entity set 'TrgovinaContext.Artikel'  is null.");
            }
            var artikel = await _context.Artikel.FindAsync(id);
            if (artikel != null)
            {
                _context.Artikel.Remove(artikel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtikelExists(int id)
        {
          return _context.Artikel.Any(e => e.ArtikelId == id);
        }
    }
}
