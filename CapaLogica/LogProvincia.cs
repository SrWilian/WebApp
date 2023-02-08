using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class LogProvincia
    {
        #region singleton
        private static readonly LogProvincia UnicaInstancia = new LogProvincia();
        public static LogProvincia Instancia
        {
            get
            {
                return LogProvincia.UnicaInstancia;
            }

        }
        #endregion singleton
        public List<EntProvincia> ListarProvincia()
        {
            try
            {
                List<EntProvincia> lista = DatProvincia.Instancia.ListarProvincia();
                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
