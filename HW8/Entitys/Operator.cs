using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8.Entitys
{
    public class Operator : User
    {
        
        public Operator(int id,string firstname,string lastname, string email, string password) : base(id, firstname,lastname,email, password)
        {
        }
    }
}
