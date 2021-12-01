using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsadasFront.API.Models
{
    public class Comprobante
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
