using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDeskBackend.Backend.Logic.Interfaces;
using HelpDeskBackend.DataBase;
using HelpDeskBackend.Backend.Logic.Utilities;



namespace HelpDeskBackend.Backend.Logic.Class
{
    public class users : Iusers
    {
       

        private dynamic validations(PR_USERS item) {
       
            PRUEBA_HELP_DESKEntities1 data = new PRUEBA_HELP_DESKEntities1();
            bool isError = false;
            var exist = data.PR_USERS.Where(x => x.USER_NAME == item.USER_NAME).FirstOrDefault();
            if (exist!=null)
            {
             
                return "exist_user";
            }
        
            return "success";

        }

       
        public dynamic SaveUsers(PR_USERS item)
        {
            PRUEBA_HELP_DESKEntities1 data = new PRUEBA_HELP_DESKEntities1();
            if (validations(item) != "success")
            {
                return validations(item);
            }

            using (var tran=data.Database.BeginTransaction()) {
                try
                {
                    string pssword =Encript.EncriptValue(item.PASSWORD);
                    var user = new PR_USERS();
                    user.NAME = item.NAME;
                    user.CREATED_DATE = DateTime.Now;
                    user.ACTIVE = true;
                    user.USER_NAME = item.USER_NAME;
                    user.PASSWORD = pssword;
                    user.ID_ROL = item.PR_USERS_ROL.ID_ROL;
                    user.ID_DEPARMENT = item.PR_DEPARTMENTS.ID_DEPARTMENT;
                    data.PR_USERS.Add(user);
                    data.SaveChanges();
                    tran.Commit();
                    return "success";
                }
                catch (Exception)
                {
                    tran.Rollback();
                    return "error";
              
                }
            }

            
        }
    }
}
