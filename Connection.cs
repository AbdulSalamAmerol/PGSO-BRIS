using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Linq.Expressions;
using System.Runtime.InteropServices;




namespace pgso
{
    class Connection
    {
        public SqlConnection strCon;
        public Connection()
        {
            try
            {
                // Retrieve Connection String from App.config
                string connectionString = ConfigurationManager.ConnectionStrings["pgso.Properties.Settings.strCon"].ConnectionString;
                strCon = new SqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                throw new Exception("Database connection initialization failed: " + ex.Message);
            }
        }
        // public SqlConnection strCon = new SqlConnection(ConfigurationManager.ConnectionStrings["pgso.Properties.Settings.strCon"].ConnectionString.ToString());
    }
}
