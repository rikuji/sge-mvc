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
    public class AlunoResponsavelController : Controller
    {
        private readonly SGEContext _context;

        public AlunoResponsavelController(SGEContext context)
        {
            _context = context;
        }

        // GET: AlunoResponsavels
        public async Task<IActionResult> Index()
        {
            var sGEContext = _context.AlunoResponsavel.Include(a => a.Aluno).Include(a => a.Responsavel);
            return View(await sGEContext.ToListAsync());
        }

        // GET: AlunoResponsavels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alunoResponsavel = await _context.AlunoResponsavel
                .Include(a => a.Aluno)
                .Include(a => a.Responsavel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alunoResponsavel == null)
            {
                return NotFound();
            }

            return View(alunoResponsavel);
        }

        // GET: AlunoResponsavels/Create
        public IActionResult Create()
        {
            ViewData["AlunoId"] = new SelectList(_context.Aluno, "Id", "Id");
            ViewData["ResponsavelId"] = new SelectList(_context.Responsavel, "Id", "Nome");
            return View();
        }

        // POST: AlunoResponsavels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ResponsavelId,AlunoId")] AlunoResponsavel alunoResponsavel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alunoResponsavel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlunoId"] = new SelectList(_context.Aluno, "Id", "Id", alunoResponsavel.AlunoId);
            ViewData["ResponsavelId"] = new SelectList(_context.Responsavel, "Id", "Id", alunoResponsavel.ResponsavelId);
            return View(alunoResponsavel);
        }

        // GET: AlunoResponsavels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alunoResponsavel = await _context.AlunoResponsavel.FindAsync(id);
            if (alunoResponsavel == null)
            {
                return NotFound();
            }
            ViewData["AlunoId"] = new SelectList(_context.Aluno, "Id", "Id", alunoResponsavel.AlunoId);
            ViewData["ResponsavelId"] = new SelectList(_context.Responsavel, "Id", "Id", alunoResponsavel.ResponsavelId);
            return View(alunoResponsavel);
        }

        // POST: AlunoResponsavels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ResponsavelId,AlunoId")] AlunoResponsavel alunoResponsavel)
        {
            if (id != alunoResponsavel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alunoResponsavel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoResponsavelExists(alunoResponsavel.Id))
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
            ViewData["AlunoId"] = new SelectList(_context.Aluno, "Id", "Id", alunoResponsavel.AlunoId);
            ViewData["ResponsavelId"] = new SelectList(_context.Responsavel, "Id", "Id", alunoResponsavel.ResponsavelId);
            return View(alunoResponsavel);
        }

        // GET: AlunoResponsavels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alunoResponsavel = await _context.AlunoResponsavel
                .Include(a => a.Aluno)
                .Include(a => a.Responsavel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alunoResponsavel == null)
            {
                return NotFound();
            }

            return View(alunoResponsavel);
        }

        // POST: AlunoResponsavels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alunoResponsavel = await _context.AlunoResponsavel.FindAsync(id);
            _context.AlunoResponsavel.Remove(alunoResponsavel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlunoResponsavelExists(int id)
        {
            return _context.AlunoResponsavel.Any(e => e.Id == id);
        }
    }
}
