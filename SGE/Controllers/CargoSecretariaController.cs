using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SGE.Models;

namespace SGE.Controllers
{
    public class CargoSecretariaController : Controller
    {
        private readonly SGEContext _context;

        public CargoSecretariaController(SGEContext context)
        {
            _context = context;
        }

        // GET: CargoSecretarias
        public async Task<IActionResult> Index()
        {
            return View(await _context.CargoSecretaria.ToListAsync());
        }

        // GET: CargoSecretarias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargoSecretaria = await _context.CargoSecretaria
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cargoSecretaria == null)
            {
                return NotFound();
            }

            return View(cargoSecretaria);
        }

        // GET: CargoSecretarias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CargoSecretarias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao")] CargoSecretaria cargoSecretaria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cargoSecretaria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cargoSecretaria);
        }

        // GET: CargoSecretarias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargoSecretaria = await _context.CargoSecretaria.FindAsync(id);
            if (cargoSecretaria == null)
            {
                return NotFound();
            }
            return View(cargoSecretaria);
        }

        // POST: CargoSecretarias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao")] CargoSecretaria cargoSecretaria)
        {
            if (id != cargoSecretaria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cargoSecretaria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CargoSecretariaExists(cargoSecretaria.Id))
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
            return View(cargoSecretaria);
        }

        // GET: CargoSecretarias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargoSecretaria = await _context.CargoSecretaria
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cargoSecretaria == null)
            {
                return NotFound();
            }

            return View(cargoSecretaria);
        }

        // POST: CargoSecretarias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cargoSecretaria = await _context.CargoSecretaria.FindAsync(id);
            _context.CargoSecretaria.Remove(cargoSecretaria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CargoSecretariaExists(int id)
        {
            return _context.CargoSecretaria.Any(e => e.Id == id);
        }
    }
}
