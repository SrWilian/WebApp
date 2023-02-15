using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EntProvincia
    {
        private int idProvincia;
        private String desProvincia;
        //public Boolean estProvincia { get; set; }

        public EntProvincia(){ 
            }
        public EntProvincia(int idProvincia, string desProvincia)
        {
            this.idProvincia = idProvincia;
            this.desProvincia = desProvincia;
          
        }


        public int IdProvincia
        {
            get { return idProvincia; }
            set { idProvincia = value; }
        }

        public string DesProvincia
        {
            get { return desProvincia; }
            set { desProvincia = value; }
        }



    }


}
