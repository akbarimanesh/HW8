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
    public class CourseRepository : ICourseRepository
    {
        public List<Course> Get()
        {
            return Mymemory.courses;
        }
        public void AddCourse(Course course)
        {
            Mymemory.courses.Add(course);
        }

        


        
    }
}
