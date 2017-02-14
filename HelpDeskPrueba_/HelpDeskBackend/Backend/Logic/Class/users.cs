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
       
            PRUEBA_HELP_DESKEntities data = new PRUEBA_HELP_DESKEntities();
            bool isError = false;
            var exist = data.PR_USERS.Where(x => x.USER_NAME == item.USER_NAME).FirstOrDefault();
            if (exist!=null)
            {
             
                return "exist_user";
            }
        
            return "success";

        }

       //*metodo para registrar los usuarios*//
        public dynamic SaveUsers(PR_USERS item)
        {
            PRUEBA_HELP_DESKEntities data = new PRUEBA_HELP_DESKEntities();
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
                    user.ID_ROL = item.ID_ROL;
                    user.ID_DEPARMENT = item.ID_DEPARMENT;
                    data.PR_USERS.Add(user);
                    data.SaveChanges();
                    tran.Commit();
                    return "success";
                }
                catch (Exception EX)
                {
                    tran.Rollback();
                    return "error";
              
                }
          }

           
        }
        public dynamic GetAllUser()
        {
           
            using (var db = new PRUEBA_HELP_DESKEntities()) {
                try
                {
                    var data = db.PR_USERS.Where(x => x.ACTIVE == true).Select(x => new
                    {
                        x.ID_USER,
                        x.NAME,
                        DEPARTMENT = x.PR_DEPARTMENTS.DEPARTMENT,
                        ROL = x.PR_USERS_ROL.ROL
                    }).ToList();
                    return data;
                }
                catch (Exception)
                {

                    throw;
                }
            }
              
        }

        //*metodo para seguir usuarios, el usuario fallowed es el usuario que esta logueado*//
        public dynamic fallowUser(int user_fallowed, int user_fallow)
        {
        
            using (var db = new PRUEBA_HELP_DESKEntities())
            {

                try
                {
                    var exist = db.PR_USER_FOLLOWED.Where(x => x.ID_USER_FALLOW == user_fallow && x.ID_USER_FOLLOWED == user_fallowed).FirstOrDefault();
                    if (exist != null)
                    {
                        return "exist";
                    }

                    PR_USER_FOLLOWED user = new PR_USER_FOLLOWED();
                    user.ID_USER_FALLOW = user_fallow;
                    user.ID_USER_FOLLOWED = user_fallowed;
                    db.PR_USER_FOLLOWED.Add(user);
                    db.SaveChanges();
                    return "success";
                }
                catch (Exception)
                {

                    throw;
                }
            }
          
        }

       
    }
}
