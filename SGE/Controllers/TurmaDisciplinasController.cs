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
    public class TurmaDisciplinasController : Controller
    {
        private readonly SGEContext _context;

        public TurmaDisciplinasController(SGEContext context)
        {
            _context = context;
        }

        // GET: TurmaDisciplinas
        public async Task<IActionResult> Index()
        {
            var sGEContext = _context.TurmaDisciplina.Include(t => t.Disciplina).Include(t => t.Turma);
            return View(await sGEContext.ToListAsync());
        }

        // GET: TurmaDisciplinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turmaDisciplina = await _context.TurmaDisciplina
                .Include(t => t.Disciplina)
                .Include(t => t.Turma)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turmaDisciplina == null)
            {
                return NotFound();
            }

            return View(turmaDisciplina);
        }

        // GET: TurmaDisciplinas/Create
        public IActionResult Create()
        {
            ViewData["DisciplinaId"] = new SelectList(_context.Disciplina, "Id", "Id");
            ViewData["TurmaId"] = new SelectList(_context.Turma, "Id", "Id");
            return View();
        }

        // POST: TurmaDisciplinas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TurmaId,DisciplinaId")] TurmaDisciplina turmaDisciplina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(turmaDisciplina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DisciplinaId"] = new SelectList(_context.Disciplina, "Id", "Id", turmaDisciplina.DisciplinaId);
            ViewData["TurmaId"] = new SelectList(_context.Turma, "Id", "Id", turmaDisciplina.TurmaId);
            return View(turmaDisciplina);
        }

        // GET: TurmaDisciplinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turmaDisciplina = await _context.TurmaDisciplina.FindAsync(id);
            if (turmaDisciplina == null)
            {
                return NotFound();
            }
            ViewData["DisciplinaId"] = new SelectList(_context.Disciplina, "Id", "Id", turmaDisciplina.DisciplinaId);
            ViewData["TurmaId"] = new SelectList(_context.Turma, "Id", "Id", turmaDisciplina.TurmaId);
            return View(turmaDisciplina);
        }

        // POST: TurmaDisciplinas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TurmaId,DisciplinaId")] TurmaDisciplina turmaDisciplina)
        {
            if (id != turmaDisciplina.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turmaDisciplina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurmaDisciplinaExists(turmaDisciplina.Id))
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
            ViewData["DisciplinaId"] = new SelectList(_context.Disciplina, "Id", "Id", turmaDisciplina.DisciplinaId);
            ViewData["TurmaId"] = new SelectList(_context.Turma, "Id", "Id", turmaDisciplina.TurmaId);
            return View(turmaDisciplina);
        }

        // GET: TurmaDisciplinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turmaDisciplina = await _context.TurmaDisciplina
                .Include(t => t.Disciplina)
                .Include(t => t.Turma)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turmaDisciplina == null)
            {
                return NotFound();
            }

            return View(turmaDisciplina);
        }

        // POST: TurmaDisciplinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var turmaDisciplina = await _context.TurmaDisciplina.FindAsync(id);
            _context.TurmaDisciplina.Remove(turmaDisciplina);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurmaDisciplinaExists(int id)
        {
            return _context.TurmaDisciplina.Any(e => e.Id == id);
        }
    }
}
