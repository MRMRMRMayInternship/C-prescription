using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace CSPrescriptionInterfaceProgramBate001.Controllers
{
    class SavePrescriptionInfoAsXMLFile
    {
        public void SaveAsXMLFile(Models.PrescriptionClass info){
            string filename = System.Environment.CurrentDirectory+@"\"+info.Patient.PatientID + "_" + info.PrescriptionID+@".xml";
            System.IO.FileStream fs = new System.IO.FileStream(filename, System.IO.FileMode.OpenOrCreate);
            DataContractSerializer sr = new DataContractSerializer(info.GetType());
            sr.WriteObject(fs, info);
            fs.Close();
        }
    }
}
