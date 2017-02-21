using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityReg
{
    
        public abstract class Users
        {
            public string Fname;
            public string Lname;
            public string password;
            public string email;
            public int id;

            public Users()
            {

            }

            public Users(string Fname, String Lname, string password, string email)
            {
                this.Fname = Fname;
                this.Lname = Lname;
                this.password = password;
                this.email = email;

            }

            public abstract string GetInfo();


            public string FullName
            {
                get { return Fname + "" + Lname; }

            }
            public virtual string Password
            {
                get
                {
                    return password;
                }
            }
            public string Email
            {
                get
                {
                    return email;
                }
                set
                {
                    email = value;
                }
            }
            public int Id
            {
                get
                {
                    return id;
                }
                set
                {
                    id = value;
                }
            }
            public override string ToString()
            {
                string result = "";
                result += FullName;
                result += "\n" + Email;
                return result;
            }

        }
    }

