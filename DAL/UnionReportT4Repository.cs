using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnionReportT4Repository
    {
        private SqlConnection conn;
        private string spUnionReportT4Select = "spUnionReportT4Select";
        private string spUnionReportT4Delete = "spUnionReportT4Delete";
        private string spUnionReportT4Clc = "spUnionReportT4Clc";


        public UnionReportT4Repository(SqlConnection connection)
        {
            conn = connection;
        }

        #region Private methods

        private void FillDataRec(SqlDataReader reader, UnionReportT4 unionReportT4)
        {
            int resInt = 0;
            DateTime resDate = DateTime.MinValue;

            if (int.TryParse(reader["UnionReportT4_Id"].ToString(), out resInt))
            {
                unionReportT4.UnionReportT4_Id = resInt;
            }
            if (int.TryParse(reader["UnionReportT4_CtId"].ToString(), out resInt))
            {
                unionReportT4.UnionReportT4_CtId = resInt;
            }
            if (DateTime.TryParse(reader["UnionReportT4_Date"].ToString(), out resDate))
            {
                unionReportT4.UnionReportT4_Date = resDate;
            }
            if (int.TryParse(reader["UnionReportT4_ExportFile"].ToString(), out resInt))
            {
                unionReportT4.UnionReportT4_ExportFile = resInt;
            }
            if (int.TryParse(reader["UnionReportT4_ISUKR"].ToString(), out resInt))
            {
                unionReportT4.UnionReportT4_ISUKR = resInt;
            }
            unionReportT4.UnionReportT4_TIN = reader["UnionReportT4_TIN"].ToString();
            unionReportT4.UnionReportT4_LName = reader["UnionReportT4_LName"].ToString();
            unionReportT4.UnionReportT4_FName = reader["UnionReportT4_FName"].ToString();
            unionReportT4.UnionReportT4_MName = reader["UnionReportT4_MName"].ToString();
            unionReportT4.UnionReportT4_C_Pid = reader["UnionReportT4_C_Pid"].ToString();
            if (int.TryParse(reader["UnionReportT4_Start_Days"].ToString(), out resInt))
            {
                unionReportT4.UnionReportT4_Start_Days = resInt;
            }
            if (int.TryParse(reader["UnionReportT4_Stop_Days"].ToString(), out resInt))
            {
                unionReportT4.UnionReportT4_Stop_Days = resInt;
            }
            if (int.TryParse(reader["UnionReportT4_Days"].ToString(), out resInt))
            {
                unionReportT4.UnionReportT4_Days = resInt;
            }
            if (int.TryParse(reader["UnionReportT4_Hours"].ToString(), out resInt))
            {
                unionReportT4.UnionReportT4_Hours = resInt;
            }
            if (int.TryParse(reader["UnionReportT4_Minutes"].ToString(), out resInt))
            {
                unionReportT4.UnionReportT4_Minutes = resInt;
            }
            if (int.TryParse(reader["UnionReportT4_DaysNorm"].ToString(), out resInt))
            {
                unionReportT4.UnionReportT4_DaysNorm = resInt;
            }
            if (int.TryParse(reader["UnionReportT4_HoursNorm"].ToString(), out resInt))
            {
                unionReportT4.UnionReportT4_HoursNorm = resInt;
            }
            if (int.TryParse(reader["UnionReportT4_MinutesNorm"].ToString(), out resInt))
            {
                unionReportT4.UnionReportT4_MinutesNorm = resInt;
            }
            unionReportT4.UnionReportT4_Ord_Num = reader["UnionReportT4_Ord_Num"].ToString();
            if (int.TryParse(reader["UnionReportT4_Ord_Dat"].ToString(), out resInt))
            {
                unionReportT4.UnionReportT4_Ord_Dat = resInt;
            }
            if (int.TryParse(reader["UnionReportT4_SSN"].ToString(), out resInt))
            {
                unionReportT4.UnionReportT4_SSN = resInt;
            }
        }

        #endregion

        //Получить таблицу 4 объединенной ведомости
        public List<UnionReportT4> GetAllUnionReportT4ByParams(int unionReportT4_CtId, out string error)
        {
            error = string.Empty;

            var unionReportT4s = new List<UnionReportT4>();

            if (conn == null)
            {
                error = "conn == null";
                return unionReportT4s;
            }
            if (unionReportT4_CtId == 0)
            {
                error = "Не задані вхідні параметри";
                return null;
            }

            SqlCommand command = new SqlCommand(spUnionReportT4Select, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@inUnionReportT4_CtId", unionReportT4_CtId);
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var unionReportT4 = new UnionReportT4();
                    FillDataRec(reader, unionReportT4);
                    unionReportT4s.Add(unionReportT4);
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
            return unionReportT4s;
        }

        //Удалить таблицу 4 объединенной ведомости
        public bool DeleteUnionReportT4ByParams(int unionReportT4_CtId, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spUnionReportT4Delete, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inUnionReportT4_CtId", unionReportT4_CtId);
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

        //Рассчитать таблицу 4 объединенной ведомости
        public bool CalcUnionReportT4(int unionReportT4_CtId, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            if (unionReportT4_CtId == 0)
            {
                error = "unionReportT4_CtId == 0";
                return false;
            }

            SqlCommand command = new SqlCommand(spUnionReportT4Clc, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inUnionReportT4_CtId", unionReportT4_CtId);
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
