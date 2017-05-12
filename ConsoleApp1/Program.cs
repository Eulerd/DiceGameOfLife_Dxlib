using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1;
            int i = 0;
            while(a < Math.Pow(10 , 9))
            {
                a <<= 1;
                i++;
            }


        }
    }
}
