using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Net;
namespace CapaDatos
{
    public class DatLogin
    {
        private static readonly DatLogin _instance = new DatLogin();
        public static DatLogin Instancia
        {
            get { return _instance; }
        }
        public bool RegistrarUsuario(EntUsuario Usu)
        {
            SqlCommand cmd = null;
            bool creado = false;
            bool registrado;
            string mensaje;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spRegistrarusuario", cn);
                cmd.Parameters.AddWithValue("correo", Usu.Correo);
                cmd.Parameters.AddWithValue("clave", Usu.Clave);
                cmd.Parameters.Add("registrado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;
            
                cn.Open();
            
               
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    registrado = Convert.ToBoolean(cmd.Parameters["Registrado"].Value);
                    mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                    creado = true;
                }
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
