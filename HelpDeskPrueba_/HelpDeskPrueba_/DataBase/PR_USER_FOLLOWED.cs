//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HelpDeskFrontEnd.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class PR_USER_FOLLOWED
    {
        public int ID_FOLLOW { get; set; }
        public Nullable<int> ID_USER_FOLLOWED { get; set; }
        public Nullable<int> ID_USER_FALLOW { get; set; }
    
        public virtual PR_USERS PR_USERS { get; set; }
        public virtual PR_USERS PR_USERS1 { get; set; }
    }
}
