using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
namespace CapaDatos
{
    public class DatProvincia
    {
        #region singleton
        private static readonly DatProvincia UnicaInstancia = new DatProvincia();
        public static DatProvincia Instancia
        {
            get
            {
                return DatProvincia.UnicaInstancia;
            }
        }
        #endregion singleton

        public List<EntProvincia> ListarProvincia()
        {
            SqlCommand cmd = null;
            List<EntProvincia> lista = new List<EntProvincia>();

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarProvincia", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EntProvincia ci = new EntProvincia();

                    ci.idProvincia = Convert.ToInt32(dr["idProvincia"]);
                    ci.desProvincia = dr["desProvincia"].ToString();


                    lista.Add(ci);
                }
            }
            catch (SqlException e)
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
