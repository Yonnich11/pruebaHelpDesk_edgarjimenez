using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDeskBackend.DataBase;

namespace HelpDeskBackend.Backend.Logic.Class
{
   public  class myTicket

    {
        PRUEBA_HELP_DESKEntities db = new PRUEBA_HELP_DESKEntities();
        //*metoto para obtener todos los ticket que estan asignados a mi*//
        public dynamic GetMyTicket(int idUser)
        {
            try
            {
                int enproceso = Convert.ToInt32(Enum.Enum.estadoTicket.enProceso);
                var myTicket = db.PR_TICKET.Where(x => x.ID_STATE == enproceso && x.USER_ASIGNED == idUser).Select(x => new
                {
                    x.ID_TICKET,
                    x.ID_PROBLEM,
                    PROBLEM = x.PR_PROBLEM.PROBLEM,
                    USER_CREATE = db.PR_USERS.Where(s => s.ID_USER == x.USER_CREATED).Select(s =>  s.NAME ).FirstOrDefault(),
                    x.DESCRIPCION,
                    x.CREATED_DATE,
                    ESTATE = x.PR_TICKET_STATE.STATE,
                    FILES=db.PR_ANEXOS.Where(p=> p.ID_TICKET==x.ID_TICKET).FirstOrDefault().FILES_NTEXT
                }).ToList();

                if (myTicket != null)
                {
                    return myTicket;
                }
                return "no_data";

            }
            catch (Exception)
            {
                return "error";
            }
        }
        //*metodo para obtener el ticket para cerrarlo, este se utiliza para abrir el modal*//
        public dynamic getForClosed(int idTicket)
        {
            try
            {
                var data = db.PR_TICKET.Where(x => x.ID_TICKET == idTicket).Select(x => new
                {
                    x.ID_TICKET,
                    ESTADO=x.PR_TICKET_STATE.STATE,
                    x.CREATED_DATE,
                    x.USER_CREATED,
                    PROBLEM=x.PR_PROBLEM.PROBLEM,
                    x.DESCRIPCION
                }).FirstOrDefault();
                return data;
            }
            
            catch (Exception)
            {

                throw;
            }
        }
        //*metodo para cerrar los ticket, actualiza la fecha de cerrado a la actual, el comentario, y el estado a cerrado*//
        public dynamic closeTicket(dynamic data)
        {
            try
            {
                int idticket = data.ID_TICKET;
                var close = db.PR_TICKET.Where(x => x.ID_TICKET == idticket).FirstOrDefault();
                close.COMMENTARY = data.COMMENTARY;
                close.ID_STATE = Convert.ToInt32(Enum.Enum.estadoTicket.Cerrado);
                close.CLOSED_DATE = DateTime.Now;
                db.SaveChanges();
                return "success";

            }
            catch (Exception)
            {

                throw;
            }
        }
        //*metodo para obtener los tcket de los usuarios que sigue la persona que esta logueada*//
        public dynamic getMyFallowData(int iduser)
        {
            using (var db = new PRUEBA_HELP_DESKEntities())
            {

                try
                {
                    List<dynamic> datafallow = new List<dynamic>();
                    var data = db.PR_USER_FOLLOWED.Where(x => x.ID_USER_FOLLOWED == iduser).ToList();
                    foreach (var item in data)
                    {
                        var ticket = db.PR_TICKET.Where(x => x.USER_ASIGNED == item.ID_USER_FALLOW).Select(x => new
                        {
                            x.ID_TICKET,
                            NAME_CREATED = db.PR_USERS.Where(a => a.ID_USER == x.USER_CREATED).FirstOrDefault().NAME,
                            NAME_ASIGNED = db.PR_USERS.Where(a => a.ID_USER == x.USER_ASIGNED).FirstOrDefault().NAME,
                            PROBLEM = x.PR_PROBLEM.PROBLEM,
                            x.DESCRIPCION,
                            x.CREATED_DATE,
                            STATE = x.PR_TICKET_STATE.STATE
                        }).ToList();
                        datafallow.Add(ticket);
                    }
                    return datafallow[0];
                }
                catch (Exception)
                {
                    return "error";
                }
            }
        }
    }
}
