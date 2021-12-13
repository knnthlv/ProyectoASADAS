using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsadasFront.API.Models
{
    public class TipoUsuario
    {
        public int IdUsuario { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(15)]
        public string Descripcion { get; set; }

    }
}
