using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIPusingWPFModel;
namespace WpfProDemo.DAO
{
    public class LoginEventHandle
    {
        //private DatabaseConnection DB = null;
        //private SqlCommand cmd;
        //private SqlDataReader str;
        //private SqlConnection conn;
        //public LoginEventHandle()
        //{
        //    try
        //    {
        //        DB = new DatabaseConnection();
        //    }
        //    catch(Exception e)
        //    {
        //        System.Windows.MessageBox.Show("Create DB connection Obj: " + e.Message);
        //    }
        //}
        /// <summary>
        /// using Entity Framework 6.0
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pw"></param>
        /// <returns></returns>
        public bool IsValid(string id, string pw)
        {
            using(PIPusingWPFModel.PIPEntities conn = new PIPusingWPFModel.PIPEntities()){
                var result = conn.Accounts.Where(u => u.Did.Equals(id) && u.AccountPw.Equals(pw)).FirstOrDefault();
                return result != null;
            }
        }
        //public bool IsValidTest(string id, string pw)
        //{
        //    conn = DB.GetConntion();
        //    cmd = new SqlCommand("select Did, accountPw from dbo.Account", conn);
        //    str = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        //    bool flag = false;
        //    while (str.Read())
        //    {
        //        //str[0] id
        //        //str[1] pw
        //        if (str[0].Equals(id) && str[1].Equals(pw))
        //            flag = true;
        //    }
        //    if (!Release())
        //        return false;
        //    else 
        //        return flag;
        //}
        //private bool Release()
        //{
        //    try
        //    {
        //        DB.Release(conn, cmd, str);
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //    return true;
        //}
    }
}
