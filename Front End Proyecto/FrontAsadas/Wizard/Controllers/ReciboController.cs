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
    public class ReciboController : Controller
    {
        private readonly asadaContext _context;

        public ReciboController(asadaContext context)
        {
            _context = context;
        }

        // GET: Recibo
        public async Task<IActionResult> Index()
        {
            var asadaContext = _context.Recibo.Include(r => r.CedulaNavigation).Include(r => r.IdEstadoNavigation).Include(r => r.IdMedidorNavigation);
            return View(await asadaContext.ToListAsync());
        }

        // GET: Recibo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recibo = await _context.Recibo
                .Include(r => r.CedulaNavigation)
                .Include(r => r.IdEstadoNavigation)
                .Include(r => r.IdMedidorNavigation)
                .FirstOrDefaultAsync(m => m.IdRecibo == id);
            if (recibo == null)
            {
                return NotFound();
            }

            return View(recibo);
        }

        // GET: Recibo/Create
        public IActionResult Create()
        {
            ViewData["Cedula"] = new SelectList(_context.Usuario, "Cedula", "Cedula");
            ViewData["IdEstado"] = new SelectList(_context.Estado, "IdEstado", "Descripcion");
            ViewData["IdMedidor"] = new SelectList(_context.Medidor, "IdMedidor", "Cedula");
            return View();
        }

        // POST: Recibo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRecibo,FechaCobro,Monto,Consumo,IdMedidor,Cedula,FechaVencimiento,IdEstado")] Recibo recibo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recibo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cedula"] = new SelectList(_context.Usuario, "Cedula", "Cedula", recibo.Cedula);
            ViewData["IdEstado"] = new SelectList(_context.Estado, "IdEstado", "Descripcion", recibo.IdEstado);
            ViewData["IdMedidor"] = new SelectList(_context.Medidor, "IdMedidor", "Cedula", recibo.IdMedidor);
            return View(recibo);
        }

        // GET: Recibo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recibo = await _context.Recibo.FindAsync(id);
            if (recibo == null)
            {
                return NotFound();
            }
            ViewData["Cedula"] = new SelectList(_context.Usuario, "Cedula", "Cedula", recibo.Cedula);
            ViewData["IdEstado"] = new SelectList(_context.Estado, "IdEstado", "Descripcion", recibo.IdEstado);
            ViewData["IdMedidor"] = new SelectList(_context.Medidor, "IdMedidor", "Cedula", recibo.IdMedidor);
            return View(recibo);
        }

        // POST: Recibo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRecibo,FechaCobro,Monto,Consumo,IdMedidor,Cedula,FechaVencimiento,IdEstado")] Recibo recibo)
        {
            if (id != recibo.IdRecibo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recibo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReciboExists(recibo.IdRecibo))
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
            ViewData["Cedula"] = new SelectList(_context.Usuario, "Cedula", "Cedula", recibo.Cedula);
            ViewData["IdEstado"] = new SelectList(_context.Estado, "IdEstado", "Descripcion", recibo.IdEstado);
            ViewData["IdMedidor"] = new SelectList(_context.Medidor, "IdMedidor", "Cedula", recibo.IdMedidor);
            return View(recibo);
        }

        // GET: Recibo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recibo = await _context.Recibo
                .Include(r => r.CedulaNavigation)
                .Include(r => r.IdEstadoNavigation)
                .Include(r => r.IdMedidorNavigation)
                .FirstOrDefaultAsync(m => m.IdRecibo == id);
            if (recibo == null)
            {
                return NotFound();
            }

            return View(recibo);
        }

        // POST: Recibo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recibo = await _context.Recibo.FindAsync(id);
            _context.Recibo.Remove(recibo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReciboExists(int id)
        {
            return _context.Recibo.Any(e => e.IdRecibo == id);
        }
    }
}
