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

    public partial class Violation
    {
        
        public int BorrowID { get; set; }
        public string ViolationType { get; set; }
        public virtual Borrow Borrow { get; set; }

        public virtual LibraryUser LibraryUser { get; set; }
        public virtual BookInformation BookInformation { get; set; }
    }
}
