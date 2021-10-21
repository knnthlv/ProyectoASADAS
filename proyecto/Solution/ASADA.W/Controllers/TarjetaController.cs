using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASADA.W.Models;

namespace ASADA.W.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarjetaController : ControllerBase
    {
        private readonly asadaContext _context;

        public TarjetaController(asadaContext context)
        {
            _context = context;
        }

        // GET: api/Tarjeta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarjeta>>> GetTarjeta()
        {
            return await _context.Tarjeta.ToListAsync();
        }

        // GET: api/Tarjeta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tarjeta>> GetTarjeta(string id)
        {
            var tarjeta = await _context.Tarjeta.FindAsync(id);

            if (tarjeta == null)
            {
                return NotFound();
            }

            return tarjeta;
        }

        // PUT: api/Tarjeta/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarjeta(string id, Tarjeta tarjeta)
        {
            if (id != tarjeta.NumeroTarjeta)
            {
                return BadRequest();
            }

            _context.Entry(tarjeta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarjetaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tarjeta
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Tarjeta>> PostTarjeta(Tarjeta tarjeta)
        {
            _context.Tarjeta.Add(tarjeta);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TarjetaExists(tarjeta.NumeroTarjeta))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTarjeta", new { id = tarjeta.NumeroTarjeta }, tarjeta);
        }

        // DELETE: api/Tarjeta/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tarjeta>> DeleteTarjeta(string id)
        {
            var tarjeta = await _context.Tarjeta.FindAsync(id);
            if (tarjeta == null)
            {
                return NotFound();
            }

            _context.Tarjeta.Remove(tarjeta);
            await _context.SaveChangesAsync();

            return tarjeta;
        }

        private bool TarjetaExists(string id)
        {
            return _context.Tarjeta.Any(e => e.NumeroTarjeta == id);
        }
    }
}
