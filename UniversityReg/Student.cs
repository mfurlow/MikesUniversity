using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityReg
{
    public class Student : Users
    {
        private int major;
        private bool isFulltime;
        private string registeredCourses;
        Dictionary<string, Course> classes = new Dictionary<string, Course>();

        public Student()
        {

        }

        public Student(string Fname, string Lname, string password, string email) : base(Fname, Lname, password, email)
        {
            this.major = major;
            isFulltime = false;
        }
        public override string GetInfo()
        {
            StringBuilder info = new StringBuilder(base.ToString());
            info.Append($"\n (major)");
            info.Append($"\nfulltime: (isFulltime)");

            if (classes.Count == 0)
            {
                info.Append("not registered for classes");
            }
            else
            {
                foreach (KeyValuePair<string, Course> c in classes)
                {
                    info.Append("\n");
                    info.Append(c.Value.Title);
                }
            }
            return info.ToString();
        }

    }
}
