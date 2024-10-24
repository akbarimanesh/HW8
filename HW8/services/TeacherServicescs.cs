using HW8.Entitys;
using HW8.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8.services
{
    public  class TeacherServicescs
    {
        TeacherRepository teachrep;
        public TeacherServicescs()
        {
            teachrep = new TeacherRepository();
        }
        public List<Student> GetStudents(int teacherid)
        {
            return teachrep.GetStudents(teacherid);
        }
    }
}
