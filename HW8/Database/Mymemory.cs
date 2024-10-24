using HW8.Entitys;
using HW8.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8.Database
{
    public static class Mymemory
    {
        public static User? UserCurrent { get; set; }
        public static List<User> users = new List<User>();
        public static List<Course> courses = new List<Course>();
      

        static Mymemory()
        {
            users = new List<User>()
            {
                new Student (){Id=0,FirstName="leila",LastName="akbari",Email="leila@gmail.com",Password="123456",ISActive=true,role=Enums.EnumRole.Student},
                 new Student (){Id=1,FirstName="hana",LastName="soleimani",Email="hana@gmail.com",Password="123456",ISActive=true,role=Enums.EnumRole.Student},
                  new Teacher (){Id=2,FirstName="ali",LastName="shams",Email="ali@gmail.com",Password="123456",ISActive=true,role=Enums.EnumRole.Teacher },
                   new Teacher (){Id=3,FirstName="lena",LastName="rezaei",Email="lena@gmail.com",Password="123456",ISActive=true,role=Enums.EnumRole.Teacher}

            };

         
            courses = new List<Course>()
            {
                new Course(){Id=0,Name="c#",Unit=3,week="Saturday",Starttimet= 14,Endtimet=16,Capacity=20,prerequisite="c++",teacher=new Teacher(3,"lena","rezaei","lena@gmail.com","123456")},
                new Course(){Id=1,Name="java",Unit=3,week="sunday",Starttimet= 08,Endtimet=10,Capacity=20,prerequisite="css",teacher=new Teacher(2,"ali","shams","ali@gmail.com","123456")},
                new Course(){Id=2,Name="php",Unit=3,week="Saturday", Starttimet= 15,Endtimet=17,Capacity=20,prerequisite="html",teacher=new Teacher(3,"lena","rezaei","lena@gmail.com","123456")},
                 new Course(){Id=3,Name="math2",Unit=3,week="sunday", Starttimet= 09,Endtimet=11,Capacity=20,prerequisite="math1",teacher=new Teacher(2,"ali","shams","ali@gmail.com","123456")},
                  new Course(){Id=4,Name="sqlserver",Unit=3,week="Wednesday", Starttimet= 08,Endtimet=10,Capacity=20,prerequisite="oracle",teacher=new Teacher(3,"lena","rezaei","lena@gmail.com","123456")},
                   new Course(){Id=5,Name="physic2",Unit=3,week="Saturday", Starttimet= 15,Endtimet=17,Capacity=20,prerequisite="physic1",teacher=new Teacher(2,"ali","shams","ali@gmail.com","123456")},
                    new Course(){Id=6,Name="history2",Unit=2,week="monday", Starttimet= 15,Endtimet=17,Capacity=20,prerequisite="history1",teacher=new Teacher(3,"lena","rezaei","lena@gmail.com","123456")},
                     new Course(){Id=7,Name="Researchmethod",Unit=2,week="monday", Starttimet= 14,Endtimet=16,Capacity=20,prerequisite="Research",teacher=new Teacher(2,"ali","shams","ali@gmail.com","123456")},
            };

          
        }



    }
}
