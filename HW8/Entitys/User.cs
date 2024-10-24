using HW8.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8.Entitys
{
   public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool ISActive { get; set; } = false;
       public EnumRole role { get; set; }
        
        public User(int id,string firstname,string lastname,string email,string password) 
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Password = password;
       

        }

        public User()
        {
        }
    }
}
