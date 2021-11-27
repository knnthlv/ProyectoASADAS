using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Wizard.Models
{
    public partial class Marca
    {
        public Marca()
        {
            Tarjeta = new HashSet<Tarjeta>();
        }

        public int IdMarca { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Tarjeta> Tarjeta { get; set; }
    }
}
