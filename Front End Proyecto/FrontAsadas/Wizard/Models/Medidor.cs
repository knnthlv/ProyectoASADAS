using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Wizard.Models
{
    public partial class Medidor
    {
        public Medidor()
        {
            Recibo = new HashSet<Recibo>();
        }

        public int IdMedidor { get; set; }
        public string Direccion { get; set; }
        public string Cedula { get; set; }

        public virtual Usuario CedulaNavigation { get; set; }
        public virtual ICollection<Recibo> Recibo { get; set; }
    }
}
