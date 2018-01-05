using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;
namespace WpfProDemo.DAO
{
    public class DatabaseConnectionPool
    {
        //@"Server=(localdb)\ProjectsV12;Initial Catalog=mrestaurant;Integrated Security=true";
        private readonly SqlConnectionStringBuilder connStr = null;
        private static Stack<SqlConnection> connectionPool = null;
        private const int size = 0;
        private int useCount = 0;
        public DatabaseConnectionPool()
        {
            if (connStr == null)
            {
                connStr = new SqlConnectionStringBuilder();
                connStr.DataSource = @"(localdb)\ProjectsV12";
                connStr.InitialCatalog = "PIP";
                connStr.IntegratedSecurity = true;
                connStr.ConnectTimeout = 1;
                connStr.MaxPoolSize = 10;
            }

            if (connectionPool == null)
                InitializeConnectionPool();

        }
        public void InitializeConnectionPool(int count = 10)
        {
            connectionPool = new Stack<SqlConnection>();
            for (int i = 0; i < count; i++)
            {
                try
                {
                    SqlConnection conn = new SqlConnection(connStr.ConnectionString);
                    ConnectionPool = conn;
                }
                catch(Exception e)
                {
                    MessageBox.Show("Connection error :" + e.Message);
                    break;
                }
            }
        }
        public SqlConnection ConnectionPool
        {
            get
            {
                lock (connectionPool)
                {
                    SqlConnection temp = null;
                    if (connectionPool.Count() <= 0)
                    {
                        MessageBox.Show("No any connection in the pool.");
                        return temp;
                    }
                    else
                    {
                        MessageBox.Show("Connection Count: " + connectionPool.Count());
                        temp = connectionPool.Pop();
                        temp.Open();
                        return temp;
                    }
                }
            }
            set
            {
                if (value != null)
                    connectionPool.Push(value);
            }
        }
    }
}
