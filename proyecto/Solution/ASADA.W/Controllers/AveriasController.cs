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
    public class AveriasController : ControllerBase
    {
        private readonly asadaContext _context;

        public AveriasController(asadaContext context)
        {
            _context = context;
        }

        // GET: api/Averias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Averia>>> GetAveria()
        {
            return await _context.Averia.ToListAsync();
        }

        // GET: api/Averias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Averia>> GetAveria(int id)
        {
            var averia = await _context.Averia.FindAsync(id);

            if (averia == null)
            {
                return NotFound();
            }

            return averia;
        }

        // PUT: api/Averias/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAveria(int id, Averia averia)
        {
            if (id != averia.IdAveria)
            {
                return BadRequest();
            }

            _context.Entry(averia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AveriaExists(id))
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

        // POST: api/Averias
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Averia>> PostAveria(Averia averia)
        {
            _context.Averia.Add(averia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAveria", new { id = averia.IdAveria }, averia);
        }

        // DELETE: api/Averias/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Averia>> DeleteAveria(int id)
        {
            var averia = await _context.Averia.FindAsync(id);
            if (averia == null)
            {
                return NotFound();
            }

            _context.Averia.Remove(averia);
            await _context.SaveChangesAsync();

            return averia;
        }

        private bool AveriaExists(int id)
        {
            return _context.Averia.Any(e => e.IdAveria == id);
        }
    }
}
