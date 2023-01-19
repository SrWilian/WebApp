using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EntUsuario
    {

        public int IdUsuario { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Correo Electrónico..")]
        public string Correo { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Minimo debes ingresar 5 carateres números y letras"), MaxLength(26, ErrorMessage = "Máximo es permitido 26 caracteres")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Clave { get; set; }

        [Display(Name = "Confirmar Contraseña")]
        [MinLength(5, ErrorMessage = "Minimo debes ingresar 5 carateres números y letras"), MaxLength(26, ErrorMessage = "Máximo es permitido26 caracteres")]
        [Compare("Clave", ErrorMessage = "Las contraseñas no son iguales, Por favor ingrese la misma contraseña")]
        public string ConfirmarClave { get; set; }











        /*



        //[Required(ErrorMessage = "Campo obligatorio")]

        //public int IdUsuario { get; set; }


        //public string Correo { get; set; }

        //[Required, MinLength(5, ErrorMessage = "Minimo 5 carateres"), MaxLength(26, ErrorMessage = "Máximo 26 caracteres")]
        //public string Clave { get; set; }

        //[Required, MinLength(5, ErrorMessage = "Minimo 5 carateres"), MaxLength(26, ErrorMessage = "Máximo 26 caracteres")]
        //public string ConfirmarClave { get; set; }
        //private int idUsuario;
        //private string correo;
        //private string clave;
        //private string confirmarClave;
        //public EntUsuario()
        //{
        //}
        //public EntUsuario(int idUsuario, string correo, string clave, string confirmarClave)
        //{
        //    this.idUsuario = idUsuario;
        //    this.correo = correo;
        //    this.clave = clave;
        //    this.correo = correo;
        //    this.confirmarClave = confirmarClave;
        //}
        //public int IdUsuario
        //{
        //    get { return idUsuario; }
        //    set { idUsuario = value; }
        //}

        //public string Correo
        //{
        //    get { return correo; }
        //    set { correo = value; }
        //}
        //public string Clave
        //{
        //    get { return clave; }
        //    set { clave = value; }

        //}
        //public string ConfirmarClave
        //{
        //    get { return confirmarClave; }
        //    set { confirmarClave = value; }
        //}
    
        */
    }
}
