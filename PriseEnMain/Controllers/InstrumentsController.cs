using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
            //var typeInstrument = await _context.TypeInstruments
            //    .Include(item => item.TypeInstrumentTypeAttributs)
            //        .ThenInclude(item => item.TypeAttribut)
            //    .SingleOrDefaultAsync(item => item.Name == "BSA");

            //var typesAttributsPossibles = typeInstrument
            //    .TypeInstrumentTypeAttributs
            //    .Select(item => item.TypeAttribut)
            //    .ToList();

            return View(await _context.Instruments.ToListAsync());
        }

        public async Task<IActionResult> CreateChooseTypeInstrument(string searchString, int typeId)
        {
            var viewModel = new CreateInstrumentVM
            {
                TypeInstrumentId = typeId,
            };

            var types = from m in _context.TypeInstruments
                        select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                types = types.Where(s => s.Name.Contains(searchString));
            }

            return View(await types.ToListAsync());
        }



        public async Task<IActionResult> CreateChooseEmetteur(string searchString, int typeId, CancellationToken cancellationToken)
        {
            var typeInstrument = await _context.TypeInstruments
                .Include(item => item.TypeInstrumentTypeAttributs)
                    .ThenInclude(item => item.TypeAttribut)
                .SingleOrDefaultAsync(item => item.Id == typeId);

            var typesAttributs = typeInstrument
                .TypeInstrumentTypeAttributs
                .Select(item => new CreateAttributViewModel
                {
                    AttributeTypeId = item.TypeAttributId,
                    AttributeTypeName = item.TypeAttribut.Name,
                    AttributeTypeValueType = item.TypeAttribut.Type,

                })
                .ToList();

            var list = typeInstrument
                .TypeInstrumentTypeAttributs;
            bool search = false;

            foreach (var typ in list)
            {
                if ( typ.TypeAttribut.Name == "Emetteur")
                {
                    search = true;
                }
            }

            if(search == false)
            {
                return RedirectToAction("CreateChooseInstrumentSousjacent", new { typeId = typeId });
            }

                    var query = _context.Emetteurs
                .AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                query = query.Where(s => s.Name.Contains(searchString));
            }

            var emetteurs = await query
                .Select(item => new EmetteurVM { Id = item.Id, Name = item.Name })
                .ToListAsync(cancellationToken);

            var viewModel = new CreateInstrumentVM
            {
                TypeInstrumentId = typeId,
                Emetteurs = emetteurs,
                Attributs = typesAttributs
            };

            return View(viewModel);
        }



        public async Task<IActionResult> CreateChooseInstrumentSousjacent(string searchString, int typeId, int emetteurId, CancellationToken cancellationToken)
        {
            var typeInstrument = await _context.TypeInstruments
               .Include(item => item.TypeInstrumentTypeAttributs)
                   .ThenInclude(item => item.TypeAttribut)
               .SingleOrDefaultAsync(item => item.Id == typeId);

            var typesAttributs = typeInstrument
                .TypeInstrumentTypeAttributs
                .Select(item => new CreateAttributViewModel
                {
                    AttributeTypeId = item.TypeAttributId,
                    AttributeTypeName = item.TypeAttribut.Name,
                    AttributeTypeValueType = item.TypeAttribut.Type,

                })
                .ToList();

            var instru = await _context.Instruments.FindAsync(typeId);
            var query = _context.Instruments
                .AsQueryable();


            var list = typeInstrument
                .TypeInstrumentTypeAttributs;

            bool search = false;

            foreach (var typ in list)
            {
                if (typ.TypeAttribut.Name == "Instrument")
                {
                    search = true;
                }
            }

            if (search == false)
            {
                return RedirectToAction("CreateChooseContrat", new { typeId = typeId });
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                query = query.Where(s => s.Name.Contains(searchString));
            }

            //TypeInstrument TypeInstru = (TypeInstrument)ViewBag.selectItem;


            query = query.Where(s => s.TypeInstrument.Id.Equals(typeId));


            var intrumens = await query
                  .Select(item => new InstrumentsSousJacentsVM { Id = item.Id, Name = item.Name })
                  .ToListAsync(cancellationToken);

            var viewModel = new CreateInstrumentVM
            {
                TypeInstrumentId = typeId,
                EmetteurId = emetteurId,
                InstrumentsSousJacents = intrumens,
                Attributs = typesAttributs
            };

            return View(viewModel);

        }


