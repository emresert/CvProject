using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cv.Models
{
    public class MemberModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
    }
}