using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Wizard.Models
{
    public partial class Tarjeta
    {
        public Tarjeta()
        {
            Comprobante = new HashSet<Comprobante>();
        }

        public string NumeroTarjeta { get; set; }
        public string Nombre { get; set; }
        public int Cvv { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int IdMarca { get; set; }
        public string Cedula { get; set; }

        public virtual Usuario CedulaNavigation { get; set; }
        public virtual Marca IdMarcaNavigation { get; set; }
        public virtual ICollection<Comprobante> Comprobante { get; set; }
    }
}
