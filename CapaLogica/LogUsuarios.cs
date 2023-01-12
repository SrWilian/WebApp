using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    internal class LogUsuarios
    {
        private static readonly LogUsuarios _instancia = new LogUsuarios();
        public static LogUsuarios Instancia
        {
            get { return _instancia; }
        }
       /*
        public List<EntUsuarios> ListarUsuarios()
        {
            return DatUsuarios.Instancia.ListarUsuarios();
        }
       */
    }
} 
