using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProDemo.Models
{
    public class PersonClass
    {
        protected string _Name;
        public string Name { get; set; }
        protected string _ResidentRegistrationNumber;
        public string ResidentRegistrationNumber { get; set; }
        protected string _Birthday;
        public string Birthday { get; set; }
        protected string _Age;
        public string Age { get; set; }
        protected string _Sex;
        public string Sex { get; set; }
    }
}
