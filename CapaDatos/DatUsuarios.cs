using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    
    public class DatUsuarios
    {
        private static readonly DatUsuarios _instance = new DatUsuarios();
        public static DatUsuarios Instancia
        {
            get { return _instance; }
        }

        public bool ListarUsuarios(EntUsuarios Usu)
        {
            EntMensaje Messenger = new EntMensaje();
            SqlCommand cmd = null;
            bool creado = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarusuarios", cn);
                cmd.Parameters.AddWithValue("email", Usu.email);
                cmd.Parameters.AddWithValue("password", Usu.password);
                cmd.Parameters.AddWithValue("idState", Usu.IdState);
                cmd.Parameters.AddWithValue("edad", Usu.edad);

                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                                
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return creado;

        }


        
    }
}
