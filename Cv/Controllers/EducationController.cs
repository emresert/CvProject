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
                        EducationID=education.EducationID,
                        SchoolName = education.SchoolName,
                        Department = education.Department,
                        StartDate = education.StartDate,
                        FinishDate = education.FinishDate,
                        fk_StatusID = education.fk_StatusID,
                        fk_UserID=education.fk_UserID       
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
        public ActionResult Edit(int id) {
            var education = db.tbl_Education.FirstOrDefault(e => e.EducationID == id);
            var change = new EducationModel();
            change.SchoolName = education.SchoolName;
            change.Department = education.Department;
            change.StartDate = education.StartDate;
            change.FinishDate = education.FinishDate;
            change.fk_StatusID = education.fk_StatusID;
            ViewBag.fk_StatusID = new SelectList(db.tbl_Status, "StatusID", "StatusName", education.fk_StatusID);
            return View(change);
        }
        [HttpPost]
        public ActionResult Edit(int id ,EducationModel edModel) {
            var education = db.tbl_Education.FirstOrDefault(e => e.EducationID == id);
            education.SchoolName = edModel.SchoolName;
            education.Department = edModel.Department;
            education.StartDate = edModel.StartDate;
            education.FinishDate = edModel.FinishDate;
            education.fk_StatusID = edModel.fk_StatusID;
            db.SaveChanges();
            return RedirectToAction("Show");
        }
        public ActionResult Details(int id)
        {
            var education = db.tbl_Education.FirstOrDefault(e => e.EducationID == id);
            var change = new EducationModel();
            change.EducationID = education.EducationID;
            change.SchoolName = education.SchoolName;
            change.Department = education.Department;
            change.StartDate = education.StartDate;
            change.FinishDate = education.FinishDate;
            switch (education.fk_StatusID)
            {
                case 1:
                    ViewBag.Status = "Primary";
                    break;
                case 2:
                    ViewBag.Status = "High School";
                    break;
                case 3:
                    ViewBag.Status = "Asociate";
                    break;
                case 4:
                    ViewBag.Status = "Undergrade";
                    break;
                case 5:
                    ViewBag.Status = "Master";
                    break;
                case 6:
                    ViewBag.Status = "PostGrade";
                    break;
                default:
                    ViewBag.Status = "Not Select";
                    break;
            }
            return View(change);
        }
        public ActionResult Delete(int id) {
        var education = db.tbl_Education.FirstOrDefault(e => e.EducationID == id);
            db.tbl_Education.Remove(education);
            db.SaveChanges();
            return RedirectToAction("Show");
        }
    }

}
