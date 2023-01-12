using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class LogUsuario
    {
        private static readonly LogUsuario _instancia = new LogUsuario();
        public static LogUsuario Instancia
        {
            get { return _instancia; }
        }
        public bool RegistrarUsuario(EntUsuario Usu)
        {
            return DatLogin.Instancia.RegistrarUsuario(Usu);
        }

        
        public List<EntUsuario> ListarUsuario()
        {
            return DatLogin.Instancia.ListarUsuario();
        }
        
    }
}
