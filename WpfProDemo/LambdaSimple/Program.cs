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
            string source= "홍기동";
            var bytes = System.Text.Encoding.Default.GetBytes(source);
            string result = string.Empty;
            foreach(var temp in bytes){
                System.Console.Write("{0,3}",temp.ToString());
                result += string.Format(@"?{0,3}", temp.ToString());
            }
            var list = new List<byte>();
            var templist = result.Split('?');
            foreach (var temp in templist)
            {
                if(!string.IsNullOrEmpty(temp))
                list.Add(Convert.ToByte(temp));
            }
            System.Console.Write(System.Text.Encoding.Default.GetString(list.ToArray()));
        }
    }
}
