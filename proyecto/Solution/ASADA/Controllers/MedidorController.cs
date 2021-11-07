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
    public class MedidorController : ControllerBase
    {
        private readonly ADbContext _context;
        private readonly IMapper _mapper;


        public MedidorController(ADbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        // GET: api/Medidor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Medidor>>> GetMedidor()
        {
            var res = await new BS.Medidor(_context).GetAllAsync();
            var mapaux = _mapper.Map<IEnumerable<data.Medidor>, IEnumerable<models.Medidor>>(res).ToList();


            return mapaux;
        }

        // GET: api/Medidor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Medidor>> GetMedidor(int id)
        {
            var medidor = await new BS.Medidor(_context).GetOneByIdAsync(id);
            var mapaux = _mapper.Map<data.Medidor, models.Medidor>(medidor);

            if (medidor == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Medidor/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedidor(int id, models.Medidor medidor)
        {
            if (id != medidor.IdMedidor)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<models.Medidor, data.Medidor>(medidor);
                new BS.Medidor(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!MedidorExists(id))
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

        // POST: api/Medidor
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Medidor>> PostMedidor(models.Medidor medidor)
        {
            var mapaux = _mapper.Map<models.Medidor, data.Medidor>(medidor);
            new BS.Medidor(_context).Insert(mapaux);

            return CreatedAtAction("GetMedidor", new { id = medidor.IdMedidor }, medidor);
        }

        // DELETE: api/Medidor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Medidor>> DeleteMedidor(int id)
        {
            var medidor = new BS.Medidor(_context).GetOneById(id);
            if (medidor == null)
            {
                return NotFound();
            }

            new BS.Medidor(_context).Delete(medidor);
            var mapaux = _mapper.Map<data.Medidor, models.Medidor>(medidor);


            return mapaux;
        }

        private bool MedidorExists(int id)
        {
            return (new BS.Medidor(_context).GetOneById(id) != null);
        }
    }
}
