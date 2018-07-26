using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cv.Models;

namespace Cv.Controllers
{
    public class EducationController : Controller
    {
        CvEntities db = new CvEntities();
        // GET: Education
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Show()
        {
            var dataSet = Session["Users"] as tbl_Member;
            var educations = db.tbl_Education.ToList();
            var educationList = new List<EducationModel>();
            foreach (var education in educations) {
                if (education.fk_UserID == dataSet.UserID) {
                    var eModel = new EducationModel
                    {
                        SchoolName = education.SchoolName,
                        Department = education.Department,
                        StartDate = education.StartDate,
                        FinishDate = education.FinishDate,
                        fk_StatusID = education.fk_StatusID
                    };
                    educationList.Add(eModel);
                }

            }
            
            return View(educationList);
        }

        public ActionResult Create()
        {
            ViewBag.fk_StatusID = new SelectList(db.tbl_Status, "StatusID", "StatusName");
            return View();
        }
        [HttpPost]

        public ActionResult Create(EducationModel eModel)
        {
            var dataSet = Session["Users"] as tbl_Member;
            var member = db.tbl_Education.FirstOrDefault(m => m.fk_UserID == dataSet.UserID);
            var education = new tbl_Education();
            education.EducationID = eModel.EducationID;
            education.SchoolName = eModel.SchoolName;
            education.Department = eModel.Department;
            education.StartDate = eModel.StartDate;
            education.FinishDate = eModel.FinishDate;
            education.fk_UserID = dataSet.UserID;
            education.fk_StatusID = eModel.fk_StatusID;
            db.tbl_Education.Add(education);
            db.SaveChanges();
            ViewBag.fk_StatusID = new SelectList(db.tbl_Status, "StatusID", "StatusName", eModel.fk_StatusID);
            return RedirectToAction("Show","Education");


        }
    }

}
