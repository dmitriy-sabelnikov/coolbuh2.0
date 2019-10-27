using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace BLL
{
    public class InitSqlDB
    {

        public static bool IsExistsTableSetup(SqlConnection sqlConnection, out string error)
        {
            error = string.Empty;
            bool bRet = false;
            if (sqlConnection == null)
            {
                error = "sqlConnection == null";
                return bRet;
            }
            try
            {
                SqlCommand cmd = new SqlCommand("select coalesce(OBJECT_ID(N'[SetupApp]','U'),0)");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection;;
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    bRet =  reader.GetInt32(0) == 0 ? true : false;
                }
                reader.Close();
            }
            catch (Exception e)
            {
                error = e.Message;
                bRet = false;
            }
            return bRet;
        }
        public static bool CreateDBIfNotExists(SqlConnection sqlConnection, out string error)
        {
            error = string.Empty;
            if (sqlConnection == null)
            {
                error = "sqlConnection == null";
                return false;
            }
            try
            {
                SqlCommand cmd = new SqlCommand("IF DB_ID (N'coolbuh') IS NULL CREATE DATABASE[coolbuh]");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                error = e.Message;
                return false;
            }
            return true;
        }
    }
}
