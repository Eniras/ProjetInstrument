using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PriseEnMain.Data;
using PriseEnMain.Models;
using PriseEnMain.ViewModels;

namespace PriseEnMain.Controllers
{
    public class InstrumentSous_jacentController : Controller
    {
        private readonly PartengContext _context;

        private TypeInstrument edit_Type;
        public InstrumentSous_jacentController(PartengContext context)
        {
            _context = context;
        }

        // GET: InstrumentSous_jacent
        public async Task<IActionResult> Index()
        {


            return View(await _context.InstrumentSous_jacents.ToListAsync());

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

        public IActionResult SelectItem(TypeInstrument instrumentSous_Jacent)
        {
            this.edit_Type = instrumentSous_Jacent;
            TypeInstrument type_instrument = InstrumentsController._type.Type;

            //InstrumentsController._instrument.instrumentSous_Jacent = instrumentSous_Jacent;

            //InstrumentsController._type = instrumentSous_Jacent;
            //InstrumentsController._type.Type = type_instrument;


            return RedirectToAction("Edit", "InstrumentSous_jacent", new { area = "" });
        }



        [HttpGet]
        public ActionResult Register(InstrumentSous_jacent instrusmentSous_jacent)
        {

            ViewBag.Types = _context.TypeInstruments.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            });


            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(InstrumentSous_jacent model, CancellationToken token)
        {
            if (!ModelState.IsValid)
            {
                var SelectListType = ViewBag.liste as List<TypeInstrument>;

                ViewBag.Types = SelectListType.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                });

                return View(model);
            }

            _context.Update(model);
            await _context.SaveChangesAsync(token);
            return RedirectToAction("Index");


        }

        // GET: InstrumentSous_jacent/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var instrument = await _context.Instruments
                .FindAsync(id);

            if (instrument == null)
            {
                return NotFound();
            }

            var viewModel = new EditInstrumentSousJacentVM
            {
                Id = instrument.Id,
                Name = instrument.Name,
                TypeInstrumentId = instrument.TypeInstrumentId,
                //EmetteurId = instrument.EmetteurId,
                //ContratId = instrument.ContratId,
                //InstrumentSousJacentId = instrument.InstrumentSousJacentId,
                TypesInstruments = new SelectList(_context.TypeInstruments, "Id", "Name"),
                Emetteurs = new SelectList(_context.Emetteurs, "Id", "Name"),
                Contrats = new SelectList(_context.Contrats, "Id", "Name"),
                InstrumentsSousJacents = new SelectList(_context.Instruments, "Id", "Name")
            };

            return View(viewModel);
        }

        // POST: InstrumentSous_jacent/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditInstrumentSousJacentVM viewModel)
        {
            var instrument = await _context.Instruments
                .FindAsync(id);

            if (id != viewModel.Id || instrument == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                instrument.Name = viewModel.Name;
                instrument.TypeInstrumentId = viewModel.TypeInstrumentId;
                //instrument.EmetteurId = viewModel.EmetteurId;
                //instrument.ContratId = viewModel.ContratId;
                //instrument.InstrumentSousJacentId = viewModel.InstrumentSousJacentId;

                try
                {
                    _context.Update(instrument);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstrumentSous_jacentExists(instrument.Id))
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

            viewModel.TypesInstruments = new SelectList(_context.TypeInstruments, "Id", "Name", viewModel.TypeInstrumentId);
            viewModel.Emetteurs = new SelectList(_context.Emetteurs, "Id", "Name", viewModel.EmetteurId);
            viewModel.Contrats = new SelectList(_context.Contrats, "Id", "Name", viewModel.ContratId);
            viewModel.InstrumentsSousJacents = new SelectList(_context.Instruments, "Id", "Name", viewModel.InstrumentSousJacentId);

            return View(viewModel);
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
