using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MikesUniversity.Models
{
    public class Courses
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseTime { get; set; }
        public int CreditHour { get; set; }
        public int Major_Id { get; set; }
    }
}