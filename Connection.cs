using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace pgso_connect//pinalitan ko namespaces. From pgso to pgso_connect
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
    }
}


/*
namespace pgso_connect //pinalitan ko namespaces. From pgso to pgso_connect
{
    class Connection
    {
        public SqlConnection strCon = new SqlConnection(ConfigurationManager.ConnectionStrings["pgso.Properties.Settings.strCon"].ConnectionString.ToString());
    }
}
*/