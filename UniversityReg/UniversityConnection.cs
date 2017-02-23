using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace UniversityReg
{
    
    public static class UniversityConnection
    {
        public static string query1 = "SELECT * FROM Student";
        /// <summary>
        /// This is where the connectin to the database is established
        /// </summary>
        public static void OpenSqlConnection()
        {
            string connectionString = GetConnectionString();

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
            }
        }
        /// <summary>
        ///     Disconnected Architecture that connects to the database
        /// </summary>
        /// <param name="con"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public static DataSet GetDisconnectedResults(string con, string query)
        {
            using (SqlConnection sqlcon = new SqlConnection(con))
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(query, sqlcon);
                adapter.Fill(ds);

                return ds;
            }

        }
        /// <summary>
        /// This checks the username and the password that the user inputs against the database
        /// </summary>
        /// <param name="email"></param>
        /// <param name="pword"></param>
        /// <returns></returns>
        public static bool LoginCheck(string email, string pword)
        {
            bool check;
            string connectionString = GetConnectionString();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("LoginCheck4", conn);           
              //  SqlCommand Cmd = new SqlCommand(query1, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", email);
                cmd.Parameters.AddWithValue("@password", pword);

                SqlParameter rtrnValue = new SqlParameter();
                rtrnValue.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(rtrnValue);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    check = (bool)rtrnValue.Value;                  
                    
                }
                catch(Exception ex)
                {
                    check = false;
                }
                conn.Close();                    
                return check;
            }           
        }
        public static string GetConnectionString()
        {
            return "Data Source = firstdatabase.ckfyvy05mrkv.us-west-2.rds.amazonaws.com,1433; Initial Catalog = RegistrationApplication; Persist Security Info = True; User Id = mike; Password = Midnightcj1; Encrypt = False;";
        }

        /// <summary>
        /// This will add a student to the database
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public static string AddStudent(Student student)
        {
            return "EXEC AddNStudent1 @fname = '" + student.Fname + "',@lname ='" + student.Lname + "',@email ='" + student.email + "',@pword = '" + student.password + "'" ;
        }
        /// <summary>
        /// This returns the schedule for the given student using a stored procedure
        /// </summary>
        /// <param name="stuId"></param>
        public static void ViewSchedule(int stuId)
        {
            string connection = GetConnectionString();
              
            using (SqlConnection sqlcon = new SqlConnection(connection))
            {
                SqlCommand command = new SqlCommand("StudentSchedule", sqlcon);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@studentId", stuId);
                try
                {
                    sqlcon.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}, {1},{2}", reader[0], reader[1],reader[2]);
                        
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
            
        }
        public static DataSet StudentSchedule()
        {
            string connectionString = GetConnectionString();
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("StudentSchedule", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet dsCourses = new DataSet();

            da.Fill(dsCourses);
            return dsCourses;
        }

        public static string AddCourse(Course c)
        {
            return "";
        }

        public class ConnectionCourses
        {

            public DataSet CoursesTable()
            {
                string connectionString = GetConnectionString();
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("select * from Course", con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet dsCourses = new DataSet();

                da.Fill(dsCourses);
                return dsCourses;
            }
        }

     }
}
