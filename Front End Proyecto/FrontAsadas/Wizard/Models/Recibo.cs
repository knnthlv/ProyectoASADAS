using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Wizard.Models
{
    public partial class Recibo
    {
        public Recibo()
        {
            Comprobante = new HashSet<Comprobante>();
        }

        public int IdRecibo { get; set; }
        public DateTime FechaCobro { get; set; }
        public int Monto { get; set; }
        public int Consumo { get; set; }
        public int IdMedidor { get; set; }
        public string Cedula { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int IdEstado { get; set; }

        public virtual Usuario CedulaNavigation { get; set; }
        public virtual Estado IdEstadoNavigation { get; set; }
        public virtual Medidor IdMedidorNavigation { get; set; }
        public virtual ICollection<Comprobante> Comprobante { get; set; }
    }
}
