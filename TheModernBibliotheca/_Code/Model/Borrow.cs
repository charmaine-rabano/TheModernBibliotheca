//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TheModernBibliotheca._Code.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Borrow
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Borrow()
        {
            this.Violations = new HashSet<Violation>();
        }
    
        public int BorrowID { get; set; }
        public int InstanceID { get; set; }
        public int UserID { get; set; }
        public Nullable<System.DateTime> DateBorrowed { get; set; }
        public Nullable<System.DateTime> DateReturned { get; set; }
        public string SiteType { get; set; }
        public string BorrowState { get; set; }
    
        public virtual BookInstance BookInstance { get; set; }
        public virtual LibraryUser LibraryUser { get; set; }
        public virtual Reservation Reservation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Violation> Violations { get; set; }
    }
}
