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
    public class DatRegion
    {
        #region singleton
        private static readonly DatRegion UnicaInstancia = new DatRegion();
        public static DatRegion Instancia
        {
            get
            {
                return DatRegion.UnicaInstancia;
            }
        }
        #endregion singleton

        public List<EntRegion> ListarProvincia()
        {
            SqlCommand cmd = null;
            List<EntRegion> lista = new List<EntRegion>();

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarProvincia", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EntRegion ci = new EntRegion();

                    //ci.idProvincia = Convert.ToInt32(dr["idProvincia"]);
                    //ci.desProvincia = dr["desProvincia"].ToString();


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
