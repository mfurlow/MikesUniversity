using MikesUniversity.Models;
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
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(StudentModel s)
        {
            if (UniversityConnection.LoginCheck(s.Email, s.Pword) == true)
            {
                ViewBag.email = s.Email;
                ViewBag.pword = s.Pword;

                return RedirectToAction("MainPage","Home");//placeholder
            }
            else
        
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
        public ActionResult ViewSchedule(StudentModel m)
        {
            UniversityConnection.ViewSchedule(m.Studentid);
            return View();
        }

        
    }
}