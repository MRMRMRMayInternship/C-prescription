using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPrescriptionInterfaceProgramBate001.Models
{
    [System.Runtime.Serialization.DataContract(Name="Prescription",Namespace="CSPrescriptionInterfaceProgramBate001.Models")]
    public class PrescriptionClass
    {
        [System.Runtime.Serialization.DataMember]
        //private System.Collections.Generic.IList<DrugClass> drugArrayList = new System.Collections.Generic.List<DrugClass>();
        public string PrescriptionID { get; set; }
        [System.Runtime.Serialization.DataMember]
        public string Date { get; set; }
        [System.Runtime.Serialization.DataMember]
        public PatientClass Patient { get; set; }
        [System.Runtime.Serialization.DataMember]
        public DoctorClass Docotr { get; set; }
        [System.Runtime.Serialization.DataMember]
        public IList<DrugClass> Drugs { get; set; }
    }
}
