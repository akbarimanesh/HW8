using HW8.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8.Contacts
{
    public interface IUserRepository
    {
      public  void Login(User user);
        public void Register(User user);
        public User Getcurentuser();
        public List<User> GetUsers();
        public void Adduser(User user);
    }
}
