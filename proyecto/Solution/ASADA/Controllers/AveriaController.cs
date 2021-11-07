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
    public class AveriaController : ControllerBase
    {
        private readonly ADbContext _context;
        private readonly IMapper _mapper;


        public AveriaController(ADbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        // GET: api/Averias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Averia>>> GetAveria()
        {
            var res = await new BS.Averia(_context).GetAllAsync();
            var mapaux = _mapper.Map<IEnumerable<data.Averia>, IEnumerable<models.Averia>>(res).ToList();


            return mapaux;
        }

        // GET: api/Averias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Averia>> GetAveria(int id)
        {
            var averia = await new BS.Averia(_context).GetOneByIdAsync(id);
            var mapaux = _mapper.Map<data.Averia, models.Averia>(averia);

            if (averia == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Averias/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAveria(int id, models.Averia averia)
        {
            if (id != averia.IdAveria)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<models.Averia, data.Averia>(averia);
                new BS.Averia(_context).Update(mapaux);
            }
            catch (Exception ee)
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
        public async Task<ActionResult<models.Averia>> PostAveria(models.Averia averia)
        {
            var mapaux = _mapper.Map<models.Averia, data.Averia>(averia);
            new BS.Averia(_context).Insert(mapaux);

            return CreatedAtAction("GetAveria", new { id = averia.IdAveria }, averia);
        }

        // DELETE: api/Averias/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Averia>> DeleteAveria(int id)
        {
            var averia = new BS.Averia(_context).GetOneById(id);
            if (averia == null)
            {
                return NotFound();
            }

            new BS.Averia(_context).Delete(averia);
            var mapaux = _mapper.Map<data.Averia, models.Averia>(averia);

            return mapaux;
        }

        private bool AveriaExists(int id)
        {
            return (new BS.Averia(_context).GetOneById(id) != null);
        }
    }
}
