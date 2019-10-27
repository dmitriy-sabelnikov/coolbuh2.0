using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;


namespace DAL
{
    public class DBServer
    {
        SqlConnection sqlConn = null;
        OleDbConnection oleDbConn = null;

        public SqlConnection GetConnectionSqlDb()
        {
            return sqlConn;
        }
        public OleDbConnection GetConnectionOleDb()
        {
            return oleDbConn;
        }

        public bool ConnectToSqlDB(string connectionString, out string errors)
        {
            errors = string.Empty;
            try
            {
                sqlConn = new SqlConnection(connectionString);
                sqlConn.Open();
                return true;
            }
            catch (Exception ex)
            {
                errors  = ex.Message;
                return false;
            }
        }
        public bool ConnectToOleDB(string connectionString, out string errors)
        {
            errors = string.Empty;
            try
            {
                oleDbConn = new OleDbConnection(connectionString);
                oleDbConn.Open();
                return true;
            }
            catch (Exception ex)
            {
                errors = ex.Message;
                return false;
            }
        }

        public bool DisconnectFromSqlDB(out string errors)
        {
            errors = string.Empty;
            try
            {
                sqlConn.Close();
                return true;
            }
            catch (Exception ex)
            {
                errors = ex.Message;
                return false;
            }
        }

        public bool DisconnectFromOleDB(out string errors)
        {
            errors = string.Empty;
            try
            {
                oleDbConn.Close();
                return true;
            }
            catch (Exception ex)
            {
                errors = ex.Message;
                return false;
            }
        }
    }
}
