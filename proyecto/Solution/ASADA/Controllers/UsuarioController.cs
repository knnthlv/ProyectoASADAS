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
    public class UsuarioController : ControllerBase
    {
        private readonly ADbContext _context;
        private readonly IMapper _mapper;


        public UsuarioController(ADbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        // GET: api/Usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Usuario>>> GetUsuario()
        {
            var res = await new BS.Usuario(_context).GetAllAsync();
            var mapaux = _mapper.Map<IEnumerable<data.Usuario>, IEnumerable<models.Usuario>>(res).ToList();

            return mapaux;

        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Usuario>> GetUsuario(string id)
        {
            var usuario = await new BS.Usuario(_context).GetOneByIdAsyncString(id);
            var mapaux = _mapper.Map<data.Usuario, models.Usuario>(usuario);

            if (usuario == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Usuario/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(string id, models.Usuario usuario)
        {
            if (id != usuario.Cedula)
            {
                return BadRequest();
            }


            try
            {
                var mapaux = _mapper.Map<models.Usuario, data.Usuario>(usuario);
                new BS.Usuario(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!UsuarioExists(id))
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

        // POST: api/Usuario
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Usuario>> PostUsuario(models.Usuario usuario)
        {
            try
            {
                var mapaux = _mapper.Map<models.Usuario, data.Usuario>(usuario);
                new BS.Usuario(_context).Insert(mapaux);
            }
            catch (Exception ee)
            {
                if (UsuarioExists(usuario.Cedula))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUsuario", new { id = usuario.Cedula }, usuario);
        }

        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Usuario>> DeleteUsuario(string id)
        {
            var usuario = new BS.Usuario(_context).GetOneByIdString(id);
            if (usuario == null)
            {
                return NotFound();
            }

            new BS.Usuario(_context).Delete(usuario);
            var mapaux = _mapper.Map<data.Usuario, models.Usuario>(usuario);

            return mapaux;
        }

        private bool UsuarioExists(string id)
        {
            return (new BS.Usuario(_context).GetOneByIdString(id) != null);
        }
    }
}
