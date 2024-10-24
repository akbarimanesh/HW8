using HW8.Database;
using HW8.Entitys;
using HW8.Enums;
using HW8.services;
using System;
using System.Text;

SeedDatacs.Seed();
int option;
int option2;
int option3;
int option4;
var sumunit = 0;
CourseServices courseServicecs = new CourseServices();
UserService userService = new UserService();


User user = new User();
do
{

    Console.Clear();
    Console.WriteLine("1:Login ");
    Console.WriteLine("2:Register ");
    Console.Write("please Enter your option : ");
    option = int.Parse(Console.ReadLine());
    switch (option)
    {
        case 1:
            Login();
            break;
        case 2:
            Register();
            break;
        default:
            break;
    }


} while (option < 3);
void Login()
{
    Console.Clear();
    Console.Write("please Enter Email: ");
    string email = Console.ReadLine();
    Console.Write("please Enter Password: ");
    string password = Console.ReadLine();
   
    var result = userService.Login(email, password);
    
    if (!result.Isuccess && user.ISActive==false)
    {
        Console.WriteLine(result.Massege);
        Console.WriteLine("*******************************");
        Console.ReadKey();
       
    }
    else if (userService.getcurrentuser().role==EnumRole.Student)
    {
        do
        {


            Console.Clear();
            Console.WriteLine("1:View the list of courses offered ");
            Console.WriteLine("2:Choice of courses ");
            Console.WriteLine("3:View the class schedule ");
            Console.WriteLine("4:Exit ");
            Console.Write("please Enter your option : ");
            option2 = int.Parse(Console.ReadLine());


            switch (option2)
            {
                case 1:
                     CoursesOffered();
                    break;
                case 2:
                    Choice();
                    break;
                case 3:
                    ViewSchedule();
                    break;

                case 4:
                    Exit();
                    break;
                default:
                    break;
            }


        } while (option2 < 4);
    }
    else if (userService.getcurrentuser().role == EnumRole.Teacher)
    {
        do
        {


            Console.Clear();
            Console.WriteLine("1:Create New Cource ");
            Console.WriteLine("2:View The List Of Students ");
            Console.WriteLine("3:Exit ");
            Console.Write("please Enter your option : ");
            option3 = int.Parse(Console.ReadLine());


            switch (option3)
            {
                case 1:
                    Create();
                    break;
                case 2:
                    ViewStudents();
                    break;
                case 3:
                    Exit();
                    break;
                default:
                    break;
            }


        } while (option3 <3);
    }
    else if (userService.getcurrentuser().role == EnumRole.Operator)
    {
        do
        {


            Console.Clear();
            Console.WriteLine("1:view users ");
            Console.WriteLine("2:create user ");
            Console.WriteLine("3:Class capacity ");
            Console.WriteLine("4:Active/Deactive Users ");
            Console.WriteLine("5:Exit ");
            Console.Write("please Enter your option : ");
            option4 = int.Parse(Console.ReadLine());


            switch (option4)
            {
                case 1:
                    Manege();
                    break;
                case 2:
                    CreateUser();
                    break;
                case 3:
                    Capacity();
                    break;
                case 4:
                    ActiveUser();
                    break;
                case 5:
                    Exit();
                    break;
                default:
                    break;
            }


        } while (option4 < 4);
    }
}

