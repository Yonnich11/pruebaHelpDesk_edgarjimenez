using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDeskBackend.DataBase;
using HelpDeskBackend.Backend.Logic.Interfaces;
using HelpDeskBackend.Backend.Logic.Enum;


namespace HelpDeskBackend.Backend.Logic.Class
{
   public class createTicket 
    {
        public dynamic createdTicket(dynamic item)
        {
            var db = new PRUEBA_HELP_DESKEntities1();
            var ticket = new PR_TICKET();
            ticket.ID_STATE =Convert.ToInt32(Enum.Enum.estadoTicket.sinAsignar);
            ticket.CREATED_DATE = DateTime.Now;
            ticket.DESCRIPCION = item.DESCRIPCTION;
            ticket.ID_PROBLEM = item.ID_PROBLEM;
            ticket.USER_CREATED = item.USER_CREATED;
            ticket.ID_DEPARTMENT_ASIGNED = Convert.ToInt32(Enum.Enum.Department.soporte);
            if (item.ADJUNTO != null)
            {
                var adj = new PR_ANEXOS();
                adj.ID_TICKET = ticket.ID_TICKET;
                adj.FILES = "";//
                db.PR_ANEXOS.Add(adj);

            }
            db.PR_TICKET.Add(ticket);
            db.SaveChanges();
            return "succes";
        }
    }
}
