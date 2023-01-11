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
                cmd = new SqlCommand("spAgregarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@razonSocial", Cli.RazonSocial);
                cmd.Parameters.AddWithValue("@dni", Cli.Dni);
                cmd.Parameters.AddWithValue("@correo", Cli.Correo);
                cmd.Parameters.AddWithValue("@telefono", Cli.Telefono);
                cmd.Parameters.AddWithValue("@direccion", Cli.Direccion);
                cmd.Parameters.AddWithValue("@estCliente", Cli.EstCliente);
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
                        Direccion = dr["direccion"].ToString(),
                        EstCliente =Convert.ToBoolean(dr["estCliente"])
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

        public EntCliente BuscarNombreCliente(string NombreCliente)
        {
            SqlCommand cmd = null;
            EntCliente Cli = new EntCliente();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spBuscarNombreCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCliente", NombreCliente);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Cli.IdCliente = Convert.ToInt32(dr["idCliente"]);
                    Cli.RazonSocial = dr["razonsocial"].ToString();
                    Cli.Dni = dr["dni"].ToString();
                    Cli.Correo = dr["correo"].ToString();
                    Cli.Telefono = Convert.ToInt32(dr["telefono"]);
                    Cli.Direccion = dr["direccion"].ToString();
                    Cli.EstCliente =Convert.ToBoolean(dr["estCliente"]);
                }
            }
            catch (Exception e)
            { throw e; }
            finally { cmd.Connection.Close(); }
            return Cli;
        }

        public bool EditarCliente(EntCliente Cli)
        {
            SqlCommand cmd = null;
            bool actualiza = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEditarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCliente", Cli.IdCliente);
                cmd.Parameters.AddWithValue("@razonSocial", Cli.RazonSocial);
                cmd.Parameters.AddWithValue("@dni", Cli.Dni);
                cmd.Parameters.AddWithValue("@correo", Cli.Correo);
                cmd.Parameters.AddWithValue("@telefono", Cli.Telefono);
                cmd.Parameters.AddWithValue("@direccion", Cli.Direccion);
                cmd.Parameters.AddWithValue("@estCliente", Cli.EstCliente);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    actualiza = true;
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
            return actualiza;
        }

        //Eliminar - Deshabilitar

        public bool DeshabilitarCliente(int IdCliente)
        {
            SqlCommand cmd = null;
            bool eliminado = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spDeshabilitarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCliente", IdCliente);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    eliminado = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return eliminado;
        }
    }
}
