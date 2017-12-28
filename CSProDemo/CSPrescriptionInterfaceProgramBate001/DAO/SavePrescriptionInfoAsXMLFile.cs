using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace CSPrescriptionInterfaceProgramBate001.DAO
{
    class SavePrescriptionInfoAsXMLFile
    {
        public void SaveAsXMLFile(Models.PrescriptionClass info, string filename){
            System.IO.FileStream fs = new System.IO.FileStream(filename, System.IO.FileMode.OpenOrCreate);
            DataContractSerializer sr = new DataContractSerializer(info.GetType());
            sr.WriteObject(fs, info);
            fs.Close();
        }
    }
}
