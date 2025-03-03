using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;




namespace pgso
{
    class Connection
    {
        public SqlConnection strCon = new SqlConnection(ConfigurationManager.ConnectionStrings["pgso.Properties.Settings.strCon"].ConnectionString.ToString());
    }
}
