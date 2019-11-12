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
    public class ResponsavelController : Controller
    {
        private readonly SGEContext _context;

        public ResponsavelController(SGEContext context)
        {
            _context = context;
        }

        // GET: Responsavel
        public async Task<IActionResult> Index()
        {
            var sGEContext = _context.Responsavel.Include(r => r.EstadoCivil).Include(r => r.TipoUsuario);
            return View(await sGEContext.ToListAsync());
        }

        // GET: Responsavel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsavel = await _context.Responsavel
                .Include(r => r.EstadoCivil)
                .Include(r => r.TipoUsuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (responsavel == null)
            {
                return NotFound();
            }

            return View(responsavel);
        }

        // GET: Responsavel/Create
        public IActionResult Create()
        {
            ViewData["TipoUsuarioId"] = new SelectList(_context.TipoUsuario, "Id", "Perfil");
            ViewData["EstadoCivilId"] = new SelectList(_context.EstadoCivil, "Id", "Descricao");

            ViewData["Sexo"] = new List<SelectListItem>
            {
                new SelectListItem {Text="Selecione", Value = ""},
                new SelectListItem {Text="Masculino", Value = "Masculino"},
                new SelectListItem {Text="Feminino", Value = "Feminino"},
            };

            return View();
        }

        // POST: Responsavel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,CPF,Email,Celular,TelefoneFixo,DateNascimento,Sexo,Logradouro,Complemento,Bairro,Cidade,Estado,UF,CEP,Numero,ResposavelLegal,ResposavelFinanceiro,TipoUsuarioId,EstadoCivilId")] Responsavel responsavel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(responsavel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoUsuarioId"] = new SelectList(_context.TipoUsuario, "Id", "Perfil");
            ViewData["EstadoCivilId"] = new SelectList(_context.EstadoCivil, "Id", "Descricao");

            ViewData["Sexo"] = new List<SelectListItem>
            {
                new SelectListItem {Text="Selecione", Value = ""},
                new SelectListItem {Text="Masculino", Value = "Masculino"},
                new SelectListItem {Text="Feminino", Value = "Feminino"},
            };
            return View(responsavel);
        }

        // GET: Responsavel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsavel = await _context.Responsavel.FindAsync(id);
            if (responsavel == null)
            {
                return NotFound();
            }

            ViewData["TipoUsuarioId"] = new SelectList(_context.TipoUsuario, "Id", "Perfil");
            ViewData["EstadoCivilId"] = new SelectList(_context.EstadoCivil, "Id", "Descricao");

            ViewData["Sexo"] = new List<SelectListItem>
            {
                new SelectListItem {Text="Selecione", Value = ""},
                new SelectListItem {Text="Masculino", Value = "Masculino"},
                new SelectListItem {Text="Feminino", Value = "Feminino"},
            };
            return View(responsavel);
        }

        // POST: Responsavel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,CPF,Email,Celular,TelefoneFixo,DateNascimento,Sexo,Logradouro,Complemento,Bairro,Cidade,Estado,UF,CEP,Numero,ResposavelLegal,ResposavelFinanceiro,TipoUsuarioId,EstadoCivilId")] Responsavel responsavel)
        {
            if (id != responsavel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(responsavel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResponsavelExists(responsavel.Id))
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
            ViewData["TipoUsuarioId"] = new SelectList(_context.TipoUsuario, "Id", "Perfil");
            ViewData["EstadoCivilId"] = new SelectList(_context.EstadoCivil, "Id", "Descricao");

            ViewData["Sexo"] = new List<SelectListItem>
            {
                new SelectListItem {Text="Selecione", Value = ""},
                new SelectListItem {Text="Masculino", Value = "Masculino"},
                new SelectListItem {Text="Feminino", Value = "Feminino"},
            };
            return View(responsavel);
        }

        // GET: Responsavel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responsavel = await _context.Responsavel
                .Include(r => r.EstadoCivil)
                .Include(r => r.TipoUsuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (responsavel == null)
            {
                return NotFound();
            }

            return View(responsavel);
        }

        // POST: Responsavel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var responsavel = await _context.Responsavel.FindAsync(id);
            _context.Responsavel.Remove(responsavel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResponsavelExists(int id)
        {
            return _context.Responsavel.Any(e => e.Id == id);
        }
    }
}
