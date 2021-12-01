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
    public class AveriaController : Controller
    {
        private readonly asadaContext _context;

        public AveriaController(asadaContext context)
        {
            _context = context;
        }

        // GET: Averia
        public async Task<IActionResult> Index()
        {
            var asadaContext = _context.Averia.Include(a => a.IdEstadoNavigation);
            return View(await asadaContext.ToListAsync());
        }

        // GET: Averia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var averia = await _context.Averia
                .Include(a => a.IdEstadoNavigation)
                .FirstOrDefaultAsync(m => m.IdAveria == id);
            if (averia == null)
            {
                return NotFound();
            }

            return View(averia);
        }

        // GET: Averia/Create
        public IActionResult Create()
        {
            ViewData["IdEstado"] = new SelectList(_context.Estado, "IdEstado", "Descripcion");
            return View();
        }

        // POST: Averia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAveria,Descripcion,Direccion,FechaInicio,FechaFin,IdEstado")] Averia averia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(averia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstado"] = new SelectList(_context.Estado, "IdEstado", "Descripcion", averia.IdEstado);
            return View(averia);
        }

        // GET: Averia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var averia = await _context.Averia.FindAsync(id);
            if (averia == null)
            {
                return NotFound();
            }
            ViewData["IdEstado"] = new SelectList(_context.Estado, "IdEstado", "Descripcion", averia.IdEstado);
            return View(averia);
        }

        // POST: Averia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAveria,Descripcion,Direccion,FechaInicio,FechaFin,IdEstado")] Averia averia)
        {
            if (id != averia.IdAveria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(averia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AveriaExists(averia.IdAveria))
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
            ViewData["IdEstado"] = new SelectList(_context.Estado, "IdEstado", "Descripcion", averia.IdEstado);
            return View(averia);
        }

        // GET: Averia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var averia = await _context.Averia
                .Include(a => a.IdEstadoNavigation)
                .FirstOrDefaultAsync(m => m.IdAveria == id);
            if (averia == null)
            {
                return NotFound();
            }

            return View(averia);
        }

        // POST: Averia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var averia = await _context.Averia.FindAsync(id);
            _context.Averia.Remove(averia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AveriaExists(int id)
        {
            return _context.Averia.Any(e => e.IdAveria == id);
        }
    }
}
