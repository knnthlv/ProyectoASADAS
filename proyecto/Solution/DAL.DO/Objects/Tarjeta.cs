using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DO.Objects
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
