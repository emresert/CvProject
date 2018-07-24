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
        public ActionResult Show()
        {// find 1 den fazla yani liste şeklinde firsordefault ise sadece  1 kayıt döndürür
            var dataSet = Session["Users"] as tbl_Member;
            MemberModel memberModel = null;
     
            var member = db.tbl_Member.FirstOrDefault(m => m.UserID == dataSet.UserID);
            
                memberModel = new MemberModel
                {
                    UserName = member.UserName,
                    UserSurname = member.UserSurname,
                    UserPassword = member.UserPassword,
                    UserEmail = member.UserEmail
                };
            
            return View(memberModel);

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
            var control = db.tbl_Member.FirstOrDefault(m => m.UserEmail == member.UserEmail);
                if (control != null)
                {
                    ViewBag.Control = "There is an user who has this email";
                    return View();
                }
          
                db.tbl_Member.Add(member);
                db.SaveChanges();
                Session["Users"] = member;
                return RedirectToAction("UserToDoList","Home");
            }
            return View(MemberModel);
        }
        public ActionResult Edit()
        {
            var dataSet = Session["Users"] as tbl_Member;
            var member = db.tbl_Member.FirstOrDefault(m => m.UserID == dataSet.UserID);
            var change = new MemberModel();
            change.UserID = member.UserID;
            change.UserName = member.UserName;
            change.UserSurname = member.UserSurname;
            change.UserPassword = member.UserPassword;
            change.UserEmail = member.UserEmail;
            return View(change);
        }
        [HttpPost]
        public ActionResult Edit(MemberModel mModel)
        {
            var dataSet = Session["Users"] as tbl_Member;
            var member = db.tbl_Member.FirstOrDefault(m => m.UserID == dataSet.UserID);
            member.UserID = dataSet.UserID;
            member.UserName = mModel.UserName;
            member.UserSurname = mModel.UserSurname;
            member.UserPassword = mModel.UserPassword;
            member.UserEmail = dataSet.UserEmail;
            dataSet.UserName = mModel.UserName;
            dataSet.UserSurname = mModel.UserSurname;
            dataSet.UserPassword = mModel.UserPassword;
            db.SaveChanges();
            
           
            return RedirectToAction("Show","Member");
        }
        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}