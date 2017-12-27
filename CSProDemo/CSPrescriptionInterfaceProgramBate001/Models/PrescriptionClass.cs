using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPrescriptionInterfaceProgramBate001.Models
{
    [System.Runtime.Serialization.DataContract(Name="Prescription",Namespace="CSPrescriptionInterfaceProgramBate001.Models")]
    class PrescriptionClass
    {
        [System.Runtime.Serialization.DataMember]
        //private System.Collections.Generic.IList<DrugClass> drugArrayList = new System.Collections.Generic.List<DrugClass>();
        public string PrescriptionID { get; set; }
        public string Date { get; set; }
        public PatientClass Patient { get; set; }
        public DoctorClass Docotr { get; set; }
        public IList<DrugClass> Drugs { get; set; }
    }
}
