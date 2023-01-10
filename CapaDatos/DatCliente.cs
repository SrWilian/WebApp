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
    public class DatCliente
    {
        private static readonly DatCliente _instance = new DatCliente();
        public static DatCliente Instancia
        {
            get { return _instance; }
        }

        public bool AgregarCliente(EntCliente Cli)
        {
            SqlCommand cmd = null;
            bool creado = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spCrearCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@razonSocial", Cli.RazonSocial);
                cmd.Parameters.AddWithValue("@dni", Cli.Dni);
                cmd.Parameters.AddWithValue("@correo", Cli.Correo);
                cmd.Parameters.AddWithValue("@telefono", Cli.Telefono);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
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
        public List<EntCliente> ListarCliente()
        {
            SqlCommand cmd = null;
            List<EntCliente> lista = new List<EntCliente>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EntCliente Cli = new EntCliente
                    {
                        IdCliente = Convert.ToInt32(dr["idCliente"]),
                        RazonSocial = dr["razonsocial"].ToString(),
                        Dni = dr["dni"].ToString(),
                        Correo = dr["correo"].ToString(),
                        Telefono = Convert.ToInt32(dr["telefono"]),
                        direccion = dr["direccion"].ToString()
                    };
                    lista.Add(Cli);
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
            return lista;
        }
    }
}
