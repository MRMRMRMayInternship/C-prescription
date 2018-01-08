using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProDemo.DAO
{
    public static class PatientDB
    {
        private static System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);
        private static readonly List<Models.Patient> patientList = XmlSerializer.LoadFromXml(config.AppSettings.Settings["patientFilePath"].Value.ToString(), typeof(List<Models.Patient>)) as List<Models.Patient>;
        public static Models.Patient RandomGetPatient(){
            System.Random random = new Random();
            int index = random.Next(patientList.Count());
            return patientList[index];
        }
    }
}
