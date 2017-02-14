using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HelpDeskBackend.Backend.Logic.Class;

namespace HelpDeskFrontEnd.API
{
    [RoutePrefix("informes")]
    public class informesController : ApiController
    {
        Informes inf = new Informes();
        [Route("getTicketCerrados")]
        [HttpGet]
        public IHttpActionResult getTicketCerrados()
        {
            return Ok(inf.getSolicitudesCerradas());
        }



    }
}
