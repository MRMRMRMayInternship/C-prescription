using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CSPrescriptionInterfaceProgramBate001.Models
{
    [System.Runtime.Serialization.DataContract(Name = "DrugList", Namespace = "")]
    class DrugsClass : System.Runtime.Serialization.IExtensibleDataObject
    {
        [System.Runtime.Serialization.DataMember(Name="Drugs")]
        public IList<DrugClass> Drugs { get; set; }

        public ExtensionDataObject ExtensionData
        {
            get;
            set;
        }
    }
}
