using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ASADA.W.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Averia = new HashSet<Averia>();
            Recibo = new HashSet<Recibo>();
        }

        public int IdEstado { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Averia> Averia { get; set; }
        public virtual ICollection<Recibo> Recibo { get; set; }
    }
}
