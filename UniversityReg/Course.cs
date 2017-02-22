using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityReg
{
    
        public class Course
        {
        public string title { get; set; }
        public string title1;
            private string major;
            private DateTime TimeOfDay;
            private int creditHour;
            public bool isClosed;

        public Course()
        {

        }
        
        public Course(string title1, DateTime timeOfDay, int creditHour = 1, string major = "Elective")
            {
                this.title1 = title;
                this.major = major;
                this.TimeOfDay = timeOfDay;
                this.creditHour = creditHour;
                //  this.id = id;
            }
            private List<Student> studentRoster = new List<Student>();

            public delegate bool CloseRegistration(Course thisCourseToClose);
            public CloseRegistration cr = null;

            public int RosterCount
            {
                get
                {
                    return studentRoster.Count;
                }
            }

            public bool isFull
            {
                get
                {

                    return studentRoster.Count == Global.maxStudents;
                }


            }

            public Student GetStudentById(int id)
            {
                var student = studentRoster.Where(x => x.Id == id).FirstOrDefault();
                return student;
            }

            public Student GetStudentByFirstName(string fn)
            {
                var results = studentRoster.Where(person => person.Fname == fn).FirstOrDefault();
                return results;
            }

            public Student GetStudentByFullname(string name)
            {
                var result = studentRoster.Where(p => p.FullName == name).FirstOrDefault();
                return result;
            }

            public Student GetStudentByFullName(string firstname, string lastname)
            {
                return GetStudentByFullname(firstname + " " + lastname);
            }

            public bool AddStudent(Student student)
            {

                //        SpaceCheck(studentRoster.Count + 1);
                studentRoster.Add(student);
                if (cr != null && isFull)
                {
                    cr(this);
                }
                return true;
            }

            public bool AddStudents(List<Student> roster)
            {
                //        SpaceCheck(roster.Count + studentRoster.Count);
                foreach (Student item in roster)
                {
                    AddStudent(item);
                }
                return true;
            }


            public bool RemoveStudentById(int id)
            {
                return studentRoster.Remove(GetStudentById(id));
            }

            public string Title
            {
                get
                {
                    return title; ;
                }
            }

            public Task<List<Student>> FetchRoster()
            {
                return Task.Run(() => { return studentRoster; });
            }
            public bool RemoveStudent(Student student)
            {
                throw new NotImplementedException();
            }

            public bool RemoveStudent(int id)
            {
                throw new NotImplementedException();
            }

            public bool RemoveStudent(string Fname, string Lname)
            {
                throw new NotImplementedException();
            }
            public async Task<List<Student>> GetStudentRoster()
            {
                Console.WriteLine("Start async");
                var results = await FetchRoster();
                Console.WriteLine("End async");
                return results;
            }
        }
    }

