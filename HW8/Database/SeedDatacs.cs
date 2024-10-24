using HW8.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8.Database
{
    public static class SeedDatacs
    {
        public static  void Seed()
        {
            User op = new User(4,"saba","sharifi", "admin@gmail.com", "123456");
            op.role = Enums.EnumRole.Operator;
            op.ISActive = true;
            Mymemory.users.Add(op);
        }
    }
}
