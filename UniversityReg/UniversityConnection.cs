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
        public static string LoginCheck(string email, string pword)
        {
            string check;
            string connectionString = GetConnectionString();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("LoginCheck3", conn);           
              //  SqlCommand Cmd = new SqlCommand(query1, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@pword", pword);

                SqlParameter rtrnValue = new SqlParameter();
                rtrnValue.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(rtrnValue);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    if(email = )
                    check = (string)rtrnValue.Value;
                    
                    
                }
                catch(Exception ex)
                {
                    check = "0";
                }
                conn.Close();
                    
                return check;
            }           

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
