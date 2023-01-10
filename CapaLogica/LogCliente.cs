using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class LogCliente
    {
        private static readonly LogCliente _instancia = new LogCliente();
        public static LogCliente Instancia
        {
            get { return _instancia; }
        }
        #region MANTENEDORES
        public bool AgregarCliente(EntCliente c)
        {
            return DatCliente.Instancia.AgregarCliente(c);
        }
        public List<EntCliente> ListarCliente()
        {
            return DatCliente.Instancia.ListarCliente();
        }
        # endregion MANTENEDORES
    }
}
