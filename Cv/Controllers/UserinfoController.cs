using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cv.Models;



namespace Cv.Controllers
{
    public class UserinfoController : Controller
    {
        private CvEntities db = new CvEntities();
        public ActionResult UserToDoList()
        {


            return View();
        }
       
        
        public ActionResult Show()
        {// find 1 den fazla yani liste şeklinde firsordefault ise sadece  1 kayıt döndürür
            var dataSet = Session["Users"] as tbl_Member;
            UserinfoModel userinfoModel = null;
            ViewBag.Name = dataSet.UserName + " " + dataSet.UserSurname;
            var userinfo = db.tbl_Userinfo.FirstOrDefault(p => p.fk_UserID == dataSet.UserID);
            if (userinfo != null) { 
                if (userinfo.fk_GenderID == 1)
                {
                    ViewBag.Gender = "Male";
                }
                else
                {
                    ViewBag.Gender = "Female";
                }

                userinfoModel = new UserinfoModel
                {
                    DateOfBirth = userinfo.DateOfBirth,
                    PhoneNumber = userinfo.PhoneNumber,
                    Adress = userinfo.Adress,
                    UserImage= userinfo.UserImage
                };
            }
           

            
            return View(userinfoModel);

        }
        public ActionResult Create()
        {
            ViewBag.fk_GenderID = new SelectList(db.tbl_Gender, "GenderID", "Gender");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserInfoID,DateOfBirth,PhoneNumber,Adress,UserImage,fk_GenderID")] UserinfoModel Userinfo)
        {
            var dataSet = Session["Users"] as tbl_Member;
         
            var member = db.tbl_Userinfo.FirstOrDefault(m => m.fk_UserID == dataSet.UserID);

                
                if (ModelState.IsValid)
                {
                if (member==null) {
                    var userinfo = new tbl_Userinfo();
                    userinfo.UserInfoID = Userinfo.UserInfoID;
                    userinfo.Adress = Userinfo.Adress;
                    userinfo.DateOfBirth = Userinfo.DateOfBirth;
                    userinfo.PhoneNumber = Userinfo.PhoneNumber;
                    userinfo.UserImage = Userinfo.UserImage;
                    userinfo.fk_GenderID = Userinfo.fk_GenderID;
                    var userData = Session["Users"] as tbl_Member;
                    userinfo.fk_UserID = userData.UserID;
                    db.tbl_Userinfo.Add(userinfo);
                    db.SaveChanges();
                  
                    return RedirectToAction("Show");
                } else {

                    ViewBag.den = "Zaten bir kaydınız var.";
                    return RedirectToAction("UserToDoList","Home");
                }
                    
                }
                ViewBag.fk_GenderID = new SelectList(db.tbl_Gender, "GenderID", "Gender", Userinfo.fk_GenderID);
                return View(Userinfo);
            }

        public ActionResult Edit()
        {
             var dataSet = Session["Users"] as tbl_Member;
             var member = db.tbl_Userinfo.FirstOrDefault(m => m.fk_UserID == dataSet.UserID);
             var change = new UserinfoModel();
             change.UserInfoID = member.UserInfoID;
             change.Adress = member.Adress;
             change.DateOfBirth = member.DateOfBirth;
             change.PhoneNumber = member.PhoneNumber;
             change.UserImage = member.UserImage;
             change.fk_UserID = member.fk_UserID;
             ViewBag.fk_GenderID = new SelectList(db.tbl_Gender, "GenderID", "Gender");
             
             
            return View(change);
   
        }
        [HttpPost]
        public ActionResult Edit(UserinfoModel Userinfo)
        {
            var dataSet = Session["Users"] as tbl_Member;
            var member = db.tbl_Userinfo.FirstOrDefault(m => m.fk_UserID == dataSet.UserID);
            member.Adress = Userinfo.Adress;
            member.DateOfBirth = Userinfo.DateOfBirth;
            member.PhoneNumber = Userinfo.PhoneNumber;
            member.UserImage = Userinfo.UserImage;
            member.fk_GenderID = Userinfo.fk_GenderID;
            db.SaveChanges();
            return RedirectToAction("Show");
        }
        public ActionResult Delete()
        {
            var dataSet = Session["Users"] as tbl_Member;
            var member = db.tbl_Userinfo.FirstOrDefault(m => m.fk_UserID == dataSet.UserID);
            var change = new UserinfoModel();
            change.UserInfoID = member.UserInfoID;
            change.Adress = member.Adress;
            change.DateOfBirth = member.DateOfBirth;
            change.PhoneNumber = member.PhoneNumber;
            change.UserImage = member.UserImage;
            change.fk_UserID = member.fk_UserID;
            db.tbl_Userinfo.Remove(member);
            db.SaveChanges();
            return View("UserToDoList","Home");
        }



    }

}