using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cv.Models
{
    public class EducationModel
    {
        public int EducationID { get; set; }
        public string SchoolName { get; set; }
        public string Department { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> FinishDate { get; set; }
        public Nullable<int> fk_UserID { get; set; }
        public Nullable<int> fk_StatusID { get; set; }

           

        public virtual tbl_Member tbl_Member { get; set; }
        public virtual tbl_Status tbl_Status { get; set; }
    }
}