using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProDemo.Models
{
    public class EmployeeClass:AccountClass
    {
        public string Department { get; set; }
        protected string _Department;
    }
}
