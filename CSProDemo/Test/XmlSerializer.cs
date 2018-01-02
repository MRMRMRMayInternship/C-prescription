using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace CSPrescriptionInterfaceProgramBate001.DAO
{
    public static class XmlSerializer
    {
        public static void SaveToXml(string filePath, object sourceObj, Type type){
            if(!string.IsNullOrWhiteSpace(filePath)&&sourceObj!=null){
                type = type != null ? type : sourceObj.GetType();
                if(!string.IsNullOrWhiteSpace(filePath)){
                    FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
                    System.Xml.Serialization.XmlSerializer sr = new System.Xml.Serialization.XmlSerializer(type);
                    sr.Serialize(fs, sourceObj);
                    fs.Close();
                }
            }
        }
        public static object LoadFromXml(string filePath, Type type)
        {
            object result = null;
            if (File.Exists(filePath))
            {
                FileStream fs = new FileStream(filePath, FileMode.Open);
                System.Xml.Serialization.XmlSerializer sr = new System.Xml.Serialization.XmlSerializer(type);
                result = sr.Deserialize(fs);
            }
            return result;
        }
    }
}
