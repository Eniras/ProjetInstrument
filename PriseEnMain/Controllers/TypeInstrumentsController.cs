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
    public class TypeInstrumentsController : Controller
    {
        private readonly PartengContext _context;

        public TypeInstrumentsController(PartengContext context)
        {
            _context = context;
        }

        // GET: TypeInstruments
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.TypeInstruments.ToListAsync());
        //}

        public async Task<IActionResult> Index(string searchString)
        {
            var types = from m in _context.TypeInstruments
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                types = types.Where(s => s.Name.Contains(searchString));
            }

            return View(await types.ToListAsync());
        }

        public IActionResult SelectItem(TypeInstrument type)
        {
            InstrumentsController._type.Type = type;

            return RedirectToAction("Index");


        }



        // GET: TypeInstruments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeInstrument = await _context.TypeInstruments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeInstrument == null)
            {
                return NotFound();
            }

            return View(typeInstrument);
        }

        // GET: TypeInstruments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeInstruments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] TypeInstrument typeInstrument)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeInstrument);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeInstrument);
        }

        // GET: TypeInstruments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeInstrument = await _context.TypeInstruments.FindAsync(id);
            if (typeInstrument == null)
            {
                return NotFound();
            }
            return View(typeInstrument);
        }

        // POST: TypeInstruments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] TypeInstrument typeInstrument)
        {
            if (id != typeInstrument.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeInstrument);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeInstrumentExists(typeInstrument.Id))
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
            return View(typeInstrument);
        }

        // GET: TypeInstruments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeInstrument = await _context.TypeInstruments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeInstrument == null)
            {
                return NotFound();
            }

            return View(typeInstrument);
        }

        // POST: TypeInstruments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeInstrument = await _context.TypeInstruments.FindAsync(id);
            _context.TypeInstruments.Remove(typeInstrument);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeInstrumentExists(int id)
        {
            return _context.TypeInstruments.Any(e => e.Id == id);
        }
    }
}
