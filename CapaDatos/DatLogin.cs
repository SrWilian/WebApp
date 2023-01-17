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
            EntMensaje Messenger= new EntMensaje();
            SqlCommand cmd = null;
            bool creado = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spRegistrarusuario", cn);
                cmd.Parameters.AddWithValue("@email", Usu.Correo);
                cmd.Parameters.AddWithValue("@clave", Usu.Clave);
                cmd.Parameters.Add("@registrado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;
            
                cn.Open();
            
               
                int i = cmd.ExecuteNonQuery();
                Messenger.registrado = Convert.ToBoolean(cmd.Parameters["@Registrado"].Value);
                //Messenger.mensaje = cmd.Parameters["@Mensaje"].Value.ToString();
                if(Messenger.registrado == false)
                {
                    i=0;
                }
                creado = Messenger.registrado;
                if (i != 0)
                {
                    
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


        public string Mensaje(string Mnje, EntUsuario Usu)
        {
           // EntUsuario Usu = new EntUsuario();
            EntMensaje Messenger = new EntMensaje();
            SqlCommand cmd = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spRegistrarusuario", cn);
                cmd.Parameters.AddWithValue("@email", Usu.Correo);
                cmd.Parameters.AddWithValue("@clave", Usu.Clave);
                cmd.Parameters.Add("@registrado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();


                int i = cmd.ExecuteNonQuery();
                Messenger.registrado = Convert.ToBoolean(cmd.Parameters["@Registrado"].Value);
                Mnje = cmd.Parameters["@Mensaje"].Value.ToString();                
            }

            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return Mnje;
        }


        public bool LoginUsuario(EntUsuario Usuario)
        {
            EntMensaje Messenger = new EntMensaje();
            SqlCommand cmd = null;
            bool creado = false;
            try
            {

                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spValidarUsuario", cn);
                cmd.Parameters.AddWithValue("@email", Usuario.Correo);
                cmd.Parameters.AddWithValue("@clave", Usuario.Clave);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                Usuario.IdUsuario = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                int i = cmd.ExecuteNonQuery();

                //aqui revisar porque i= -1
                if (i != 0)
                {
                    creado = true;
                    Messenger.mensaje = ("bienvenido " + Usuario.Correo);
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















        //public List<EntCliente> ListarUsuario()
        //{

        //    SqlCommand cmd = null;
        //    List<EntUsuario> lista = new List<EntUsuario>();
        //    try
        //    {
        //        SqlConnection cn = Conexion.Instancia.Conectar();
        //        cmd = new SqlCommand("spListarCliente", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cn.Open();
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            EntCliente Cli = new EntCliente
        //            {
        //                IdCliente = Convert.ToInt32(dr["idCliente"]),
        //                RazonSocial = dr["razonsocial"].ToString(),
        //                Dni = dr["dni"].ToString(),
        //                Correo = dr["correo"].ToString(),
        //                Telefono = Convert.ToInt32(dr["telefono"]),
        //                Direccion = dr["direccion"].ToString(),
        //                EstCliente = Convert.ToBoolean(dr["estCliente"])
        //            }
        //            lista.Add(Cli);
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //    finally
        //    {
        //        cmd.Connection.Close();
        //    }
        //    return lista;
        //}

    }
}
