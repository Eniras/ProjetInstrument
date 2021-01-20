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
    public class InstrumentsController : Controller
    {
        private readonly PartengContext _context;
        public static InstrumentSous_jacent _type = new InstrumentSous_jacent();
        public static Instrument _instrument = new Instrument();



        public InstrumentsController(PartengContext context)
        {
            _context = context;
        }

        // GET: Instruments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Instruments.ToListAsync());
        }

        public async Task<IActionResult> CreateChooseTypeInstrument(string searchString)
        {
            var types = from m in _context.TypeInstruments
                        select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                types = types.Where(s => s.Name.Contains(searchString));
            }

            return View(await types.ToListAsync());
        }



        public async Task<IActionResult> CreateChooseEmetteur(string searchString)
        {
            //return View(await _context.Emetteurs.ToListAsync());

            var emetteurs = from m in _context.Emetteurs
                            select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                emetteurs = emetteurs.Where(s => s.Name.Contains(searchString));
            }

            return View(await emetteurs.ToListAsync());
        }


        public IActionResult SelectItem(TypeInstrument type)
        {
            ViewBag.selectItem = type;

            return RedirectToAction("CreateChooseTypeInstrument", "Instruments", new { area = "" });
        }


        public async Task<IActionResult> CreateChooseInstrumentSousjacent(string searchString)
        {
            //return View(await _context.InstrumentSous_jacents.ToListAsync());

            var instruments = from m in _context.Instruments
                              select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                instruments = instruments.Where(s => s.Name.Contains(searchString));
            }

            //TypeInstrument TypeInstru = (TypeInstrument)ViewBag.selectItem;

            //if (!String.IsNullOrEmpty(TypeInstru.Name))
            //{
            //    instruments = instruments.Where(s => s.TypeInstrument.Id.Equals(TypeInstru.Id)); 
            //}


            return View(await instruments.ToListAsync());
        }


        public async Task<IActionResult> CreateChooseAttribut(string searchString)
        {
            //return View(await _context.Attributs.ToListAsync());

            var attributs = from m in _context.Attributs
                            select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                attributs = attributs.Where(s => s.Name.Contains(searchString));
            }

            return View(await attributs.ToListAsync());
        }

        public async Task<IActionResult> CreateChooseContrat(string searchString)
        {
            //return View(await _context.Contrats.ToListAsync());

            var contrats = from m in _context.Contrats
                           select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                contrats = contrats.Where(s => s.Name.Contains(searchString));
            }

            return View(await contrats.ToListAsync());
        }



        // GET: Instruments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instrument = await _context.Instruments
                .Include(item => item.TypeInstrument)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (instrument == null)
            {
                return NotFound();
            }

            return View(instrument);
        }

        // GET: Instruments/Create
        public async Task<IActionResult> Create(int typeId, string searchTerm)
        {
            var typeInstrument = await _context.TypeInstruments.FindAsync(typeId);
            if (typeInstrument == null)
            {
                return NotFound();
            }

            var viewModel = new CreateInstrumentVM
            {
                TypeInstrumentId = typeId,
                TypeInstrumentName = typeInstrument.Name,
                TypesInstruments = new SelectList(_context.TypeInstruments, "Id", "Name"),
                Emetteurs = new SelectList(_context.Emetteurs, "Id", "Name"),
                Contrats = new SelectList(_context.Contrats, "Id", "Name"),
                InstrumentsSousJacents = new SelectList(_context.Instruments, "Id", "Name")
            };

            return View(viewModel);

        }

        // POST: Instruments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateInstrumentVM viewModel)
        {
            Instrument instrument = new Instrument();

            if (ModelState.IsValid)
            {
                instrument.Name = viewModel.Name;
                instrument.TypeInstrumentId = viewModel.TypeInstrumentId;
                instrument.EmetteurId = viewModel.EmetteurId;
                instrument.ContratId = viewModel.ContratId;
                instrument.InstrumentSousJacentId = viewModel.InstrumentSousJacentId;




                _context.Add(instrument);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }



            return View(viewModel);
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
                EmetteurId = instrument.EmetteurId,
                ContratId = instrument.ContratId,
                InstrumentSousJacentId = instrument.InstrumentSousJacentId,
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
                instrument.EmetteurId = viewModel.EmetteurId;
                instrument.ContratId = viewModel.ContratId;
                instrument.InstrumentSousJacentId = viewModel.InstrumentSousJacentId;

                try
                {
                    _context.Update(instrument);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();

                }
                return RedirectToAction(nameof(Index));
            }

            viewModel.TypesInstruments = new SelectList(_context.TypeInstruments, "Id", "Name", viewModel.TypeInstrumentId);
            viewModel.Emetteurs = new SelectList(_context.Emetteurs, "Id", "Name", viewModel.EmetteurId);
            viewModel.Contrats = new SelectList(_context.Contrats, "Id", "Name", viewModel.ContratId);
            viewModel.InstrumentsSousJacents = new SelectList(_context.Instruments, "Id", "Name", viewModel.InstrumentSousJacentId);

            return View(viewModel);
        }
        // GET: Instruments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instrument = await _context.Instruments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (instrument == null)
            {
                return NotFound();
            }

            return View(instrument);
        }

        // POST: Instruments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instrument = await _context.Instruments.FindAsync(id);
            _context.Instruments.Remove(instrument);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstrumentExists(int id)
        {
            return _context.Instruments.Any(e => e.Id == id);
        }
    }
}
