using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDeskBackend.DataBase;

namespace HelpDeskBackend.Backend.Logic.Class
{
   public class ticketNotAsig
    {
        PRUEBA_HELP_DESKEntities db = new PRUEBA_HELP_DESKEntities();
        //*metodo para cargar la data de los ticket que nadie se ha asignado*//
        public dynamic GetData()
        {
            int estadoSinAsig = Convert.ToInt32(Enum.Enum.estadoTicket.sinAsignar);
            var data = db.PR_TICKET.Where(x=> x.ID_STATE==estadoSinAsig).OrderBy(x=> x.ID_TICKET).Select(x => new
            {
                x.ID_TICKET,
                DEPARTAMENTO_PROC=x.PR_USERS1.PR_DEPARTMENTS.DEPARTMENT,
                x.ID_PROBLEM,
                PROBLEM=x.PR_PROBLEM.PROBLEM,
                USER_CREATE=db.PR_USERS.Where(s=> s.ID_USER==x.USER_CREATED).Select(s=>  s.NAME ).FirstOrDefault(),
                x.DESCRIPCION,
                x.CREATED_DATE,
                ESTATE=x.PR_TICKET_STATE.STATE

            }).ToList();

            return data;
        }

        //*metodo para asignar el ticket al usuario que esta logueado en el momento*//
        public dynamic asigTicket(dynamic data) {
            int idTicket = Convert.ToInt32(data.ID_TICKET);
            var asignar = db.PR_TICKET.Where(x => x.ID_TICKET == idTicket).FirstOrDefault();
            asignar.ID_STATE =Convert.ToInt32( Enum.Enum.estadoTicket.enProceso);
            asignar.USER_ASIGNED = data.ID_USER;
            db.SaveChanges();
            return "success";

        }
    }
}
