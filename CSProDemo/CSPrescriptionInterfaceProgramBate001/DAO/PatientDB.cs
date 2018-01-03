using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPrescriptionInterfaceProgramBate001.DAO
{
    public static class PatientDB
    {
        private static System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);
        private static readonly List<Models.PatientClass> patientList = XmlSerializer.LoadFromXml(config.AppSettings.Settings["patientFilePath"].Value.ToString(), typeof(List<Models.PatientClass>)) as List<Models.PatientClass>;
        public static Models.PatientClass RandomGetPatient(){
            System.Random random = new Random();
            int index = random.Next(patientList.Count());
            return patientList[index];
        }
    }
}
