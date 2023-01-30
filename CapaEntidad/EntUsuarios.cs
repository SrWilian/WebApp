using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EntUsuarios
    {
        public int Id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int IdState { get; set; }
        public int edad { get; set; }
    }


 //   id int IDENTITY(1,1) primary key NOT NULL,
 //   email varchar(100) NOT NULL,
 //   password varchar(50) NOT NULL,
 //   idState int NOT NULL,
	//edad int
}
