//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cv.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Experiences
    {
        public int ExpID { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> FinishDate { get; set; }
        public Nullable<int> fk_UserID { get; set; }
    
        public virtual tbl_Member tbl_Member { get; set; }
    }
}
