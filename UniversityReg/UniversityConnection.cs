﻿using System;
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