<<<<<<< HEAD



        public async Task<IActionResult> CreateChooseContrat(string searchString, int typeId, int emetteurId, int instrumentId, CancellationToken cancellationToken)
        {


            var typeInstrument = await _context.TypeInstruments
              .Include(item => item.TypeInstrumentTypeAttributs)
                  .ThenInclude(item => item.TypeAttribut)
              .SingleOrDefaultAsync(item => item.Id == typeId);

            var typesAttributs = typeInstrument
                .TypeInstrumentTypeAttributs
                .Select(item => new CreateAttributViewModel
                {
                    AttributeTypeId = item.TypeAttributId,
                    AttributeTypeName = item.TypeAttribut.Name,
                    AttributeTypeValueType = item.TypeAttribut.Type,
=======
        public async Task<IActionResult> CreateChooseAttribut(string searchString, int typeId, int emetteurId, int instrumentId,int contratId, CancellationToken cancellationToken)
        {
            var query = _context.Attributs
               .AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                query = query.Where(s => s.Name.Contains(searchString));
            }

            query = query.Where(s => s.TypeInstrument.Id.Equals(typeId));

            var attributs = await query
                  .Select(item => new AttributVM { Id = item.Id, Name = item.Name, TypeAttribut = item.TypeAttribut })
                  .ToListAsync(cancellationToken);

            var viewModel = new CreateInstrumentVM
            {
                TypeInstrumentId = typeId,
                EmetteurId = emetteurId,
                ContratId = contratId,
                InstrumentSousJacentId = instrumentId,
                Attributs = attributs
            };

            return View(viewModel);
        }
>>>>>>> e3accd7050a85c28ae57251593eeaa2ce74cd1d4

                })
                .ToList();

<<<<<<< HEAD
            var list = typeInstrument
               .TypeInstrumentTypeAttributs;
            bool search = false;
            foreach (var typ in list)
            {
                if (typ.TypeAttribut.Name == "Contrat")
                {
                    search = true;
                }
            }

            if (search == false)
            {
                return RedirectToAction("CreateChooseAttribut", new { typeId = typeId });
            }
