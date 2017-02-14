using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HelpDeskBackend.DataBase;
using HelpDeskBackend.Backend.Logic.Interfaces;
using HelpDeskBackend.Backend.Logic.Class;

namespace HelpDeskPrueba_.API
{
    [RoutePrefix("ticket")]
    
    
    public class TicketController : ApiController
    {
        IcreatedTicket tk = new createTicket();
        ticketNotAsig tknot = new ticketNotAsig();
        myTicket myTicket = new myTicket();
        [HttpPost]
        [Route("SaveTicket")]
        public IHttpActionResult save(dynamic data)
        {
            return Ok(tk.createdTicket(data));
        }

        [HttpGet]
        [Route("GetTicketSinAsig")]
        public IHttpActionResult GetTicket()
        {
            return Ok(tknot.GetData());
        }
        [HttpPost]
        [Route("asignarTicket")]
        public IHttpActionResult asignarTicket(dynamic data)
        {
            return Ok(tknot.asigTicket(data));
        }

        [HttpGet]
        [Route("GetMyTicket")]
        public IHttpActionResult GetMyTicket(int idUser)
        {
            return Ok(myTicket.GetMyTicket(idUser));
        }
        [HttpGet]
        [Route("getForClosed")]
        public IHttpActionResult getForClosed(int idTicket)
        {
            return Ok(myTicket.getForClosed(idTicket));
        }

        [HttpPost]
        [Route("closeTicket")]
        public IHttpActionResult closeTickett(dynamic data)
        {
            return Ok(myTicket.closeTicket(data));
        }
        [HttpGet]
        [Route("GetClosedTicket")]
        public IHttpActionResult GetClosedTicket()
        { var db = new PRUEBA_HELP_DESKEntities();
            var data = db.PR_TICKET.Where(x => x.ID_STATE == 3).Select(x => new
            {
                x.ID_TICKET,
                ESTADO = x.PR_TICKET_STATE.STATE,
                x.CREATED_DATE,
                x.CLOSED_DATE,
                USER_CREATED=db.PR_USERS.Where(p=> p.ID_USER==x.USER_CREATED).Select(p=> p.NAME).FirstOrDefault(),
                PROBLEM = x.PR_PROBLEM.PROBLEM,
                x.DESCRIPCION,
                x.COMMENTARY,
                USER_CLOSED=db.PR_USERS.Where(c=> c.ID_USER==x.USER_ASIGNED).Select(c=> c.NAME).FirstOrDefault()
            }).ToList();
            return Ok(data);
        }
        [HttpGet]
        [Route("getMyFallowData")]
        public IHttpActionResult getMyFallowData(int user_fallowed)
        {
            return Ok(myTicket.getMyFallowData(user_fallowed));
        }
    }
}
