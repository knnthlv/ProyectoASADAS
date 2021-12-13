using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsadasFront.API.Models
{
    public class Marca
    {
        public int IdMarca { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(10)]
        public string Descripcion { get; set; }

    }
}
