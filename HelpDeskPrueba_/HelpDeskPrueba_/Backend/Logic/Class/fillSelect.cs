using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HelpDeskBackend.DataBase;

namespace HelpDeskBackend.Backend.Logic.Class
{
   public class fillSelect
    {
        public dynamic GetDataFillSelect()
        { 
            var db = new PRUEBA_HELP_DESKEntities1();
            return new
            {
                ROLES=db.PR_USERS_ROL.Select(x=> new {x.ID_ROL,x.ROL }).ToList(),
                DEPARTMENT=db.PR_DEPARTMENTS.Select(x=> new { x.ID_DEPARTMENT, x.DEPARTMENT }).ToList(),
                PROBLEM=db.PR_PROBLEM.Select(x=> new { x.ID_PROBLEM,x.PROBLEM}).ToList()
            };
        }
    }
}
