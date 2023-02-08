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
    public class DatClientes
    {
        private static readonly DatClientes _instance = new DatClientes();
        public static DatClientes Instancia
        {
            get { return _instance; }
        }


        public bool AgregarClientes(EntClientes Client)
        {
            SqlCommand cmd = null;
            bool creado = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("RegistrarClientes", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@rucDni", Client.RucDni);
                cmd.Parameters.AddWithValue("@tipoDoc", Client.TipoDoc.ToString());
                cmd.Parameters.AddWithValue("@razonSocial", Client.RazonSocial);
                cmd.Parameters.AddWithValue("@direccion", Client.Direccion);
                cmd.Parameters.AddWithValue("@region", Client.Region);
                cmd.Parameters.AddWithValue("@provincia", Client.IdProvincia);
                cmd.Parameters.AddWithValue("@distrito", Client.Distrito);
                cmd.Parameters.AddWithValue("@ubigeo", Client.Ubigeo);
                cmd.Parameters.AddWithValue("@telefono", Client.Telefono);
                cmd.Parameters.AddWithValue("@correo", Client.Correo);
                cmd.Parameters.AddWithValue("@record", 0);

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
        public List<EntClientes> ListarClientes()
        {

            SqlCommand cmd = null;
            List<EntClientes> lista = new List<EntClientes>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("ListarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EntProvincia Prov = new EntProvincia();
                    Prov.idProvincia=  Convert.ToInt32(dr["IdProvincia"]);
                    Prov.desProvincia = dr["desProvincia"].ToString();
                    EntClientes Client = new EntClientes

                    {

                        IdCliente = Convert.ToInt32(dr["idCliente"]),
                        RucDni = dr["RucDni"].ToString(),
                        TipoDoc = Convert.ToInt32(dr["TipoDoc"]),
                        RazonSocial = dr["RazonSocial"].ToString(),
                        Direccion = dr["Direccion"].ToString(),
                        Region = dr["Region"].ToString(),
                        IdProvincia =Prov,
                    
                        Distrito = dr["Distrito"].ToString(),
                        Ubigeo = dr["Ubigeo"].ToString(),
                        Telefono = dr["Telefono"].ToString(),
                        Correo = dr["correo"].ToString(),
                        Record = Convert.ToInt32(dr["Record"]),

                    };
                    lista.Add(Client);
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


        public bool EditarClientes(EntClientes Client)
        {
            SqlCommand cmd = null;
            bool actualiza = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("EditarClientes", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@rucDni", Client.RucDni);
                cmd.Parameters.AddWithValue("@tipoDoc", Client.TipoDoc.ToString());
                cmd.Parameters.AddWithValue("@razonSocial", Client.RazonSocial);
                cmd.Parameters.AddWithValue("@direccion", Client.Direccion);
                cmd.Parameters.AddWithValue("@region", Client.Region);
                cmd.Parameters.AddWithValue("@provincia", Client.IdProvincia.idProvincia);
                cmd.Parameters.AddWithValue("@distrito", Client.Distrito);
                cmd.Parameters.AddWithValue("@ubigeo", Client.Ubigeo);
                cmd.Parameters.AddWithValue("@telefono", Client.Telefono);
                cmd.Parameters.AddWithValue("@correo", Client.Correo);
                cmd.Parameters.AddWithValue("@record", Client.Record.ToString());
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
    }
}
