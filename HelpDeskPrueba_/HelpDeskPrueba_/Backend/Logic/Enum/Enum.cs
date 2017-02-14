using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskBackend.Backend.Logic.Enum
{
  public  class Enum
    {
        public enum estadoTicket {
            sinAsignar=1,
            enProceso=2,
            Cerrado=3,
            Cancelado=4
        }

        public enum Department {
            Digitacion=1,
            Almacen=2,
            Informatica=3,
            Desarrollo=4,
            soporte=5
        }
        public enum Roles {
soporte=1,
desarrollo=2,
roles_otros=3
        }
    }
}
