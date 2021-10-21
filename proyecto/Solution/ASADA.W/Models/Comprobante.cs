using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ASADA.W.Models
{
    public partial class Comprobante
    {
        public int IdComprobante { get; set; }
        public string Cedula { get; set; }
        public int IdRecibo { get; set; }
        public string NumeroTarjeta { get; set; }

        public virtual Usuario CedulaNavigation { get; set; }
        public virtual Recibo IdReciboNavigation { get; set; }
        public virtual Tarjeta NumeroTarjetaNavigation { get; set; }
    }
}
