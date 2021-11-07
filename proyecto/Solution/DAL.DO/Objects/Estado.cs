using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
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
