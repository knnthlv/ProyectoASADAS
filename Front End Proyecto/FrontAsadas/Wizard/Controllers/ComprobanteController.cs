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
    public class ComprobanteController : Controller
    {
        private readonly asadaContext _context;

        public ComprobanteController(asadaContext context)
        {
            _context = context;
        }

        // GET: Comprobante
        public async Task<IActionResult> Index()
        {
            var asadaContext = _context.Comprobante.Include(c => c.CedulaNavigation).Include(c => c.IdReciboNavigation).Include(c => c.NumeroTarjetaNavigation);
            return View(await asadaContext.ToListAsync());
        }

        // GET: Comprobante/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comprobante = await _context.Comprobante
                .Include(c => c.CedulaNavigation)
                .Include(c => c.IdReciboNavigation)
                .Include(c => c.NumeroTarjetaNavigation)
                .FirstOrDefaultAsync(m => m.IdComprobante == id);
            if (comprobante == null)
            {
                return NotFound();
            }

            return View(comprobante);
        }

        // GET: Comprobante/Create
        public IActionResult Create()
        {
            ViewData["Cedula"] = new SelectList(_context.Usuario, "Cedula", "Cedula");
            ViewData["IdRecibo"] = new SelectList(_context.Recibo, "IdRecibo", "Cedula");
            ViewData["NumeroTarjeta"] = new SelectList(_context.Tarjeta, "NumeroTarjeta", "NumeroTarjeta");
            return View();
        }

        // POST: Comprobante/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdComprobante,Cedula,IdRecibo,NumeroTarjeta")] Comprobante comprobante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comprobante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cedula"] = new SelectList(_context.Usuario, "Cedula", "Cedula", comprobante.Cedula);
            ViewData["IdRecibo"] = new SelectList(_context.Recibo, "IdRecibo", "Cedula", comprobante.IdRecibo);
            ViewData["NumeroTarjeta"] = new SelectList(_context.Tarjeta, "NumeroTarjeta", "NumeroTarjeta", comprobante.NumeroTarjeta);
            return View(comprobante);
        }

        // GET: Comprobante/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comprobante = await _context.Comprobante.FindAsync(id);
            if (comprobante == null)
            {
                return NotFound();
            }
            ViewData["Cedula"] = new SelectList(_context.Usuario, "Cedula", "Cedula", comprobante.Cedula);
            ViewData["IdRecibo"] = new SelectList(_context.Recibo, "IdRecibo", "Cedula", comprobante.IdRecibo);
            ViewData["NumeroTarjeta"] = new SelectList(_context.Tarjeta, "NumeroTarjeta", "NumeroTarjeta", comprobante.NumeroTarjeta);
            return View(comprobante);
        }

        // POST: Comprobante/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdComprobante,Cedula,IdRecibo,NumeroTarjeta")] Comprobante comprobante)
        {
            if (id != comprobante.IdComprobante)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comprobante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComprobanteExists(comprobante.IdComprobante))
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
            ViewData["Cedula"] = new SelectList(_context.Usuario, "Cedula", "Cedula", comprobante.Cedula);
            ViewData["IdRecibo"] = new SelectList(_context.Recibo, "IdRecibo", "Cedula", comprobante.IdRecibo);
            ViewData["NumeroTarjeta"] = new SelectList(_context.Tarjeta, "NumeroTarjeta", "NumeroTarjeta", comprobante.NumeroTarjeta);
            return View(comprobante);
        }

        // GET: Comprobante/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comprobante = await _context.Comprobante
                .Include(c => c.CedulaNavigation)
                .Include(c => c.IdReciboNavigation)
                .Include(c => c.NumeroTarjetaNavigation)
                .FirstOrDefaultAsync(m => m.IdComprobante == id);
            if (comprobante == null)
            {
                return NotFound();
            }

            return View(comprobante);
        }

        // POST: Comprobante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comprobante = await _context.Comprobante.FindAsync(id);
            _context.Comprobante.Remove(comprobante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComprobanteExists(int id)
        {
            return _context.Comprobante.Any(e => e.IdComprobante == id);
        }
    }
}
