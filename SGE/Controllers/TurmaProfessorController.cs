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
    public class TurmaProfessorController : Controller
    {
        private readonly SGEContext _context;

        public TurmaProfessorController(SGEContext context)
        {
            _context = context;
        }

        // GET: TurmaProfessor
        public async Task<IActionResult> Index()
        {
            var sGEContext = _context.TurmaProfessor.Include(t => t.Professor).Include(t => t.Turma);
            return View(await sGEContext.ToListAsync());
        }

        // GET: TurmaProfessor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turmaProfessor = await _context.TurmaProfessor
                .Include(t => t.Professor)
                .Include(t => t.Turma)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turmaProfessor == null)
            {
                return NotFound();
            }

            return View(turmaProfessor);
        }

        // GET: TurmaProfessor/Create
        public IActionResult Create()
        {
            ViewData["ProfessorId"] = new SelectList(_context.Professores, "Id", "Id");
            ViewData["TurmaId"] = new SelectList(_context.Turma, "Id", "Id");
            return View();
        }

        // POST: TurmaProfessor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TurmaId,ProfessorId")] TurmaProfessor turmaProfessor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(turmaProfessor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProfessorId"] = new SelectList(_context.Professores, "Id", "Id", turmaProfessor.ProfessorId);
            ViewData["TurmaId"] = new SelectList(_context.Turma, "Id", "Id", turmaProfessor.TurmaId);
            return View(turmaProfessor);
        }

        // GET: TurmaProfessor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turmaProfessor = await _context.TurmaProfessor.FindAsync(id);
            if (turmaProfessor == null)
            {
                return NotFound();
            }
            ViewData["ProfessorId"] = new SelectList(_context.Professores, "Id", "Id", turmaProfessor.ProfessorId);
            ViewData["TurmaId"] = new SelectList(_context.Turma, "Id", "Id", turmaProfessor.TurmaId);
            return View(turmaProfessor);
        }

        // POST: TurmaProfessor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TurmaId,ProfessorId")] TurmaProfessor turmaProfessor)
        {
            if (id != turmaProfessor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turmaProfessor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurmaProfessorExists(turmaProfessor.Id))
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
            ViewData["ProfessorId"] = new SelectList(_context.Professores, "Id", "Id", turmaProfessor.ProfessorId);
            ViewData["TurmaId"] = new SelectList(_context.Turma, "Id", "Id", turmaProfessor.TurmaId);
            return View(turmaProfessor);
        }

        // GET: TurmaProfessor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turmaProfessor = await _context.TurmaProfessor
                .Include(t => t.Professor)
                .Include(t => t.Turma)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turmaProfessor == null)
            {
                return NotFound();
            }

            return View(turmaProfessor);
        }

        // POST: TurmaProfessor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var turmaProfessor = await _context.TurmaProfessor.FindAsync(id);
            _context.TurmaProfessor.Remove(turmaProfessor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurmaProfessorExists(int id)
        {
            return _context.TurmaProfessor.Any(e => e.Id == id);
        }
    }
}
