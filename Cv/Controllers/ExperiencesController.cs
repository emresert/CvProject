using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cv.Models;

namespace Cv.Controllers
{
    public class ExperiencesController : Controller
    {
        CvEntities db = new CvEntities();
        // GET: Experiences
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Show() {
            var dataSet = Session["Users"] as tbl_Member;
            var exp = db.tbl_Experiences.ToList();
            var expList = new List<ExperiencesModel>();
            foreach (var ex in exp) {
                if (ex.fk_UserID == dataSet.UserID) {
                    var expModel = new ExperiencesModel
                    {
                        ExpID = ex.ExpID,
                        CompanyName = ex.CompanyName,
                        StartDate = ex.StartDate,
                        Position=ex.Position,
                        FinishDate = ex.FinishDate,
                        fk_UserID = dataSet.UserID
                    };
                    expList.Add(expModel);
                }
               
            }
            return View(expList);
        }
        public ActionResult Create()
        {


            return View();
        }
        [HttpPost]
        public ActionResult Create(ExperiencesModel expModel)
        {
            var dataSet = Session["Users"] as tbl_Member;
            var experience = new tbl_Experiences();
            experience.ExpID = expModel.ExpID;
            experience.CompanyName = expModel.CompanyName;
            experience.Position = expModel.Position;
            experience.StartDate = expModel.StartDate;
            experience.FinishDate = expModel.FinishDate;
            experience.fk_UserID = dataSet.UserID;
            db.tbl_Experiences.Add(experience);
            db.SaveChanges();
            return RedirectToAction("Show", "Experiences");


        }
        public ActionResult Edit(int id)
        {
            var exp = db.tbl_Experiences.FirstOrDefault(e => e.ExpID == id);
            var change = new ExperiencesModel();
            change.CompanyName = exp.CompanyName;
            change.Position = exp.Position;
            change.StartDate = exp.StartDate;
            change.FinishDate = exp.FinishDate;
            return View(change);
        }

        [HttpPost]
        public ActionResult Edit(int id, ExperiencesModel expModel)
        {
            var exp = db.tbl_Experiences.FirstOrDefault(e => e.ExpID == id);
            exp.CompanyName = expModel.CompanyName;
            exp.Position = expModel.Position;
            exp.StartDate = expModel.StartDate;
            exp.FinishDate = expModel.FinishDate;
            db.SaveChanges();
            return RedirectToAction("Show");
        }
        public ActionResult Details(int id) {
          
            var expModel = db.tbl_Experiences.FirstOrDefault(e => e.ExpID == id);
            var exp = new ExperiencesModel();
            exp.ExpID = expModel.ExpID;
            exp.CompanyName = expModel.CompanyName;
            exp.Position = expModel.Position;
            exp.StartDate = expModel.StartDate;
            exp.FinishDate = expModel.FinishDate;
            exp.fk_UserID = expModel.fk_UserID;
            return View(exp);
        }
        public ActionResult Delete(int id)
        {
            var exp = db.tbl_Experiences.FirstOrDefault(e => e.ExpID == id);
            db.tbl_Experiences.Remove(exp);
            db.SaveChanges();
            return RedirectToAction("Show");
        }
    }
}