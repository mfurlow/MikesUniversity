using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UniversityReg
{
    class Program
    {
        static void Main(string[] args)
        {

         int num =  int.Parse(Console.ReadLine());
            UniversityConnection.ViewSchedule(num);
            //var listOfCourses = new List<Course>();
            

            //using (var connection = new SqlConnection("Data Source = firstdatabase.ckfyvy05mrkv.us-west-2.rds.amazonaws.com,1433; Initial Catalog = RegistrationApplication; Persist Security Info = True; User Id = mike; Password = Midnightcj1; Encrypt = False;"))
            //{
            //    connection.Open();
            //    string sql = "select CourseName From Course";
            //    using (var command = new SqlCommand(sql, connection))
            //    {
            //        using (var reader = command.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                Course course = new Course();
            //                course.title = (string)reader[0];


            //                listOfCourses.Add(course);

            //            }
            //            foreach (Course co in listOfCourses)
            //            {
            //                Console.WriteLine(co);
            //                Console.ReadLine();
            //            }

            //        }
            //    }
            //}



        }
        public List<Course> LoadCourse()
        {
            var listOfCourses = new List<Course>();

            using (var connection = new SqlConnection("Data Source = firstdatabase.ckfyvy05mrkv.us-west-2.rds.amazonaws.com,1433; Initial Catalog = RegistrationApplication; Persist Security Info = True; User Id = mike; Password = Midnightcj1; Encrypt = False;"))
            {
                connection.Open();
                string sql = "select CourseName From Course";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var course = new Course();
                            course.title = reader["CourseName"].ToString();
                            listOfCourses.Add(course);
                        }                        
                    }
                }
            }
            return listOfCourses;
        }
    }
}
