using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

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
    public class Person
    {
        
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public class Patient : Person
    {
        //public override string Name {get; set;}   
    }
    [DataContract(Name="ArrayListTest",Namespace="Test")]
    public class ArrayListTest
    {
        [DataMember]
        public IList<Patient> Patients = new List<Patient>();
    }
    class Program
    {
        static void Main()
        {
            ArrayListTest test = new ArrayListTest();
            for (int i = 0; i < 10; i++)
            {
                Patient p = new Patient();
                p.Name = "name" + i;
                p.Age = 10 + i;
                test.Patients.Add(p);
            }
            System.IO.FileStream fs = new System.IO.FileStream(System.Environment.CurrentDirectory + @"\test1.xml",System.IO.FileMode.OpenOrCreate);
            DataContractSerializer ser = new DataContractSerializer(test.GetType());
            ser.WriteObject(fs, test);
            fs.Close();
            fs = new System.IO.FileStream(System.Environment.CurrentDirectory + @"\test1.xml", System.IO.FileMode.Open);
            ArrayListTest test1 = (ArrayListTest)ser.ReadObject(fs);
            fs.Close();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(test1.Patients[i].Name + test1.Patients[i].Age);
            }
        }
    }
}
