using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPrescriptionInterfaceProgramBate001.Models
{
    public class DrugClass
    {
        public string DrugName { get; set; }
        public string DrugID { get; set; }
        public int TimeDuration { get; set; }
        public int TimesPerDay { get; set; }
        public int dosagePerTime_Value { get; set; }
        public string dosagePerTime_Unit { get; set; }
        public string Usage { get; set; }
        public string instruction { get; set; }
        public string creation { get; set; }
    }
}
