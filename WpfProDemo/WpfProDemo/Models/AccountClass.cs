using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace WpfProDemo.Models
{
    public class AccountClass:PersonClass
    {
        public string ID { get; set; }
        public string Password { get; set; }
    }
}
