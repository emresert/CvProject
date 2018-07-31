using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cv.Models
{
    public class CvViewModel
    {
       
        public IEnumerable<tbl_Education> EducationInfo { get; set; }
        public IEnumerable<tbl_Experiences> ExperiencesInfo { get; set; }
    }
}