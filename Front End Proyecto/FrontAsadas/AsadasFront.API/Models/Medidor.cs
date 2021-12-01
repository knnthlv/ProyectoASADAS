using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsadasFront.API.Models
{
    public class Medidor
    {
        public Medidor()
        {
            //Recibo = new HashSet<Recibo>();
        }

        public int IdMedidor { get; set; }
        public string Direccion { get; set; }
        public string Cedula { get; set; }

        public virtual Usuario CedulaNavigation { get; set; }
        //public virtual ICollection<Recibo> Recibo { get; set; }
    }
}
