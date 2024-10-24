using HW8.Contacts;
using HW8.Database;
using HW8.Entitys;
using HW8.Enums;
using HW8.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8.services
{
    public class UserService
    {
        IUserRepository userrep;
        public UserService()
       {
            userrep = new UserRepository();
        }
        public void AddUser(User user)
        {
            userrep.Adduser(user);
            

        }
        public List<User> GetUsers()
        {
            return userrep.GetUsers();
        }
        public User getcurrentuser()
        {
            return userrep.Getcurentuser();
        }
        public Result Login(string email, string password)
        {
           
            var users = userrep.GetUsers();
            foreach (var user in users)
            {

                if (user.Email == email && user.Password == password)
                {
                    if (user.ISActive)
                    {
                        userrep.Login(user);
                        return new Result(true, null);
                    }

                    else
                    {
                        return new Result(false, "Your account is inactive");
                    }
                }
                

            }
            return new Result(false, "User not found");
        }

        public Result Register( string name, string family, string email, string password,EnumRole role)
        {
            var users = userrep.GetUsers();
            foreach (var user in users)
            {

                if (user.Email == email)
                {
                    return new Result(false, "This username exists");
                }
                else
                {

                    User newuser = new User();
                   
                    newuser.Id = users.Count;
                    newuser.FirstName = name;
                    newuser.LastName = family;
                    newuser.Email = email;
                    newuser.Password = password;
                    newuser.role = role;
                    userrep.Adduser(newuser);

                    return new Result(true, "Successfully registered");



                }
            }

            return new Result(true,null);
        }
    }
}

