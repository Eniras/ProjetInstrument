using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PriseEnMain.Data;
using PriseEnMain.Models;

namespace PriseEnMain.Controllers
{
    public class EmetteursController : Controller
    {
        private readonly PartengContext _context;

        public EmetteursController(PartengContext context)
        {
            _context = context;
        }

        // GET: Emetteurs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Emetteurs.ToListAsync());
        }

        // GET: Emetteurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emetteur = await _context.Emetteurs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emetteur == null)
            {
                return NotFound();
            }

            return View(emetteur);
        }

        // GET: Emetteurs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Emetteurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Emetteur emetteur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emetteur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emetteur);
        }

        // GET: Emetteurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emetteur = await _context.Emetteurs.FindAsync(id);
            if (emetteur == null)
            {
                return NotFound();
            }
            return View(emetteur);
        }

        // POST: Emetteurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Emetteur emetteur)
        {
            if (id != emetteur.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emetteur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmetteurExists(emetteur.Id))
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
            return View(emetteur);
        }

        // GET: Emetteurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emetteur = await _context.Emetteurs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emetteur == null)
            {
                return NotFound();
            }

            return View(emetteur);
        }

        // POST: Emetteurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emetteur = await _context.Emetteurs.FindAsync(id);
            _context.Emetteurs.Remove(emetteur);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmetteurExists(int id)
        {
            return _context.Emetteurs.Any(e => e.Id == id);
        }
    }
}
