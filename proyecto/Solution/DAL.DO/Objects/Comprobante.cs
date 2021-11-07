using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
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
