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
    public class InstrumentSous_jacentController : Controller
    {
        private readonly PartengContext _context;

        public InstrumentSous_jacentController(PartengContext context)
        {
            _context = context;
        }

        // GET: InstrumentSous_jacent
        public async Task<IActionResult> Index()
        {
            var types = from m in _context.InstrumentSous_jacents
                        select m;

            if (!String.IsNullOrEmpty(InstrumentsController._type.Type.Name))
            {
                types = types.Where(s => s.Type.Equals(InstrumentsController._type.Type));
            }

            return View(await types.ToListAsync());

            //return View(await _context.InstrumentSous_jacents.ToListAsync());

        }

        // GET: InstrumentSous_jacent/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instrumentSous_jacent = await _context.InstrumentSous_jacents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (instrumentSous_jacent == null)
            {
                return NotFound();
            }

            return View(instrumentSous_jacent);
        }

        // GET: InstrumentSous_jacent/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InstrumentSous_jacent/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type")] InstrumentSous_jacent instrumentSous_jacent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instrumentSous_jacent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(instrumentSous_jacent);
        }

        // GET: InstrumentSous_jacent/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instrumentSous_jacent = await _context.InstrumentSous_jacents.FindAsync(id);
            if (instrumentSous_jacent == null)
            {
                return NotFound();
            }
            return View(instrumentSous_jacent);
        }

        // POST: InstrumentSous_jacent/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type")] InstrumentSous_jacent instrumentSous_jacent)
        {
            if (id != instrumentSous_jacent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instrumentSous_jacent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstrumentSous_jacentExists(instrumentSous_jacent.Id))
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
            return View(instrumentSous_jacent);
        }

        // GET: InstrumentSous_jacent/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instrumentSous_jacent = await _context.InstrumentSous_jacents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (instrumentSous_jacent == null)
            {
                return NotFound();
            }

            return View(instrumentSous_jacent);
        }

        // POST: InstrumentSous_jacent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instrumentSous_jacent = await _context.InstrumentSous_jacents.FindAsync(id);
            _context.InstrumentSous_jacents.Remove(instrumentSous_jacent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstrumentSous_jacentExists(int id)
        {
            return _context.InstrumentSous_jacents.Any(e => e.Id == id);
        }
    }
}
