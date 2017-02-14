using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskBackend.Backend.Logic.Interfaces
{
   public interface IcreatedTicket
    {
        dynamic createTicket(dynamic item);
    }
}
