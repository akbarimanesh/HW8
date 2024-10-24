using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8.Entitys
{
    public class Student : User
    {
        public int StudentId { get; set; }
        public List<Course> courses { get; set; } = new List<Course>();
        public Student(int id,string firstname ,string lastname,string email, string password,int studentId) : base(id,firstname,lastname, email, password)
        {
            StudentId = studentId;
        }

        public Student()
        {
        }

        //public static explicit operator Student(User v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
