using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDeskBackend.DataBase;

namespace HelpDeskBackend.Backend.Logic.Class
{
    public class Informes
    {

        public dynamic getSolicitudesCerradas()
        {
            List<dynamic> data = new List<dynamic>();
       


            using (var db = new PRUEBA_HELP_DESKEntities())
            {
                int cerrado = Convert.ToInt32(Enum.Enum.estadoTicket.Cerrado);
                var ticketClosed = db.PR_TICKET.Where(x => x.ID_STATE == cerrado).Count();
                var ticketOpened = db.PR_TICKET.Count();
                return new
                {
                    closed = new
                    {
                        label = "Cerrados",
                        count = ticketClosed
                    },
                    opened = new
                    {
                        label = "Abiertos",
                        count = ticketOpened
                    }

                };
            }

        }
    }
}
