
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FlBlData
{
    public class SqlData
    {
        //local path or file path
        string connectionString
             = "Data Source=MIYUAKI\SQLEXPRESS;Initial Catalog = followblock; Integrated Security = True:";

        //initializing sql connection
        static SqlConnection connection;

        public SqlData()
        {
            connection = new SqlConnection(connectionString);
        }


    }
}
