//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HelpDeskBackend.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class PR_TICKET_STATE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PR_TICKET_STATE()
        {
            this.PR_TICKET = new HashSet<PR_TICKET>();
        }
    
        public int ID_STATE { get; set; }
        public string STATE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_TICKET> PR_TICKET { get; set; }
    }
}
