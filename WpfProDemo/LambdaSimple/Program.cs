using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace LambdaSimple
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> test = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                test.Add(i);
            }
            test.RemoveAll(i=>i<50);
            foreach(int i in test)
                Console.WriteLine(i);
        }
    }
}
