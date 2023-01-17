using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EntUsuario
    {
        private int idUsuario;
        private string correo;
        private string clave;
        private string confirmarClave;
        public EntUsuario()
        {
        }
        public EntUsuario(int idUsuario, string correo, string clave, string confirmarClave)
        {
            this.idUsuario = idUsuario;
            this.correo = correo;
            this.clave = clave;
            this.correo = correo;
            this.confirmarClave = confirmarClave;
        }
        public int IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }

        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }
        public string Clave
        {
            get { return clave; }
            set { clave = value; }

        }
        public string ConfirmarClave
        {
            get { return confirmarClave; }
            set { confirmarClave = value; }
        }
    }
}
