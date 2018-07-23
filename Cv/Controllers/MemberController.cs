using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using System.Data;
using Cv.Models;

namespace Cv.Controllers
{
    public class MemberController : Controller
    {
        private CvEntities db = new CvEntities(); 
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login( MemberModel Model)
        {
            var member = db.tbl_Member.FirstOrDefault(x => x.UserEmail == Model.UserEmail && x.UserPassword == Model.UserPassword);
            if (member != null) {
                /*ıd hariç hepsi 
                  Model.UserName=member.UserName*/
                Session["Users"] = member;
                return RedirectToAction("UserToDoList", "Home");
            }
            ViewBag.Error = "Wrong E-mail or Password!";
            return View();
        }

        public ActionResult Logout(MemberModel Model)
        {
            Session["Users"] = null;
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Create(){

           return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserName,UserSurname,UserPassword,UserEmail")] MemberModel MemberModel)
        {
            if (ModelState.IsValid) {
            var member = new tbl_Member();
            member.UserName = MemberModel.UserName;
            member.UserSurname = MemberModel.UserSurname;
            member.UserPassword = MemberModel.UserPassword;
            member.UserEmail = MemberModel.UserEmail;
            db.tbl_Member.Add(member);
            db.SaveChanges();
            return RedirectToAction("Index");
            }
            return View(MemberModel);
        }
 
        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}