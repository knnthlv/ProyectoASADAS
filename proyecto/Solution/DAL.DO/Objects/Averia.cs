using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
{
    public partial class Averia
    {
        public int IdAveria { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int IdEstado { get; set; }

        public virtual Estado IdEstadoNavigation { get; set; }
    }
}
