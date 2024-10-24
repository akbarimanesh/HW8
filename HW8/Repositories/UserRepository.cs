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
    public class UserRepository : IUserRepository
    {
        public void Adduser(User user)
        {
            Mymemory.users.Add(user);
        }

        public User Getcurentuser()
        {
            return Mymemory.UserCurrent;
        }

        public List<User> GetUsers()
        {
            return Mymemory.users;
        }

        public void Login(User user)
        {
            Mymemory.UserCurrent = user;
        }

        public void Register(User user)
        {
            Mymemory.users.Add(user);
        }
    }
}