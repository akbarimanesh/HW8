using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8.Entitys
{
    public class Course 
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public int Unit { get; set; }
        
        public int Capacity { get; set; }
        public string week { get; set; }
        public int Starttimet { get; set; }
        public string prerequisite { get; set; }
        public int Endtimet { get; set; }
        public List<Student> students { get; set; } = new List<Student>();
        public Teacher teacher { get; set; } 
        public override string ToString()
        {
            return $"{Name}({Unit}-{teacher.FirstName} {teacher.LastName})";
        }

    }
}
