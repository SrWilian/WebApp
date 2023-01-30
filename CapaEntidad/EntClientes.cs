using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EntClientes
    {
        private int idCliente;
        private string rucDni;
        private int tipoDoc;
        private string razonSocial;
        private string direccion;
        private string region;
        private string provincia;
        private string distrito;
        private string ubigeo;
        private string telefono;
        private string correo;
        private float record;

        #region constructores
        //constructores
        //==============================================================================================================
        public EntClientes()
        {

        }

        public EntClientes(int idCliente, string rucDni, int tipoDoc, string razonSocial, string direccion, string region,
            string provincia, string distrito, string ubigeo, string telefono, string correo, float record)
        {
            this.IdCliente = idCliente;
            this.RucDni = rucDni;
            this.TipoDoc = tipoDoc;
            this.RazonSocial = razonSocial;
            this.Direccion = direccion;
            this.Region = region;
            this.Provincia = provincia;
            this.Distrito = distrito;
            this.Ubigeo = ubigeo;
            this.Telefono = telefono;
            this.Correo = correo;
            this.Record = record;
        }
        #endregion
        #region get set
        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }

        public string RucDni
        {
            get { return rucDni; }
            set { rucDni = value; }
        }

        public int TipoDoc
        {
            get { return tipoDoc; }
            set { tipoDoc = value; }
        }

        public string RazonSocial
        {
            get { return razonSocial; }
            set { razonSocial = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string Region
        {
            get { return region; }
            set { region = value; }
        }

        public string Provincia
        {
            get { return provincia; }
            set { provincia = value; }
        }

        public string Distrito
        {
            get { return distrito; }
            set { distrito = value; }
        }

        public string Ubigeo
        {
            get { return ubigeo; }
            set { ubigeo = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }

        public float Record
        {
            get { return record; }
            set { record = value; }
        }

        #endregion


    }
}
