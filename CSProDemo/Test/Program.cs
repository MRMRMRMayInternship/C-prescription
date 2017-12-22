using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Project
    {
        public string Input { get; set;}
        public Inner[] Ouput { get; set; }
    }
    class Inner
    {
        public string Input { get; set; }
        public string Output { get; set; }
    }
    class JsonProgram
    {
        public void run()
        {
            Inner[] i = new Inner[]{new Inner(){},new Inner() { Input = "Inner Input", Output = "Inner Output" }};
            Project p = new Project() { Input = "Project Input", Ouput = i };
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            var json = js.Serialize(p);
            Console.WriteLine(json.ToString());
            Project p1 = js.Deserialize<Project>(json);
            Console.WriteLine(p1.Input + p1.Ouput[0]);
        }
    }
    class Prototy
    {
        public string HEHE{ get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            JsonProgram obj = new JsonProgram();
            obj.run();
        }
    }
}
