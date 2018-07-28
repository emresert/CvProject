using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cv.Models
{
	public class ExperiencesModel
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