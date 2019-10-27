using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Globalization;

namespace BLL
{
    public class ConvertDbfToSql
    {
        private SqlConnection sqlConn = null;
        private OleDbConnection oleDbConn = null;
        private bool isNeedConvertCp1252To866 = false;
        private string prefix = ""; //префикс создаваемой таблицы

        public ConvertDbfToSql(SqlConnection sqlConnection, OleDbConnection oleDbconnection, bool isNeedConvertCp1252To866, string prefix = "")
        {
            sqlConn   = sqlConnection;
            oleDbConn = oleDbconnection;
            this.isNeedConvertCp1252To866 = isNeedConvertCp1252To866;
            this.prefix = prefix;
        }
        //Конвертация DBF в SQL
        public bool ConvertDBFToSQL(string dbfFileName, out string errors)
        {
            errors = String.Empty;

            if (sqlConn == null)
            {
                errors = "SqlConnection sqlConn = null";
                return false;
            }
            if (oleDbConn == null)
            {
                errors = " OleDbConnection oleDbConn = null";
                return false;
            }

            if (dbfFileName == String.Empty)
            {
                errors = "dbfFileName == empty";
                return false;
            }
            try
            {
                OleDbCommand command = new OleDbCommand("select * from " + dbfFileName, oleDbConn);
                DataTable dt = new DataTable();
                dt.Load(command.ExecuteReader());
                if (isNeedConvertCp1252To866)
                  ConvertDataTableStrings(dt);
                string sqlText = SqlTextForCreateTable(dt, prefix+dbfFileName);
                if (ExecQuery(sqlText, out errors))
                {
                    SqlBulkCopy sqlcpy = new SqlBulkCopy(sqlConn);
                    sqlcpy.DestinationTableName = prefix + dbfFileName;
                    sqlcpy.WriteToServer(dt);
                }
            }
            catch (Exception exception)
            {
                errors  = exception.Message;
                return false;
            }
            return true;
        }

        private string ConvertToCp866(string text)
        {
            return Encoding.GetEncoding(866).GetString(Encoding.GetEncoding(1252).GetBytes(text));
        }
        private void ConvertDataTableStrings (DataTable dt)
        {
            int columnsCount = dt.Columns.Count;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < columnsCount; j++)
                {
                    if (dt.Columns[j].DataType.ToString() == "System.String")
                    {
                        string convertString = ConvertToCp866(dt.Rows[i].ItemArray[j].ToString());
                        dt.Rows[i].SetField(dt.Columns[j], convertString);
                    }
                    
                }
            }
        }
        private string SqlTextForCreateTable(DataTable dt, string tablename)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[" + tablename + "]') AND type in (N'U'))");
            sql.AppendLine("   DROP TABLE [dbo].[" + tablename + "]");
            sql.AppendLine("BEGIN");
            sql.AppendLine("create table " + tablename + "");
            sql.AppendLine("(");
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                sql.Append(dt.Columns[i].ColumnName);
                string columnType = dt.Columns[i].DataType.ToString();
                switch (columnType)
                {
                    case "System.Int32":
                        sql.Append(" int");
                        break;
                    case "System.Int64":
                        sql.Append(" bigint");
                        break;
                    case "System.Int16":
                        sql.Append(" smallint");
                        break;
                    case "System.Byte":
                        sql.Append(" tinyint");
                        break;
                    case "System.Decimal":
                        sql.Append(" decimal");
                        break;
                    case "System.DateTime":
                        sql.Append(" datetime");
                        break;
                    case "System.String":
                    default:
                        sql.AppendFormat(" nvarchar({0})", dt.Columns[i].MaxLength == -1 ? "max" : dt.Columns[i].MaxLength.ToString());
                        break;
                }
                if (i < dt.Columns.Count - 1)
                    sql.AppendLine(",");
                else
                    sql.AppendLine("");

            }
            sql.AppendLine(")");
            sql.AppendLine("END");
            return sql.ToString();
        }
        private bool ExecQuery(string sql, out string errors)
        {
            errors = string.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Connection = sqlConn;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception error)
            {
                errors  = error.Message;
            }
            return false;
        }
    }
}
