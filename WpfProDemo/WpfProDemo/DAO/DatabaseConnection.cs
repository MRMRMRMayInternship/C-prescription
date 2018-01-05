using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProDemo.DAO
{
    public class DatabaseConnection
    {
        private static DatabaseConnectionPool pool = null;
        public DatabaseConnection()
        {
            if (pool == null)
                pool = new DatabaseConnectionPool();

        }
        public SqlConnection GetConntion(){
            return pool.ConnectionPool;
        }
        public void Release(SqlConnection con, SqlCommand cmd, SqlDataReader str)
        {
            
            try
            {
                cmd.Dispose();
            }
            catch(Exception e)
            {
                System.Windows.MessageBox.Show("cmd.Dispose(): " + e.Message);
            }
            try
            {
                str.Dispose();
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show("str.Dispose(): " + e.Message);
            }
            try
            {
                con.Close();
                pool.ConnectionPool = con;
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show("Close conn : " + e.Message);
            }
        }
    }
}
