using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsadasFront.API.Models
{
    public class Estado
    {
        public int IdEstado { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(10)]
        public string Descripcion { get; set; }

    }
}
