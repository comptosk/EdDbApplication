using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace EdDbLib {

    public class Connection {

        public SqlConnection sqlConnection { get; set; } = null;
        public string connStr = null;

        public Connection(string server, string instance, string database) {
            connStr = $"server={server}\\{instance};" + $"database={database};" + $"trusted_connection=true;";
            sqlConnection = new SqlConnection(connStr);
            sqlConnection.Open();
            if(sqlConnection.State != System.Data.ConnectionState.Open) {
                throw new Exception("Connection failed. Check parameters.");
            }
            
        }
        public void Close() {
            if(sqlConnection != null) {
                sqlConnection.Close();
                sqlConnection = null;
            }
        }
    }
}
