using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPrescriptionInterfaceProgramBate001.Models
{
    [Serializable]
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
        public List<DrugClass> Drugs { get; set; }
    }
}
