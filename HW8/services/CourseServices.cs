using HW8.Contacts;
using HW8.Entitys;
using HW8.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8.services
{
    public class CourseServices
    {
        ICourseRepository courserep;
        ITeacherRepository teachrepo;
        IStudentRepository sturep;
        public CourseServices()
        {
            courserep = new CourseRepository();
            teachrepo = new TeacherRepository();
            sturep = new StudentRepository();
        }
       
        public List<Course> GetCourses()
        {
            return courserep.Get();
        }
        public void AddCourse(Course course )
        {

            course.teacher = teachrepo.get();
            courserep.AddCourse(course);

        }

        public IStudentRepository GetSturep()
        {
            return sturep;
        }

        public Student GetStudents()
        {
            return sturep.get();
        }
    }
}
