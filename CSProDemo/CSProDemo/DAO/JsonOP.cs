using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProDemo.DAO
{
    class JsonOP
    {
        private System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();  
        public string GetJson(object obj)
        {
            var json = js.Serialize(obj);
            return json.ToString();
        }
        public object Deserialize(string json)
        {
            return null;
        }
    }
}