=======
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateChooseAttribut(CreateInstrumentVM view)
        {

            var query = _context.Attributs
               .AsQueryable();

            query = query.Where(s => s.TypeInstrument.Id.Equals(view.TypeInstrumentId));

            var attributs = await query
                  .Select(item => new AttributVM
                  {
                      Id = item.Id,
                      Name = item.Name,
                      TypeAttribut = item.TypeAttribut,
                      value = item.Value
                  })
                  .ToListAsync();

            var viewModel = new CreateInstrumentVM
            {
                TypeInstrumentId = view.TypeInstrumentId,
                EmetteurId = view.EmetteurId,
                ContratId = view.ContratId,
                InstrumentSousJacentId = view.InstrumentSousJacentId,
                Attributs = attributs

            };

           // RedirectToAction("Create", "Instruments", new { typeId = view.TypeInstrumentId, emetteurId = view.EmetteurId, instrumentId = view.InstrumentSousJacentId, contratId = view.ContratId, attributs = view.Attributs });
            //}
            return View(viewModel);
        
    }



    public async Task<IActionResult> CreateChooseContrat(string searchString, int typeId, int emetteurId,int instrumentId, CancellationToken cancellationToken)
        {
           
>>>>>>> e3accd7050a85c28ae57251593eeaa2ce74cd1d4
            var query = _context.Contrats
                .AsQueryable();



            if (!String.IsNullOrEmpty(searchString))
            {
                query = query.Where(s => s.Name.Contains(searchString));
            }
            var contrats = await query
                  .Select(item => new ContratsVM { Id = item.Id, Name = item.Name })
                  .ToListAsync(cancellationToken);

            var viewModel = new CreateInstrumentVM
            {
                TypeInstrumentId = typeId,
                EmetteurId = emetteurId,
                InstrumentSousJacentId = instrumentId,
                Contrats = contrats,
                Attributs = typesAttributs
            };

            return View(viewModel);

        }

        public async Task<IActionResult> CreateChooseAttribut(int typeId, int emetteurId, int instrumentId, int contratId, CancellationToken cancellationToken)
        {
            var typeInstrument = await _context.TypeInstruments
              .Include(item => item.TypeInstrumentTypeAttributs)
                  .ThenInclude(item => item.TypeAttribut)
              .SingleOrDefaultAsync(item => item.Id == typeId);

            var typesAttributs = typeInstrument
                .TypeInstrumentTypeAttributs
                .Select(item => new CreateAttributViewModel
                {
                    AttributeTypeId = item.TypeAttributId,
                    AttributeTypeName = item.TypeAttribut.Name,
                    AttributeTypeValueType = item.TypeAttribut.Type,

                })
                .ToList();

            var viewModel = new CreateInstrumentVM
            {
                TypeInstrumentId = typeId,
                EmetteurId = emetteurId,
                InstrumentSousJacentId = instrumentId,
                ContratId = contratId,
                Attributs = typesAttributs
            };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateChooseAttribut(CreateInstrumentVM view, CancellationToken cancellationToken)
        {


            //if (ModelState.IsValid)
            //{
            var Attributes =
               view.Attributs.Select(attr => new CreateAttributViewModel
               {
                   AttributeTypeId = attr.AttributeTypeId,
                   AttributeTypeName = attr.AttributeTypeName,
                   Value = attr.Value
               });

            //RedirectToAction("Save", new { typeId = view.TypeInstrumentId, emetteurId = view.EmetteurId, instrumentId = view.InstrumentSousJacentId, contratId = view.ContratId});
            //}

            

            var viewModel = new CreateInstrumentVM
            {
                TypeInstrumentId = view.TypeInstrumentId,
                EmetteurId = view.EmetteurId,
                InstrumentSousJacentId = view.InstrumentSousJacentId,
                ContratId = view.ContratId,
                Attributs = Attributes.ToList()
            };



            TempData["Attributs"] = JsonConvert.SerializeObject(Attributes);


            return RedirectToAction("Create", new { typeId = view.TypeInstrumentId, emetteurId = view.EmetteurId, instrumentId = view.InstrumentSousJacentId, contratId = view.ContratId });


            // return View(viewModel);

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
        public async Task<IActionResult> Create(int typeId, int? emetteurId, int? instrumentId, int? contratId, List<CreateAttributViewModel> Attributs)
        {
            var instru = await _context.Instruments.FindAsync(instrumentId);
            var emet = await _context.Emetteurs.FindAsync(emetteurId);
            var type = await _context.TypeInstruments.FindAsync(typeId);
            var contrat = await _context.Contrats.FindAsync(contratId);

            if (instru == null)
            {
                return NotFound();
            }

            var attributs = JsonConvert.DeserializeObject<IEnumerable<CreateAttributViewModel>>((string)TempData["Attributs"]);
            List<CreateAttributViewModel> attributes = attributs as List<CreateAttributViewModel>;
            // List<CreateAttributViewModel> attributs = TempData["Attributs"] as List<CreateAttributViewModel>;
            TempData["Attributes"] = JsonConvert.SerializeObject(attributes);
            var viewModel = new CreateInstrumentVM
            {
                TypeInstrumentId = typeId,
                EmetteurId = emetteurId,
                ContratId = contratId,
                InstrumentSousJacentId = instrumentId,
                InstrumentName = instru.Name,
                TypeInstrumentName = type.Name,
                EmetteurName = emet.Name,
                ContratName = contrat.Name,
                TypesInstruments = new SelectList(_context.TypeInstruments, "Id", "Name"),
                Attributs = attributes

            };

            return View(viewModel);
        }

        public async Task<IActionResult> Save(int typeId, int emetteurId, int instrumentId, int contratId)
        {
            var instru = await _context.Instruments.FindAsync(instrumentId);
            var emet = await _context.Emetteurs.FindAsync(emetteurId);
            var type = await _context.TypeInstruments.FindAsync(typeId);
            var contrat = await _context.Contrats.FindAsync(contratId);

            if (instru == null)
            {
                return NotFound();
            }
            var attributs = JsonConvert.DeserializeObject<IEnumerable<CreateAttributViewModel>>((string)TempData["Attributes"]);
            List<CreateAttributViewModel> attributes = attributs as List<CreateAttributViewModel>;



            var listAttributs = attributes
             .Select(item => new Attribut
             {
                 TypeAttributId = item.AttributeTypeId,
                 ValueOther = item.Value,

            }).ToList();

            var types = await _context.TypeAttributs.ToListAsync();
            foreach(var typ in types)
            {
                if (emetteurId >= 0 && typ.Name =="Emetteur")
                {
                    var attr = new Attribut
                    {
                        TypeAttributId = typ.Id,
                        ValueEmetteurId = emetteurId
                    };
                    listAttributs.Add(attr);
                }

                if (contratId >= 0 && typ.Name == "Contrat")
                {
                    var attr = new Attribut
                    {
                        TypeAttributId = typ.Id,
                        ValueContratId = contratId
                    };
                    listAttributs.Add(attr);
                }

                if (instrumentId >= 0 && typ.Name == "Instrument")
                {
                    var attr = new Attribut
                    {
                        TypeAttributId = typ.Id,
                        ValueInstrumentId= instrumentId
                    };
                    listAttributs.Add(attr);
                }
                
            }
            foreach (var item in listAttributs)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
            }
            

            var viewModel = new CreateInstrumentVM
            {
                TypeInstrumentId = typeId,
                EmetteurId = emetteurId,
                ContratId = contratId,
                InstrumentSousJacentId = instrumentId,
                InstrumentName = instru.Name,
                TypeInstrumentName = type.Name,
                EmetteurName = emet.Name,
                ContratName = contrat.Name,
                TypesInstruments = new SelectList(_context.TypeInstruments, "Id", "Name"),

            };

            Instrument instrument = new Instrument();

            if (ModelState.IsValid)
            {
               
                instrument.Name = viewModel.TypeInstrumentName ;
                instrument.TypeInstrumentId = viewModel.TypeInstrumentId;
                instrument.Attributs = listAttributs as ICollection<Attribut>;
                //instrument.ContratId = viewModel.ContratId;
                //instrument.InstrumentSousJacentId = viewModel.InstrumentSousJacentId;
                _context.Add(instrument);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Instruments", new { area = "" });
            }
            return View(viewModel);
        }


        // POST: Instruments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(CreateInstrumentVM viewModel)
        //{
        //    Instrument instrument = new Instrument();

        //    if (ModelState.IsValid)
        //    {
        //        instrument.Name = viewModel.InstrumentName;
        //        instrument.TypeInstrumentId = viewModel.TypeInstrumentId;
        //        instrument.EmetteurId = viewModel.EmetteurId;
        //        instrument.ContratId = viewModel.ContratId;
        //        instrument.InstrumentSousJacentId = viewModel.InstrumentSousJacentId;
        //        _context.Add(instrument);
        //        await _context.SaveChangesAsync();

        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(viewModel);
        //}



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
                //TypeInstrumentId = instrument.TypeInstrumentId,
                //EmetteurId = instrument.EmetteurId,
                //ContratId = instrument.ContratId,
                //InstrumentSousJacentId = instrument.InstrumentSousJacentId,
                //TypesInstruments = new SelectList(_context.TypeInstruments, "Id", "Name"),
                //Emetteurs = new SelectList(_context.Emetteurs, "Id", "Name"),
                //Contrats = new SelectList(_context.Contrats, "Id", "Name"),
                //InstrumentsSousJacents = new SelectList(_context.Instruments, "Id", "Name")
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
