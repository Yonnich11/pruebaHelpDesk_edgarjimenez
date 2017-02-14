using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HelpDeskBackend.Backend.Logic.Interfaces;
using HelpDeskBackend.Backend.Logic.Utilities;
using HelpDeskBackend.DataBase;



namespace HelpDeskBackend.Backend.Logic.Class
{
    public class login : iloggin
    {
        public dynamic loginUser(  DataBase.PR_USERS data)
        {
            var db = new PRUEBA_HELP_DESKEntities1();

            string password = Encript.EncriptValue(data.PASSWORD);
            var getData = db.PR_USERS.Where(x => x.PASSWORD == password && x.USER_NAME == data.USER_NAME).Select(x => new {
                x.NAME,
                x.ID_USER,
                DEPARTAMENT = x.PR_DEPARTMENTS.DEPARTMENT,
                ROL = x.PR_USERS_ROL.ROL,
                x.ID_DEPARMENT,
                x.ID_ROL,
                x.USER_NAME

            }).FirstOrDefault();
            if (getData == null)
            {
                return "not_success";
            }

            return getData;

        }
    }

      
          
    
}
