using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProDemo.DAO
{
    public static class DoctorsDB
    {
        private static DatabaseConnection DB = new DatabaseConnection();
        
        public static List<Models.Doctor> FindDoctorByDid(string _did)
        {
            List<Models.Doctor> result = new List<Models.Doctor>();
            SqlConnection conn = DB.GetConntion();
           
            SqlCommand cmd = new SqlCommand("select Name, Did, Department from dbo.Doctors", conn);
            SqlDataReader str = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (str.Read())
            {
                Models.Doctor dObj = new Models.Doctor();
                str.GetString(0);
            }
            return result;
        }
    }
}
