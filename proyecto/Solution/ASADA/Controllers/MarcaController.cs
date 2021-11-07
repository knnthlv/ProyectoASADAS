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
    public class MarcaController : ControllerBase
    {
        private readonly ADbContext _context;
        private readonly IMapper _mapper;


        public MarcaController(ADbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        // GET: api/Marcas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Marca>>> GetMarca()
        {
            var res = new BS.Marca(_context).GetAll();
            var mapaux = _mapper.Map<IEnumerable<data.Marca>, IEnumerable<models.Marca>>(res).ToList();

            return mapaux;
        }

        // GET: api/Marcas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Marca>> GetMarca(int id)
        {
            var marca = new BS.Marca(_context).GetOneById(id);
            var mapaux = _mapper.Map<data.Marca, models.Marca>(marca);

            if (marca == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Marcas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarca(int id, models.Marca marca)
        {
            if (id != marca.IdMarca)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<models.Marca, data.Marca>(marca);
                new BS.Marca(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!MarcaExists(id))
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

        // POST: api/Marcas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Marca>> PostMarca(models.Marca marca)
        {
            var mapaux = _mapper.Map<models.Marca, data.Marca>(marca);
            new BS.Marca(_context).Insert(mapaux);

            return CreatedAtAction("GetMarca", new { id = marca.IdMarca }, marca);
        }

        // DELETE: api/Marcas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Marca>> DeleteMarca(int id)
        {
            var marca = new BS.Marca(_context).GetOneById(id);
            if (marca == null)
            {
                return NotFound();
            }

            new BS.Marca(_context).Delete(marca);
            var mapaux = _mapper.Map<data.Marca, models.Marca>(marca);

            return mapaux;
        }

        private bool MarcaExists(int id)
        {
            return (new BS.Marca(_context).GetOneById(id) != null);
        }
    }
}
