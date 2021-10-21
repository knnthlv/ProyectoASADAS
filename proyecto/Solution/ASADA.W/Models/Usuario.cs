using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ASADA.W.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Comprobante = new HashSet<Comprobante>();
            Medidor = new HashSet<Medidor>();
            Recibo = new HashSet<Recibo>();
            Tarjeta = new HashSet<Tarjeta>();
        }

        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public string Telefono { get; set; }
        public int IdUsuario { get; set; }

        public virtual TipoUsuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Comprobante> Comprobante { get; set; }
        public virtual ICollection<Medidor> Medidor { get; set; }
        public virtual ICollection<Recibo> Recibo { get; set; }
        public virtual ICollection<Tarjeta> Tarjeta { get; set; }
    }
}
