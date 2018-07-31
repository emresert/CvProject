using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cv.Models;

namespace Cv.Controllers
{
    public class HomeController : Controller
    {
        CvEntities db = new CvEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult UserToDoList()
        {


            return View();
        }
        public ActionResult ShowAll() {

            CvViewModel vm = new CvViewModel();
           
            vm.EducationInfo = db.tbl_Education.ToList();
            vm.ExperiencesInfo = db.tbl_Experiences.ToList();
            

            return View(vm);
        }
      
        }
    }
