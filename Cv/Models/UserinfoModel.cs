using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cv.Models
{
    public class UserinfoModel
    {
        public int UserInfoID { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public byte[] UserImage { get; set; }
        public Nullable<int> fk_GenderID { get; set; }
        public Nullable<int> fk_UserID { get; set; }

        public virtual tbl_Gender tbl_Gender { get; set; }
        public virtual tbl_Member tbl_Member { get; set; }
    }
}