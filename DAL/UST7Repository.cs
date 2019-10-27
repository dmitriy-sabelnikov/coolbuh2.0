using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entities;
using System.Data;

namespace DAL
{
    public class UST7Repository
    {
        private SqlConnection conn;
        private string spUST7Select = "spUST7Select";
        private string spUST7Delete = "spUST7Delete";
        private string spUST7Clc = "spUST7Clc";

        public UST7Repository(SqlConnection connection)
        {
            conn = connection;
        }

        private void FillDataRec(SqlDataReader reader, UST7 ust7)
        {
            int resInt = 0;
            if (int.TryParse(reader["UST7_Id"].ToString(), out resInt))
            {
                ust7.UST7_Id = resInt;
            }
            if (int.TryParse(reader["UST7_USTCt_Id"].ToString(), out resInt))
            {
                ust7.UST7_USTCt_Id = resInt;
            }

            if (int.TryParse(reader["UST7_ISUKR"].ToString(), out resInt))
            {
                ust7.UST7_ISUKR = resInt;
            }
            ust7.UST7_TIN = reader["UST7_TIN"].ToString();
            ust7.UST7_LName = reader["UST7_LName"].ToString();
            ust7.UST7_FName = reader["UST7_FName"].ToString();
            ust7.UST7_MName = reader["UST7_MName"].ToString();
            ust7.UST7_C_Pid = reader["UST7_C_Pid"].ToString();
            if (int.TryParse(reader["UST7_Start_Days"].ToString(), out resInt))
            {
                ust7.UST7_Start_Days = resInt;
            }
            if (int.TryParse(reader["UST7_Stop_Days"].ToString(), out resInt))
            {
                ust7.UST7_Stop_Days = resInt;
            }

            if (int.TryParse(reader["UST7_Days"].ToString(), out resInt))
            {
                ust7.UST7_Days = resInt;
            }
            if (int.TryParse(reader["UST7_Hours"].ToString(), out resInt))
            {
                ust7.UST7_Hours = resInt;
            }
            if (int.TryParse(reader["UST7_Minutes"].ToString(), out resInt))
            {
                ust7.UST7_Minutes = resInt;
            }
            if (int.TryParse(reader["UST7_Norm"].ToString(), out resInt))
            {
                ust7.UST7_Norm = resInt;
            }
            ust7.UST7_Ord_Num = reader["UST7_Ord_Num"].ToString();
            if (int.TryParse(reader["UST7_Ord_Dat"].ToString(), out resInt))
            {
                ust7.UST7_Ord_Dat = resInt;
            }
            if (int.TryParse(reader["UST7_SSN"].ToString(), out resInt))
            {
                ust7.UST7_SSN = resInt;
            }
        }
        //Получить таблицу7 ЕСВ
        public List<UST7> GetAllUST7ByParams(int ustct_Id, out string error)
        {
            error = string.Empty;

            List<UST7> ust7s = new List<UST7>();

            if (conn == null)
            {
                error = "conn == null";
                return ust7s;
            }
            if (ustct_Id == 0)
            {
                error = "Не задані вхідні параметри";
                return null;
            }

            SqlCommand command = new SqlCommand(spUST7Select, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@inUST7_USTCt_Id", ustct_Id);
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    UST7 ustCt = new UST7();
                    FillDataRec(reader, ustCt);
                    ust7s.Add(ustCt);
                }
            }
            catch (Exception exc)
            {
                error = exc.Message;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
            return ust7s;
        }
        //Удалить таблицу7 ЕСВ
        public bool DeleteUST7ByParams(int ustct_Id, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spUST7Delete, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inUST7_USTCt_Id", ustct_Id);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            return true;
        }
        //Рассчитать таблицу 7 ЕСВ
        public bool CalcUST7(int ustct_Id, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            if (ustct_Id == 0)
            {
                error = "ustct_Id == 0";
                return false;
            }

            SqlCommand command = new SqlCommand(spUST7Clc, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inUSTCt_Id", ustct_Id);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            return true;
        }
    }
}
