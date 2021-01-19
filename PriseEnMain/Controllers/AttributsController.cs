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
    public class AttributsController : Controller
    {
        private readonly PartengContext _context;

        public AttributsController(PartengContext context)
        {
            _context = context;
        }

        // GET: Attributs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Attributs.ToListAsync());
        }

        // GET: Attributs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attribut = await _context.Attributs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attribut == null)
            {
                return NotFound();
            }

            return View(attribut);
        }

        // GET: Attributs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Attributs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Attribut attribut)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attribut);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(attribut);
        }

        public IActionResult SelectItem(Attribut attribut)
        {

            //InstrumentsController._instrument.Attributs = attribut;


            return RedirectToAction("CreateChooseAttribut", "Instruments", new { area = "" });
        }

        // GET: Attributs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attribut = await _context.Attributs.FindAsync(id);
            if (attribut == null)
            {
                return NotFound();
            }
            return View(attribut);
        }

        // POST: Attributs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Attribut attribut)
        {
            if (id != attribut.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attribut);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttributExists(attribut.Id))
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
            return View(attribut);
        }

        // GET: Attributs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attribut = await _context.Attributs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attribut == null)
            {
                return NotFound();
            }

            return View(attribut);
        }

        // POST: Attributs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var attribut = await _context.Attributs.FindAsync(id);
            _context.Attributs.Remove(attribut);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttributExists(int id)
        {
            return _context.Attributs.Any(e => e.Id == id);
        }
    }
}
