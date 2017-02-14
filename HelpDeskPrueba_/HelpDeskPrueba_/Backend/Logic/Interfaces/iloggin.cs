using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDeskBackend.DataBase;
namespace HelpDeskBackend.Backend.Logic.Interfaces
{
   public interface iloggin
    {
        dynamic loginUser(PR_USERS data);

    }
}
