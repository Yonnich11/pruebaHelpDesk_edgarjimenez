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
   public class createTicket :IcreatedTicket    {

        //*metodo para crear los ticket*//
        public dynamic createdTicket(dynamic item)
        {
            var db = new PRUEBA_HELP_DESKEntities();
            var ticket = new PR_TICKET();
            ticket.ID_STATE =Convert.ToInt32(Enum.Enum.estadoTicket.sinAsignar);
            ticket.CREATED_DATE = DateTime.Now;
            ticket.DESCRIPCION = item.DESCRIPCION;
            ticket.ID_PROBLEM = item.ID_PROBLEM;
            ticket.USER_CREATED = item.dataUser.ID_USER;
            ticket.ID_DEPARTMENT_ASIGNED = Convert.ToInt32(Enum.Enum.Department.soporte);
            if (item.FILES != null)
            {
                
                
                var adj = new PR_ANEXOS();
                adj.ID_TICKET = ticket.ID_TICKET;
                adj.FILES_NTEXT = "data:" + item.FILES.filetype + ";base64," + item.FILES.base64;
                db.PR_ANEXOS.Add(adj);

            }
            db.PR_TICKET.Add(ticket);
            db.SaveChanges();
            return "succes";
        }
    }
}
