using MikesUniversity.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityReg;

namespace MikesUniversity.Controllers
{
    
    public class HomeController : Controller
    {
        StudentModel m = new StudentModel();
        
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
                m.FirstName = s.FirstName;
                m.LastName = s.LastName;


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

        public ActionResult ViewCourses()
        {
            List<Courses> lmd = new List<Courses>();  // creating list of model.
            DataSet ds = new DataSet();

            // connection to getdata.
            UniversityConnection.ConnectionCourses con = new UniversityConnection.ConnectionCourses();

            // fill dataset
            ds = con.CoursesTable();

            foreach (DataRow dr in ds.Tables[0].Rows) // loop for adding add from dataset to list<ModelData>
            {
                lmd.Add(new Courses
                {
                    CourseId = Convert.ToInt32(dr["CourseId"]),
                    CourseName = dr["CourseName"].ToString(),
                  //  CourseTime = dr["Course Time"].ToString(),                    
                    CreditHour = Convert.ToInt32(dr["CreditHour"]),
                    Major_Id = Convert.ToInt32(dr["Major_Id"])
                });
            }
            return View(lmd);
        }


    }
}