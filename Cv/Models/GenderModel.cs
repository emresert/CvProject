using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cv.Models
{
    public class GenderModel
    {
      
        public int GenderID { get; set; }
        public string Gender { get; set; }

       
        public virtual ICollection<tbl_Userinfo> tbl_Userinfo { get; set; }
    }
}