using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Data;

namespace BLL
{
    public class SqlSript
    {
        private SqlConnection sqlConn = null;
        public SqlSript(SqlConnection sqlConnection)
        {
            sqlConn = sqlConnection;
        } 
        //Парсинг sql скрипта
        private List<string> GetScriptText(string text)
        {
            int pStartIndex = 0;
            int pFindIndex = 0;
            string pFindText = "GO";

            List<string> sqlText = new List<string>();
            while (pFindIndex != -1)
            {
                pFindIndex = text.IndexOf(pFindText, pStartIndex, StringComparison.Ordinal);
                if (pFindIndex == -1)
                {
                    sqlText.Add(text.Substring(pStartIndex));
                }
                else
                {
                    sqlText.Add(text.Substring(pStartIndex, pFindIndex));
                }
                pStartIndex = pFindIndex + pFindText.Length;
            }
            return sqlText;
        }
        public bool RunScript(string pathWithFilename, out string error)
        {
            error = string.Empty;
            if(sqlConn == null)
            {
                error = "Відсутнє підключення до БД";
                return false;
            }
            if(pathWithFilename == string.Empty)
            {
                error = "Не вказаний путь до файлу";
                return false;
            }
            if(!File.Exists(pathWithFilename))
            {
                error = "Не існує вказанного файлу: "+ pathWithFilename;
                return false;
            }
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConn;
                string script = File.ReadAllText(pathWithFilename, Encoding.GetEncoding("windows-1251"));
                List<string> sqlScript = GetScriptText(script);
                foreach(string scriptText in sqlScript)
                {
                    cmd.CommandText = scriptText;
                    cmd.ExecuteNonQuery();
                }
            }
            catch(Exception e)
            {
                error = e.Message;
                return false;
            }
            return true;
        }
        public bool ExecuteSqlScript(string sqlText, out string error)
        {
            error = string.Empty;
            if (sqlConn == null)
            {
                error = "Відсутнє підключення до БД";
                return false;
            }
            if (sqlText == string.Empty)
            {
                error = "Порожній текст скрипта";
                return false;
            }
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConn;
                cmd.CommandText = sqlText;
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
