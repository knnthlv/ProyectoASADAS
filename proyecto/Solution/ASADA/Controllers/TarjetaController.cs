using DAL.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data = DAL.DO.Objects;
using models = ASADA.Models;
using AutoMapper;

namespace ASADA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarjetaController : ControllerBase
    {
        private readonly ADbContext _context;
        private readonly IMapper _mapper;

        public TarjetaController(ADbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        // GET: api/Tarjeta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Tarjeta>>> GetTarjeta()
        {
            var res = await new BS.Tarjeta(_context).GetAllAsync();
            var mapaux = _mapper.Map<IEnumerable<data.Tarjeta>, IEnumerable<models.Tarjeta>>(res).ToList();


            return mapaux;
        }

        // GET: api/Tarjeta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Tarjeta>> GetTarjeta(string id)
        {
            var tarjeta = await new BS.Tarjeta(_context).GetOneByIdAsyncString(id);
            var mapaux = _mapper.Map<data.Tarjeta, models.Tarjeta>(tarjeta);

            if (tarjeta == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Tarjeta/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarjeta(string id, models.Tarjeta tarjeta)
        {
            if (id != tarjeta.NumeroTarjeta)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<models.Tarjeta, data.Tarjeta>(tarjeta);
                new BS.Tarjeta(_context).Update(mapaux);
            }
            catch (Exception ee)
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
        public async Task<ActionResult<models.Tarjeta>> PostTarjeta(models.Tarjeta tarjeta)
        {
            try
            {
                var mapaux = _mapper.Map<models.Tarjeta, data.Tarjeta>(tarjeta);
                new BS.Tarjeta(_context).Insert(mapaux);
            }
            catch (Exception ee)
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
        public async Task<ActionResult<models.Tarjeta>> DeleteTarjeta(string id)
        {
            var tarjeta = new BS.Tarjeta(_context).GetOneByIdString(id);

            if (tarjeta == null)
            {
                return NotFound();
            }

            new BS.Tarjeta(_context).Delete(tarjeta);
            var mapaux = _mapper.Map<data.Tarjeta, models.Tarjeta>(tarjeta);

            return mapaux;
        }

        private bool TarjetaExists(string id)
        {
            return (new BS.Tarjeta(_context).GetOneByIdString(id) != null);
        }
    }
}
