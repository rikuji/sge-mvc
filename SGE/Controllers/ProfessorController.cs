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
    public class ProfessorController : Controller
    {
        private readonly SGEContext _context;

        public ProfessorController(SGEContext context)
        {
            _context = context;
        }

        // GET: Professor
        public async Task<IActionResult> Index()
        {
            var sGEContext = _context.Professores.Include(p => p.TipoUsuario);
            return View(await sGEContext.ToListAsync());
        }

        // GET: Professor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professores
                .Include(p => p.TipoUsuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professor == null)
            {
                return NotFound();
            }

            return View(professor);
        }

        // GET: Professor/Create
        public IActionResult Create()
        {
            ViewData["TipoUsuarioId"] = new SelectList(_context.TipoUsuario, "Id", "Perfil");

            ViewData["Sexo"] = new List<SelectListItem>
            {
                new SelectListItem {Text="Selecione", Value = ""},
                new SelectListItem {Text="Masculino", Value = "Masculino"},
                new SelectListItem {Text="Feminino", Value = "Feminino"},
            };

            ViewData["Turno"] = new List<SelectListItem>
            {
                new SelectListItem {Text="Selecione", Value = ""},
                new SelectListItem {Text="Matutino", Value = "Matutino"},
                new SelectListItem {Text="Vespertino", Value = "Vespertino"},
                new SelectListItem {Text="Noturno", Value = "Noturno"},
            };


            return View();
        }

        // POST: Professor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,CPF,Sexo,Email,Turno,Registro,TipoUsuarioId")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(professor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(professor);
        }

        // GET: Professor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professores.FindAsync(id);
            if (professor == null)
            {
                return NotFound();
            }
            ViewData["TipoUsuarioId"] = new SelectList(_context.TipoUsuario, "Id", "Perfil");
            ViewData["Sexo"] = new List<SelectListItem>
            {
                new SelectListItem {Text="Selecione", Value = ""},
                new SelectListItem {Text="Masculino", Value = "Masculino"},
                new SelectListItem {Text="Feminino", Value = "Feminino"},
            };

            ViewData["Turno"] = new List<SelectListItem>
            {
                new SelectListItem {Text="Selecione", Value = ""},
                new SelectListItem {Text="Matutino", Value = "Matutino"},
                new SelectListItem {Text="Vespertino", Value = "Vespertino"},
                new SelectListItem {Text="Noturno", Value = "Noturno"},
            };

            return View(professor);
        }

        // POST: Professor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,CPF,Sexo,Email,Turno,Registro,TipoUsuarioId")] Professor professor)
        {
            if (id != professor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessorExists(professor.Id))
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
            ViewData["TipoUsuarioId"] = new SelectList(_context.TipoUsuario, "Id", "Id", professor.TipoUsuarioId);
            ViewData["Sexo"] = new List<SelectListItem>
            {
                new SelectListItem {Text="Selecione", Value = ""},
                new SelectListItem {Text="Masculino", Value = "Masculino"},
                new SelectListItem {Text="Feminino", Value = "Feminino"},
            };
            ViewData["Turno"] = new List<SelectListItem>
            {
                new SelectListItem {Text="Selecione", Value = ""},
                new SelectListItem {Text="Matutino", Value = "Matutino"},
                new SelectListItem {Text="Vespertino", Value = "Vespertino"},
                new SelectListItem {Text="Noturno", Value = "Noturno"},
            };
            return View(professor);
        }

        // GET: Professor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professores
                .Include(p => p.TipoUsuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professor == null)
            {
                return NotFound();
            }

            return View(professor);
        }

        // POST: Professor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var professor = await _context.Professores.FindAsync(id);
            _context.Professores.Remove(professor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessorExists(int id)
        {
            return _context.Professores.Any(e => e.Id == id);
        }
    }
}
