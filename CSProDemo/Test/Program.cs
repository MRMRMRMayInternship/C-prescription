using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            String str = "asd";
            StringBuilder sb = new StringBuilder(str);
            sb[1] = 'd';
            Console.WriteLine(str);
        }
    }
}
