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
        public static void OpenSqlConnection()
        {
            string connectionString = GetConnectionString();

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
            }
        }

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
        public static bool LoginCheck(Student student)
        {
            string connectionString = GetConnectionString();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand Command = new SqlCommand(query1, conn);

                conn.Open();
                SqlDataReader dr = Command.ExecuteReader();
                while (dr.Read())
                {
                    string email = (string)dr["Email"];
                    string password = (string)dr["Password"];
                    if (email != student.email && password != student.password)
                    {

                        dr.Close();
                        return false;
                    }
                    
                }
                dr.Close();
            }
            
            return false;
        }
            
        
        public static string GetConnectionString()
        {
            return "Data Source = firstdatabase.ckfyvy05mrkv.us-west-2.rds.amazonaws.com,1433; Initial Catalog = RegistrationApplication; Persist Security Info = True; User Id = mike; Password = Midnightcj1; Encrypt = False;";
        }

        public static string AddStudent(Student student)
        {
            return "INSERT INTO [Student]VALUES(" + student.Fname + ',' + student.Lname + ',' + student.email + ',' + student.password + ')';
        }

        //public static void RegisterNewStudent()
        //{
        //    GetDisconnectedResults((GetConnectionString(), AddStudent(student)));
        //}
    }
}
