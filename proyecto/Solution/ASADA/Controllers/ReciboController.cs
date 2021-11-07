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
    public class ReciboController : ControllerBase
    {
        private readonly ADbContext _context;
        private readonly IMapper _mapper;


        public ReciboController(ADbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        // GET: api/Recibo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Recibo>>> GetRecibo()
        {
            var res = await new BS.Recibo(_context).GetAllAsync();
            var mapaux = _mapper.Map<IEnumerable<data.Recibo>, IEnumerable<models.Recibo>>(res).ToList();


            return mapaux;
        }

        // GET: api/Recibo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Recibo>> GetRecibo(int id)
        {
            var recibo = await new BS.Recibo(_context).GetOneByIdAsync(id);
            var mapaux = _mapper.Map<data.Recibo, models.Recibo>(recibo);

            if (recibo == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Recibo/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecibo(int id, models.Recibo recibo)
        {
            if (id != recibo.IdRecibo)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<models.Recibo, data.Recibo>(recibo);
                new BS.Recibo(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!ReciboExists(id))
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

        // POST: api/Recibo
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Recibo>> PostRecibo(models.Recibo recibo)
        {
            var mapaux = _mapper.Map<models.Recibo, data.Recibo>(recibo);
            new BS.Recibo(_context).Insert(mapaux);

            return CreatedAtAction("GetRecibo", new { id = recibo.IdRecibo }, recibo);
        }

        // DELETE: api/Recibo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Recibo>> DeleteRecibo(int id)
        {
            var recibo = new BS.Recibo(_context).GetOneById(id);

            if (recibo == null)
            {
                return NotFound();
            }

            new BS.Recibo(_context).Delete(recibo);
            var mapaux = _mapper.Map<data.Recibo, models.Recibo>(recibo);


            return mapaux;
        }

        private bool ReciboExists(int id)
        {
            return (new BS.Recibo(_context).GetOneById(id) != null);
        }
    }
}
