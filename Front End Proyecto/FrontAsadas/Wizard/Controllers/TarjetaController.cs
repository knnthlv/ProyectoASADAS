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
    public class TarjetaController : Controller
    {
        private readonly asadaContext _context;

        public TarjetaController(asadaContext context)
        {
            _context = context;
        }

        // GET: Tarjeta
        public async Task<IActionResult> Index()
        {
            var asadaContext = _context.Tarjeta.Include(t => t.CedulaNavigation).Include(t => t.IdMarcaNavigation);
            return View(await asadaContext.ToListAsync());
        }

        // GET: Tarjeta/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarjeta = await _context.Tarjeta
                .Include(t => t.CedulaNavigation)
                .Include(t => t.IdMarcaNavigation)
                .FirstOrDefaultAsync(m => m.NumeroTarjeta == id);
            if (tarjeta == null)
            {
                return NotFound();
            }

            return View(tarjeta);
        }

        // GET: Tarjeta/Create
        public IActionResult Create()
        {
            ViewData["Cedula"] = new SelectList(_context.Usuario, "Cedula", "Cedula");
            ViewData["IdMarca"] = new SelectList(_context.Marca, "IdMarca", "Descripcion");
            return View();
        }

        // POST: Tarjeta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NumeroTarjeta,Nombre,Cvv,FechaVencimiento,IdMarca,Cedula")] Tarjeta tarjeta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tarjeta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cedula"] = new SelectList(_context.Usuario, "Cedula", "Cedula", tarjeta.Cedula);
            ViewData["IdMarca"] = new SelectList(_context.Marca, "IdMarca", "Descripcion", tarjeta.IdMarca);
            return View(tarjeta);
        }

        // GET: Tarjeta/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarjeta = await _context.Tarjeta.FindAsync(id);
            if (tarjeta == null)
            {
                return NotFound();
            }
            ViewData["Cedula"] = new SelectList(_context.Usuario, "Cedula", "Cedula", tarjeta.Cedula);
            ViewData["IdMarca"] = new SelectList(_context.Marca, "IdMarca", "Descripcion", tarjeta.IdMarca);
            return View(tarjeta);
        }

        // POST: Tarjeta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NumeroTarjeta,Nombre,Cvv,FechaVencimiento,IdMarca,Cedula")] Tarjeta tarjeta)
        {
            if (id != tarjeta.NumeroTarjeta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tarjeta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TarjetaExists(tarjeta.NumeroTarjeta))
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
            ViewData["Cedula"] = new SelectList(_context.Usuario, "Cedula", "Cedula", tarjeta.Cedula);
            ViewData["IdMarca"] = new SelectList(_context.Marca, "IdMarca", "Descripcion", tarjeta.IdMarca);
            return View(tarjeta);
        }

        // GET: Tarjeta/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarjeta = await _context.Tarjeta
                .Include(t => t.CedulaNavigation)
                .Include(t => t.IdMarcaNavigation)
                .FirstOrDefaultAsync(m => m.NumeroTarjeta == id);
            if (tarjeta == null)
            {
                return NotFound();
            }

            return View(tarjeta);
        }

        // POST: Tarjeta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tarjeta = await _context.Tarjeta.FindAsync(id);
            _context.Tarjeta.Remove(tarjeta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TarjetaExists(string id)
        {
            return _context.Tarjeta.Any(e => e.NumeroTarjeta == id);
        }
    }
}
