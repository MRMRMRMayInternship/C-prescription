using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WpfProDemo.StaticMethod
{
    /// <summary>
    /// http://www.jb51.net/article/104891.htm
    /// </summary>
    public static class StringEncodingManagement
    {
        public static string GetBytesStr(string source)
        {
            var bytes = System.Text.Encoding.Default.GetBytes(source);
            string result = string.Empty;
            foreach (var temp in bytes)
            {
                System.Console.Write("{0,3}", temp.ToString());
                result += string.Format(@"?{0,3}", temp.ToString());
            }
            return result;
        }
        public static string GetUTF(string source)
        {
            var list = new List<byte>();
            var templist = source.Split('?');
            foreach (var temp in templist)
            {
                if (!string.IsNullOrEmpty(temp))
                    list.Add(Convert.ToByte(temp));
            }
            return System.Text.Encoding.Default.GetString(list.ToArray());
        }
    }
}
