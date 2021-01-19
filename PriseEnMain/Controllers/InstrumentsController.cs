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
    public class InstrumentsController : Controller
    {
        private readonly PartengContext _context;
        public static InstrumentSous_jacent _type =new  InstrumentSous_jacent();
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

        public async Task<IActionResult> CreateChooseInstrumentSousjacent(string searchString)
        {
            //return View(await _context.InstrumentSous_jacents.ToListAsync());

            var instrumentSousjacents = from m in _context.InstrumentSous_jacents
                            select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                instrumentSousjacents = instrumentSousjacents.Where(s => s.Name.Contains(searchString));
            }


            if (!String.IsNullOrEmpty(InstrumentsController._type.Type.Name))
            {
                instrumentSousjacents = instrumentSousjacents.Where(s => s.Type.Equals(InstrumentsController._type.Type));
            }


            return View(await instrumentSousjacents.ToListAsync());
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
        public IActionResult Create()
        {
            return View();
        }

        // POST: Instruments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Instrument instrument)
        {
            instrument.TypeInstrument = _instrument.TypeInstrument;
            instrument.Emetteur = _instrument.Emetteur;
            //instrument.instrumentSous_Jacent = _instrument.instrumentSous_Jacent;
            instrument.Attributs= _instrument.Attributs;
            instrument.Contrat = _instrument.Contrat
                ;
            if (ModelState.IsValid)
            {
                _context.Add(instrument);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(instrument);
        }

        // GET: Instruments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instrument = await _context.Instruments.FindAsync(id);
            if (instrument == null)
            {
                return NotFound();
            }
            return View(instrument);
        }

        // POST: Instruments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Instrument instrument)
        {
            if (id != instrument.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instrument);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstrumentExists(instrument.Id))
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
            return View(instrument);
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
