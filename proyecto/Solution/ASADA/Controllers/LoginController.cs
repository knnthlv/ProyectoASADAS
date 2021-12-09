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
    public class LoginController : ControllerBase
    {

        private readonly ADbContext _context;
        private readonly IMapper _mapper;


        public LoginController(ADbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        // GET: api/Login/5
        [HttpGet("{correo},{password}")]
        public async Task<ActionResult<Models.Usuario>> InicioSesion(string correo, string password)
        {
            var result = await new BS.Usuario(_context).GetOneByIdAsyncStringLogin(correo,password);
            var mapaux = _mapper.Map<data.Usuario, models.Usuario>(result);

            if (result == null)
            {
                return NotFound();
            }

            return mapaux;
        }
    }
}
