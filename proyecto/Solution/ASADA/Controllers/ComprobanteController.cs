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
    public class ComprobanteController : ControllerBase
    {
        private readonly ADbContext _context;
        private readonly IMapper _mapper;


        public ComprobanteController(ADbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Comprobantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Comprobante>>> GetComprobante()
        {
            var res = await new BS.Comprobante(_context).GetAllAsync();
            var mapaux = _mapper.Map<IEnumerable<data.Comprobante>, IEnumerable<models.Comprobante>>(res).ToList();


            return mapaux;
        }

        // GET: api/Comprobantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Comprobante>> GetComprobante(int id)
        {
            var comprobante = await new BS.Comprobante(_context).GetOneByIdAsync(id);
            var mapaux = _mapper.Map<data.Comprobante, models.Comprobante>(comprobante);

            if (comprobante == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Comprobantes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComprobante(int id, models.Comprobante comprobante)
        {
            if (id != comprobante.IdComprobante)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<models.Comprobante, data.Comprobante>(comprobante);
                new BS.Comprobante(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!ComprobanteExists(id))
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

        // POST: api/Comprobantes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Comprobante>> PostComprobante(models.Comprobante comprobante)
        {
            var mapaux = _mapper.Map<models.Comprobante, data.Comprobante>(comprobante);
            new BS.Comprobante(_context).Insert(mapaux);

            return CreatedAtAction("GetComprobante", new { id = comprobante.IdComprobante }, comprobante);
        }

        // DELETE: api/Comprobantes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Comprobante>> DeleteComprobante(int id)
        {
            var comprobante = new BS.Comprobante(_context).GetOneById(id);

            if (comprobante == null)
            {
                return NotFound();
            }

            new BS.Comprobante(_context).Delete(comprobante);
            var mapaux = _mapper.Map<data.Comprobante, models.Comprobante>(comprobante);

            return mapaux;
        }

        private bool ComprobanteExists(int id)
        {
            return (new BS.Comprobante(_context).GetOneById(id) != null);
        }
    }
}
