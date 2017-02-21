using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityReg;

namespace MikesUniversity.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(Student m)
        {
            return View();
        }
        public ActionResult MainPage()
        {
            return View();
        }

        public ActionResult AddCourse()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(Student d)
        {
            if (ModelState.IsValid)
            {
              UniversityConnection.GetDisconnectedResults(UniversityConnection.GetConnectionString() , UniversityConnection.AddStudent(d));
                return View("AddStudent");
            }
            return View();
        }
        public ActionResult ViewSchedule()
        {
            return View();
        }

        
    }
}