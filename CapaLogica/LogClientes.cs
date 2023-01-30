using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class LogClientes
    {
        private static readonly LogClientes _instancia = new LogClientes();
        public static LogClientes Instancia
        {
            get { return _instancia; }
        }


        #region MANTENEDORES
        public bool AgregarCliente(EntClientes c)
        {
            return DatClientes.Instancia.AgregarClientes(c);
        }
        public List<EntClientes> ListarCliente()
        {
            return DatClientes.Instancia.ListarClientes();
        }
        public bool EditarCliente(EntClientes Client)
        {
            return DatClientes.Instancia.EditarClientes(Client);
        }
     
        #endregion
    }
}
