using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8
{
    public class Result
    {
        public bool Isuccess { get; set; }
        public string? Massege { get; set; }
        public Result(bool isuccess,string?massage)
        {
            Isuccess = isuccess;
            Massege = massage;
        }
    }
}
