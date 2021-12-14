using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsadasFront.API.Models
{
    public class Recibo
    {
        public Recibo()
        {
            //Comprobante = new HashSet<Comprobante>();
        }

        public int IdRecibo { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaCobro { get; set; }
        public int Monto { get; set; }
        public int Consumo { get; set; }
        public int IdMedidor { get; set; }
        public string Cedula { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaVencimiento { get; set; }
        public int IdEstado { get; set; }

        public virtual Usuario CedulaNavigation { get; set; }
        public virtual Estado IdEstadoNavigation { get; set; }
        public virtual Medidor IdMedidorNavigation { get; set; }
        //public virtual ICollection<Comprobante> Comprobante { get; set; }
    }
}
