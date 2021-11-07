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
    public class EstadoController : ControllerBase
    {
        private readonly ADbContext _context;
        private readonly IMapper _mapper;

        public EstadoController(ADbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Estado
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Estado>>> GetEstado()
        {
            var res = new BS.Estado(_context).GetAll();
            var mapaux = _mapper.Map<IEnumerable<data.Estado>, IEnumerable<models.Estado>>(res).ToList();

            return mapaux;
        }

        // GET: api/Estado/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Estado>> GetEstado(int id)
        {
            var estado = new BS.Estado(_context).GetOneById(id);
            var mapaux = _mapper.Map<data.Estado, models.Estado>(estado);

            if (estado == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Estado/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstado(int id, models.Estado estado)
        {
            if (id != estado.IdEstado)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<models.Estado, data.Estado>(estado);
                new BS.Estado(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!EstadoExists(id))
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

        // POST: api/Estado
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Estado>> PostEstado(models.Estado estado)
        {
            var mapaux = _mapper.Map<models.Estado, data.Estado>(estado);
            new BS.Estado(_context).Insert(mapaux);

            return CreatedAtAction("GetEstado", new { id = estado.IdEstado }, estado);
        }

        // DELETE: api/Estado/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Estado>> DeleteEstado(int id)
        {
            var estado = new BS.Estado(_context).GetOneById(id);
            if (estado == null)
            {
                return NotFound();
            }

            new BS.Estado(_context).Delete(estado);
            var mapaux = _mapper.Map<data.Estado, models.Estado>(estado);

            return mapaux;
        }

        private bool EstadoExists(int id)
        {
            return (new BS.Estado(_context).GetOneById(id) != null);
        }
    }
}
