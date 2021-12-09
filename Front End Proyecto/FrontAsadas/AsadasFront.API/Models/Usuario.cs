using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsadasFront.API.Models
{
    public class Usuario
    {
        public Usuario()
        {
            //Comprobante = new HashSet<Comprobante>();
            //Medidor = new HashSet<Medidor>();
            //Recibo = new HashSet<Recibo>();
            //Tarjeta = new HashSet<Tarjeta>();
        }

        [Required(ErrorMessage = "Escriba su cédula.")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "Escriba su nombre.")]
        [RegularExpression("[a-zA-Z]{2,254}", ErrorMessage = "Formato inválido, solo se pueden ingresar caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Escriba su apellido.")]
        [RegularExpression("[a-zA-Z]{2,254}", ErrorMessage = "Formato inválido, solo se pueden ingresar caracteres.")]
        public string PrimerApellido { get; set; }

        [Required(ErrorMessage = "Escriba su apellido.")]
        [RegularExpression("[a-zA-Z]{2,254}", ErrorMessage = "Formato inválido, solo se pueden ingresar caracteres.")]
        public string SegundoApellido { get; set; }

        [Required(ErrorMessage = "Escriba su correo.")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Digite un correo válido")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "Escriba su contraseña.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Escriba su teléfono.")]
        [RegularExpression("^[0-9]*", ErrorMessage = "Formato inválido, solo puede digitar números")]
        public string Telefono { get; set; }

        public int IdUsuario { get; set; }

        public virtual TipoUsuario IdUsuarioNavigation { get; set; }
        //public virtual ICollection<Comprobante> Comprobante { get; set; }
        //public virtual ICollection<Medidor> Medidor { get; set; }
        //public virtual ICollection<Recibo> Recibo { get; set; }
        //public virtual ICollection<Tarjeta> Tarjeta { get; set; }
    }
}
