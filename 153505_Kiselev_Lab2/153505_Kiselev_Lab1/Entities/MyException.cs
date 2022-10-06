using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153505_Kiselev_Lab2.Entities
{
    internal class MyException : Exception
    {
        public MyException(string message) : base(message) { }
    }
}
