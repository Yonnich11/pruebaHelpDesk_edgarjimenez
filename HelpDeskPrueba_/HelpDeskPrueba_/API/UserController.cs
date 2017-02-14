using System;

using System.Net.Http;
using System.Web.Http;
using HelpDeskBackend.Backend.Logic.Interfaces;
using HelpDeskBackend.Backend.Logic.Class;
using HelpDeskBackend.DataBase;



namespace HelpDeskPrueba_.API
{
    [RoutePrefix("api")]
    
    public class UserController : ApiController
    {
        Iusers user = new users();
        fillSelect fill = new fillSelect();
        login log = new login();
        [HttpPost]
        [Route("SaveUser")]
        public IHttpActionResult saveuser([FromBody] PR_USERS item)
        {
            return Ok(user.SaveUsers(item));
        }
        [HttpGet]
        [Route("GetDataForFillSelect")]
        public IHttpActionResult GetDataForFillSelect()
        {
            return Ok(fill.GetDataFillSelect());
        }

        [HttpPost]
        [Route("Login")]
        public IHttpActionResult Login(PR_USERS item)
        {
            return Ok(log.loginUser(item));
        }
        [HttpGet]
        [Route("GetAllUser")]
        public IHttpActionResult GetAllUser()
        {
            return Ok(user.GetAllUser());
        }
        [HttpGet]
        [Route("fallowUser")]
        public IHttpActionResult fallowUser(int user_fallowed, int user_fallow)
        {
            return Ok(user.fallowUser(user_fallowed,user_fallow));
        }
     
    }
}