void Register()
{
   
       
        Console.Clear();
        
         Console.Write("please Enter Email: ");
        string email = Console.ReadLine();

            Console.Write("please Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("please Enter Family: ");
            string family = Console.ReadLine();
            Console.Write("please Enter Password: ");
            string password = Console.ReadLine();
            Console.Write("please Enter role  Student=1 2:Operator 3:Teacher ");
           EnumRole role = (EnumRole)Enum.Parse(typeof(EnumRole), Console.ReadLine());
            userService.Register(name, family, email, password,role);
            var result = userService.Login(email, password);
            Console.WriteLine("********************************");
            Console.WriteLine("You have successfully registered");
            
            Console.ReadKey();


}
void CoursesOffered()
{
    Console.Clear();
    CourseServices courseServicecs = new CourseServices();
    var courses = courseServicecs.GetCourses();
    foreach (var course in courses)
    {
        Console.WriteLine($" ID :{course.Id}- Name:{course.Name}- Unit :{course.Unit}- Timeofholding :{course.week} {course.Starttimet}-{course.Endtimet} - Capacity: {course.Capacity}- prerequisite :{course.prerequisite}- Teacher: {course.teacher.FirstName} {course.teacher.LastName}");
        Console.WriteLine(" **********************************************************************************************************************");
    }
    Console.ReadKey();
}

void Choice()
{
    bool check = false;
    Console.Clear();
    Console.WriteLine("List of courses offered :");
    Console.WriteLine("-------------------------");
    UserService userService = new UserService();
    CourseServices courseServicecs = new CourseServices();
    Student curentuser = (Student)userService.getcurrentuser();
    foreach (var course in courseServicecs.GetCourses())
    {
        Console.WriteLine($" ID :{course.Id}- Name:{course.Name}- Unit :{course.Unit}- Timeofholding :{course.week} {course.Starttimet}-{course.Endtimet} - Capacity: {course.Capacity}- prerequisite :{course.prerequisite}- Teacher: {course.teacher.FirstName} {course.teacher.LastName}");
        Console.WriteLine(" **********************************************************************************************************************");
    }
    Console.Write("please enter course :");
    var id = int.Parse(Console.ReadLine());
    
    var courses = courseServicecs.GetCourses();
   
    
    foreach (var course1 in courses)
    {
        if (course1.Id == id)
        {
          if(curentuser.courses.Count==0)
          {
                curentuser.courses.Add(course1);
                sumunit = sumunit + course1.Unit;
                course1.Capacity--;
                break;
          }

          foreach (var course2 in curentuser.courses)
          {
                if (course1.week == course2.week && course2.Starttimet <= course1.Starttimet && course2.Endtimet >= course1.Starttimet)
                {
                    Console.WriteLine("Time interference");
                    check = true;
                    break;
                }
          }
          if (!check)
          {
                  if (sumunit < 20)
                  {

                  curentuser.courses.Add(course1);
                  sumunit = sumunit + course1.Unit;
                  course1.Capacity--;
                  break;
                  }

                  else
                  {
                  Console.WriteLine("You are not allowed more than 20 units.");
                  break;
                  }
                            

                   
               
          }
            
            
        }
       
    }
    Console.Write("Do you want to continue? y/n : ");
    var iscontinue = Console.ReadLine();
    if (iscontinue == "y")
        Choice();
    else
        Console.ReadKey();


}
void ViewSchedule()
{

   
    Console.Clear();
    Student curentuser = (Student)userService.getcurrentuser();
    foreach (var course2 in curentuser.courses)
    {
        Console.WriteLine($" ID :{course2.Id}- Name:{course2.Name}- Unit :{course2.Unit}- Timeofholding :{course2.week} {course2.Starttimet}-{course2.Endtimet} - Capacity: {course2.Capacity}- prerequisite :{course2.prerequisite}- Teacher: {course2.teacher.FirstName} {course2.teacher.LastName}");
        Console.WriteLine(" **********************************************************************************************************************");
    }
    Console.ReadKey();
}
void Exit()
{
    
}
void Create()
{
    Course course = new Course();
    Console.Clear();
    CourseServices courseServicecs = new CourseServices();
    var courses = courseServicecs.GetCourses();
    int id = courses.Count;
    Console.Write("please Enter Name: ");
    string name = Console.ReadLine();
    Console.Write("please Enter unit: ");
    int unit =Int32.Parse( Console.ReadLine());
    Console.Write("please Enter week: ");
    string week = Console.ReadLine();
    Console.Write("please Enter starttime: ");
    int starttime = Int32.Parse(Console.ReadLine());
    Console.Write("please Enter endtime: ");
    int endtime = Int32.Parse(Console.ReadLine());
    Console.Write("please Enter Capacity: ");
    int capacity =int.Parse( Console.ReadLine());
    Console.Write("please Enter prerequisite: ");
    string prerequisite = Console.ReadLine();
   
    Course course1 = new Course();
    course1.Id = id;
    course1.Name = name;
    course1.Unit = unit;
    course1.week = week;
    course1.Starttimet = starttime;
    course1.Endtimet = endtime;
    course1.Capacity = capacity;
    course1.prerequisite = prerequisite;

   
    courseServicecs.AddCourse(course1);
   
    Console.WriteLine("********************************");
    Console.WriteLine("You have successfully created");

    Console.ReadKey();



}
void ViewStudents()
{
    Console.Clear();
  
    Teacher curentuser = (Teacher)userService.getcurrentuser();
    CourseServices courseServicecs = new CourseServices();
   // var students = courseServicecs.GetStudents();
    var courses2 = courseServicecs.GetCourses();
    TeacherServicescs teacherServicescs = new TeacherServicescs();
    var student= teacherServicescs.GetStudents(curentuser.Id);
   
    foreach (var st in student )
    {

        Console.WriteLine($" ID :{st.Id}- FullName:{st.FirstName} {st.LastName}- Email :{st.Email} ");
        foreach (var course in st.courses)
        {

            Console.WriteLine($" Name course:{course.Name}");
            Console.WriteLine(" **********************************************************************");
            break;
        }
       
    }
    Console.ReadKey();
}

void Manege()
{
    Console.Clear();
    var users = userService.GetUsers();
    foreach(var user in users)
    {
        Console.WriteLine($" ID :{user.Id}- FullName:{user.FirstName} {user.LastName}- Email :{user.Email}- role: {user.role}");
        Console.WriteLine(" **********************************************************************************************************************");
    }
    Console.ReadKey();
}
void CreateUser()
{

 
    Console.Clear();
    UserService userService = new UserService();
    var users = userService.GetUsers();
    int id = users.Count();
    Console.Write("please Enter firstname: ");
    string firstName = Console.ReadLine();
    Console.Write("please Enter lastname: ");
    string lastName = Console.ReadLine();
    Console.Write("please Enter email: ");
    string email = Console.ReadLine();
    Console.Write("please Enter password: ");
    string password = Console.ReadLine();
   // bool isactive = false;
    Console.Write("please Enter role  Student=1 2:Operator 3:Teacher :");
   EnumRole role = (EnumRole)Enum.Parse(typeof(EnumRole), Console.ReadLine());

    User user = new User();
    user.Id = id;
    user.FirstName = firstName;
    user.LastName = lastName;
    user.Email = email;
    user.Password = password;
   // user.ISActive = isactive;
    user.role = role;

    userService.AddUser(user);
    

    Console.WriteLine("********************************");
    Console.WriteLine("You have successfully created");

    Console.ReadKey();

}
void Capacity()
{
    Console.Clear();
   
    CourseServices courseServicecs = new CourseServices();
    var courses = courseServicecs.GetCourses();
    foreach(var course in courses)
    {
        Console.WriteLine($" idcourse={course.Id}  namecourse={course.Name} Capacity={course.Capacity}");
        Console.WriteLine(" ****************************************************************************");
    }
    Console.Write("Which Id lesson capacity do you want to change?");
    int i = int.Parse(Console.ReadLine());
    Console.Write("How much do you want to change?");
    int changecap = int.Parse(Console.ReadLine());
    foreach (var course1 in courses)
    {
        if (course1.Id == i)
        {
            course1.Capacity = course1.Capacity + changecap;
            break;
        }

    }
    Console.ReadKey();
}
void ActiveUser()
{
    var con="";
    Console.Clear();
    var users = userService.GetUsers();
    foreach (var user in users)
    {
            Console.WriteLine($" ID :{user.Id}- FullName:{user.FirstName} {user.LastName}- Email :{user.Email}- role: {user.role} Isactive: {user.ISActive}");
            Console.WriteLine(" **********************************************************************************************************************");
       
        

    }
    Console.Write("Which user do you want to activate/deactive ?");
    var id = int.Parse(Console.ReadLine());
    Console.Write("activate/deactive  (a/d)?");
    var act = Console.ReadLine();
    do
    {
        foreach (var item in users)
        {
            if (item.Id == id)
            {
                if (act == "a")
                {
                    item.ISActive = true;

                    Console.WriteLine("Activated successfully.");
                    break;
                }
                else if (act == "d")
                {
                    item.ISActive = false;

                    Console.WriteLine("Dactivated successfully.");
                    break;
                }

            }

        }
        Console.Write("Do you want to activate another user? y/n :");
         con= Console.ReadLine();
       
    } while (con == "y");
    
        Console.ReadKey();
}
