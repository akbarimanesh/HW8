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
    public class StudentRepository : IStudentRepository
    {
        public Student get()
        {
            foreach(var user in Mymemory.users)
            {
                if(user is Student)
                {
                    
                    return (Student)user;
                }
            }return null;
        }
    }
}
