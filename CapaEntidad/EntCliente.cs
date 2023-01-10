using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EntCliente
    {
        private int idCliente;
        public string razonSocial;
        private string dni;
        private string correo;
        private int telefono;
        public string direccion;

        #region Constructores
        public EntCliente()
        {
        }

        public EntCliente(int idCliente, string razonSocial, string dni, string correo, int telefono)
        {
            this.idCliente = idCliente;
            this.razonSocial = razonSocial;
            this.dni = dni;
            this.correo = correo;
            this.telefono = telefono;
        }
        #endregion Constructores

        #region Get and Set
        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }

        public string RazonSocial
        {
            get { return razonSocial; }
            set { razonSocial = value; }
        }
        public string Dni
        {
            get { return dni; }
            set { dni = value; }

        }
        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }
        public int Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        #endregion Get and Set
    }
}
