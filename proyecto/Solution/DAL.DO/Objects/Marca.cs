using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
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
