using HW8.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8.Contacts
{
    public interface ITeacherRepository
    {
        public Teacher get();
        public List<Student> GetStudents(int teacherid);
    }
}
