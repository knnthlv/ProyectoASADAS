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
    public class TipoUsuarioController : ControllerBase
    {
        private readonly ADbContext _context;
        private readonly IMapper _mapper;


        public TipoUsuarioController(ADbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        // GET: api/TipoUsuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.TipoUsuario>>> GetTipoUsuario()
        {
            var res = new BS.TipoUsuario(_context).GetAll();
            var mapaux = _mapper.Map<IEnumerable<data.TipoUsuario>, IEnumerable<models.TipoUsuario>>(res).ToList();

            return mapaux;
        }

        // GET: api/TipoUsuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.TipoUsuario>> GetTipoUsuario(int id)
        {
            var tipoUsuario = new BS.TipoUsuario(_context).GetOneById(id);
            var mapaux = _mapper.Map<data.TipoUsuario, models.TipoUsuario>(tipoUsuario);

            if (tipoUsuario == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/TipoUsuario/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoUsuario(int id, models.TipoUsuario tipoUsuario)
        {
            if (id != tipoUsuario.IdUsuario)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<models.TipoUsuario, data.TipoUsuario>(tipoUsuario);
                new BS.TipoUsuario(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!TipoUsuarioExists(id))
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

        // POST: api/TipoUsuario
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.TipoUsuario>> PostTipoUsuario(models.TipoUsuario tipoUsuario)
        {
            var mapaux = _mapper.Map<models.TipoUsuario, data.TipoUsuario>(tipoUsuario);
            new BS.TipoUsuario(_context).Insert(mapaux);

            return CreatedAtAction("GetTipoUsuario", new { id = tipoUsuario.IdUsuario }, tipoUsuario);
        }

        // DELETE: api/TipoUsuario/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.TipoUsuario>> DeleteTipoUsuario(int id)
        {
            var tipoUsuario = new BS.TipoUsuario(_context).GetOneById(id);
            if (tipoUsuario == null)
            {
                return NotFound();
            }

            new BS.TipoUsuario(_context).Delete(tipoUsuario);
            var mapaux = _mapper.Map<data.TipoUsuario, models.TipoUsuario>(tipoUsuario);

            return mapaux;
        }

        private bool TipoUsuarioExists(int id)
        {
            return (new BS.TipoUsuario(_context).GetOneById(id) != null);
        }
    }
}
