using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProDemo.DAO
{
    public class LoginEventHandle
    {
        private DatabaseConnection DB = null;
        private SqlCommand cmd;
        private SqlDataReader str;
        private SqlConnection conn;
        public LoginEventHandle()
        {
            try
            {
                DB = new DatabaseConnection();
            }
            catch(Exception e)
            {
                System.Windows.MessageBox.Show("Create DB connection Obj: " + e.Message);
            }
        }
        public bool IsValid(string id, string pw)
        {
            conn = DB.GetConntion();
            cmd = new SqlCommand("select accountId, accountPw from dbo.Account", conn);
            str = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            bool flag = false;
            while (str.Read())
            {
                //str[0] id
                //str[1] pw
                if (str[0].Equals(id) && str[1].Equals(pw))
                    flag = true;
            }
            if (!Release())
                return false;
            else 
                return flag;
        }
        private bool Release()
        {
            try
            {
                DB.Release(conn, cmd, str);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
