using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PriseEnMain.Data;
using PriseEnMain.Models;
using PriseEnMain.ViewModels;

namespace PriseEnMain.Controllers
{
    public class ContratsController : Controller
    {
        private readonly PartengContext _context;

        public ContratsController(PartengContext context)
        {
            _context = context;
        }

        // GET: Contrats
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contrats.ToListAsync());
        }

        // GET: Contrats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contrat = await _context.Contrats
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contrat == null)
            {
                return NotFound();
            }

            return View(contrat);
        }

        // GET: Contrats/Create
        public IActionResult Create(int typeId, int emetteurId, int instrumentId)
        {
            var viewModel = new CreateInstrumentVM
            {
                TypeInstrumentId = typeId,
                EmetteurId = emetteurId,
                InstrumentSousJacentId = instrumentId,
              

            };

            return View(viewModel);
        }

        // POST: Contrats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( CreateInstrumentVM view)
        {
            Contrat contrat = new Contrat();
            contrat.Name = view.ContratName;

            
            //if (ModelState.IsValid)
            //{
                _context.Add(contrat);
                await _context.SaveChangesAsync();
                
                return RedirectToAction("Create", "Instruments", new { typeId = view.TypeInstrumentId, emetteurId = view.EmetteurId, instrumentId = view.InstrumentSousJacentId, contratId = contrat.Id });
            //}
            var viewModel = new CreateInstrumentVM
            {
                TypeInstrumentId = view.TypeInstrumentId,
                EmetteurId = view.EmetteurId,
                InstrumentSousJacentId = view.InstrumentSousJacentId,
                ContratName = view.ContratName,
                ContratId = contrat.Id

                //ContratName = Name,
                //ContratId = contrat.Id

            };

            return View(viewModel);
        }
        public IActionResult SelectItem(Contrat contrat)
        {

            //InstrumentsController._instrument.Contrat = contrat;


            return RedirectToAction("CreateChooseContrat", "Instruments", new { area = "" });
        }

        // GET: Contrats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contrat = await _context.Contrats.FindAsync(id);
            if (contrat == null)
            {
                return NotFound();
            }
            return View(contrat);
        }

        // POST: Contrats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Contrat contrat)
        {
            if (id != contrat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contrat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContratExists(contrat.Id))
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
            return View(contrat);
        }

        // GET: Contrats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contrat = await _context.Contrats
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contrat == null)
            {
                return NotFound();
            }

            return View(contrat);
        }

        // POST: Contrats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contrat = await _context.Contrats.FindAsync(id);
            _context.Contrats.Remove(contrat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContratExists(int id)
        {
            return _context.Contrats.Any(e => e.Id == id);
        }
    }
}
