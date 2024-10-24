using HW8.Contacts;
using HW8.Database;
using HW8.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        public Teacher get()
        {
            foreach(var user in Mymemory.users)
            {
                if(user is Teacher)
                {
                    return (Teacher)user;
                }
            }return null;
        }

        public List<Student> GetStudents(int teacherid)
        {
            List<Student> students = new List<Student> ();
           foreach(var user1 in Mymemory.users)
            {
                if(user1 is Student)
                {
                    var student1 = (Student)user1;
                    foreach(var st in student1.courses)
                    {
                        if(st.teacher.Id==teacherid)
                        {
                            students.Add(student1);
                        }
                    }
                }    
            }return students;
        }
    }
}
