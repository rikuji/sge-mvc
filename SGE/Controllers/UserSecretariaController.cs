using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SGE.Models;

namespace SGE.Controllers
{
    [Authorize]
    public class UserSecretariaController : Controller
    {
        private readonly SGEContext _context;

        public UserSecretariaController(SGEContext context)
        {
            _context = context;
        }

        // GET: UserSecretaria
        public async Task<IActionResult> Index()
        {
            var sGEContext = _context.UserSecretaria.Include(u => u.TipoUsuario);
            return View(await sGEContext.ToListAsync());
        }

        // GET: UserSecretaria/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userSecretaria = await _context.UserSecretaria
                .Include(u => u.TipoUsuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userSecretaria == null)
            {
                return NotFound();
            }

            return View(userSecretaria);
        }

        // GET: UserSecretaria/Create
        public IActionResult Create()
        {
            ViewData["TipoUsuarioId"] = new SelectList(_context.TipoUsuario, "Id", "Id");
            return View();
        }

        // POST: UserSecretaria/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,CPF,Email,Cargo,TipoUsuarioId")] UserSecretaria userSecretaria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userSecretaria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoUsuarioId"] = new SelectList(_context.TipoUsuario, "Id", "Id", userSecretaria.TipoUsuarioId);
            return View(userSecretaria);
        }

        // GET: UserSecretaria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userSecretaria = await _context.UserSecretaria.FindAsync(id);
            if (userSecretaria == null)
            {
                return NotFound();
            }
            ViewData["TipoUsuarioId"] = new SelectList(_context.TipoUsuario, "Id", "Id", userSecretaria.TipoUsuarioId);
            return View(userSecretaria);
        }

        // POST: UserSecretaria/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,CPF,Email,Cargo,TipoUsuarioId")] UserSecretaria userSecretaria)
        {
            if (id != userSecretaria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userSecretaria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserSecretariaExists(userSecretaria.Id))
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
            ViewData["TipoUsuarioId"] = new SelectList(_context.TipoUsuario, "Id", "Id", userSecretaria.TipoUsuarioId);
            return View(userSecretaria);
        }

        // GET: UserSecretaria/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userSecretaria = await _context.UserSecretaria
                .Include(u => u.TipoUsuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userSecretaria == null)
            {
                return NotFound();
            }

            return View(userSecretaria);
        }

        // POST: UserSecretaria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userSecretaria = await _context.UserSecretaria.FindAsync(id);
            _context.UserSecretaria.Remove(userSecretaria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserSecretariaExists(int id)
        {
            return _context.UserSecretaria.Any(e => e.Id == id);
        }
    }
}
