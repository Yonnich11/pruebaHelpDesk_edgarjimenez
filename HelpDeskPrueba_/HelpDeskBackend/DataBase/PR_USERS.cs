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
    
    public partial class PR_USERS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PR_USERS()
        {
            this.PR_TICKET = new HashSet<PR_TICKET>();
            this.PR_TICKET1 = new HashSet<PR_TICKET>();
            this.PR_USER_FOLLOWED = new HashSet<PR_USER_FOLLOWED>();
            this.PR_USER_FOLLOWED1 = new HashSet<PR_USER_FOLLOWED>();
        }
    
        public int ID_USER { get; set; }
        public string NAME { get; set; }
        public Nullable<int> ID_ROL { get; set; }
        public string USER_NAME { get; set; }
        public string PASSWORD { get; set; }
        public Nullable<bool> ACTIVE { get; set; }
        public Nullable<int> ID_DEPARMENT { get; set; }
        public Nullable<System.DateTime> CREATED_DATE { get; set; }
    
        public virtual PR_DEPARTMENTS PR_DEPARTMENTS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_TICKET> PR_TICKET { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_TICKET> PR_TICKET1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_USER_FOLLOWED> PR_USER_FOLLOWED { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PR_USER_FOLLOWED> PR_USER_FOLLOWED1 { get; set; }
        public virtual PR_USERS_ROL PR_USERS_ROL { get; set; }
    }
}
