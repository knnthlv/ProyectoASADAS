using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Wizard.Models;

namespace Wizard.Controllers
{
    public class MedidorController : Controller
    {
        private readonly asadaContext _context;

        public MedidorController(asadaContext context)
        {
            _context = context;
        }

        // GET: Medidor
        public async Task<IActionResult> Index()
        {
            var asadaContext = _context.Medidor.Include(m => m.CedulaNavigation);
            return View(await asadaContext.ToListAsync());
        }

        // GET: Medidor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medidor = await _context.Medidor
                .Include(m => m.CedulaNavigation)
                .FirstOrDefaultAsync(m => m.IdMedidor == id);
            if (medidor == null)
            {
                return NotFound();
            }

            return View(medidor);
        }

        // GET: Medidor/Create
        public IActionResult Create()
        {
            ViewData["Cedula"] = new SelectList(_context.Usuario, "Cedula", "Cedula");
            return View();
        }

        // POST: Medidor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMedidor,Direccion,Cedula")] Medidor medidor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medidor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cedula"] = new SelectList(_context.Usuario, "Cedula", "Cedula", medidor.Cedula);
            return View(medidor);
        }

        // GET: Medidor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medidor = await _context.Medidor.FindAsync(id);
            if (medidor == null)
            {
                return NotFound();
            }
            ViewData["Cedula"] = new SelectList(_context.Usuario, "Cedula", "Cedula", medidor.Cedula);
            return View(medidor);
        }

        // POST: Medidor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMedidor,Direccion,Cedula")] Medidor medidor)
        {
            if (id != medidor.IdMedidor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medidor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedidorExists(medidor.IdMedidor))
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
            ViewData["Cedula"] = new SelectList(_context.Usuario, "Cedula", "Cedula", medidor.Cedula);
            return View(medidor);
        }

        // GET: Medidor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medidor = await _context.Medidor
                .Include(m => m.CedulaNavigation)
                .FirstOrDefaultAsync(m => m.IdMedidor == id);
            if (medidor == null)
            {
                return NotFound();
            }

            return View(medidor);
        }

        // POST: Medidor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medidor = await _context.Medidor.FindAsync(id);
            _context.Medidor.Remove(medidor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedidorExists(int id)
        {
            return _context.Medidor.Any(e => e.IdMedidor == id);
        }
    }
}
