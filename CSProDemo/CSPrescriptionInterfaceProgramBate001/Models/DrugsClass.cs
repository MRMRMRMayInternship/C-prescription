using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPrescriptionInterfaceProgramBate001.Models
{
    [System.Runtime.Serialization.DataContract(Name = "Drug", Namespace = "CSPrescriptionInterfaceProgramBate001.Models")]
    class DrugsClass
    {
        [System.Runtime.Serialization.DataMember(Name="Drugs")]
        public IList<DrugClass> Drugs { get; set; }
    }
}
