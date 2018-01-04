using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProDemo.Models
{
    [Serializable]
    public class PrescriptionClass
    {
        //private System.Collections.Generic.IList<DrugClass> drugArrayList = new System.Collections.Generic.List<DrugClass>();
        public string PrescriptionID { get; set; }
        public string Date { get; set; }
        public PatientClass Patient { get; set; }
        public DoctorClass Doctor { get; set; }
        public List<DrugClass> Drugs { get; set; }
    }
}
