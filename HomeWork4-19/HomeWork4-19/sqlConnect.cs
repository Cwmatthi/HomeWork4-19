using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace HomeWork4_19
{
    class sqlConnect
    {
        const string connDefault = @"Server=PL7\MTCDB;Database=AdventureWorks2012;User Id=AdvWork2012; Password=pass123;";
        SqlConnection sqlConn;

        private bool DBConnect(string connectionString = "")
        {
            bool returnValue;

            if (connectionString.Length == 0)
                connectionString = connDefault;

            try
            {
                sqlConn = new SqlConnection(connectionString);
                sqlConn.Open();
                returnValue = true;
            }
            catch(Exception ex)
            {
                returnValue = false;
                throw ex;
            }

            return returnValue;
        }

    }
}
