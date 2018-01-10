using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProDemo.Models
{
    [Serializable]
    public class DrugClass
    {
        public string Price { get; set; }
        public string DrugName { get; set; }
        public string DrugID { get; set; }
        public string TimeDuration { get; set; }
        public string TimesPerDay { get; set; }
        public string DosagePerTime_Value { get; set; }
        public string DosagePerTime_Unit { get; set; }
        public string Usage { get; set; }
        public string Instruction { get; set; }
        public string Creation { get; set; }
        public bool WhenMorning { get; set; }
        public bool WhenAfternoon { get; set; }
        public bool WhenEvening { get; set; }
    }
}
