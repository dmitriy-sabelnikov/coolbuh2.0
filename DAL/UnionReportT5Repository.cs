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
    public class UnionReportT5Repository
    {
        private SqlConnection conn;
        private string spUnionReportT5Select = "spUnionReportT5Select";
        private string spUnionReportT5Delete = "spUnionReportT5Delete";
        private string spUnionReportT5Clc    = "spUnionReportT5Clc";
        
        public UnionReportT5Repository(SqlConnection connection)
        {
            conn = connection;
        }

        #region Private methods

        private void FillDataRec(SqlDataReader reader, UnionReportT5 unionReportT5)
        {
            int resInt = 0;
            DateTime resDate = DateTime.MinValue;
            decimal resDec = 0;

            if (int.TryParse(reader["UnionReportT5_Id"].ToString(), out resInt))
            {
                unionReportT5.UnionReportT5_Id = resInt;
            }
            if (int.TryParse(reader["UnionReportT5_CtId"].ToString(), out resInt))
            {
                unionReportT5.UnionReportT5_CtId = resInt;
            }
            if(DateTime.TryParse(reader["UnionReportT5_Date"].ToString(), out resDate))
            {
                unionReportT5.UnionReportT5_Date = resDate;
            }
            if (int.TryParse(reader["UnionReportT5_ExportFile"].ToString(), out resInt))
            {
                unionReportT5.UnionReportT5_ExportFile = resInt;
            }
            if (int.TryParse(reader["UnionReportT5_ISUKR"].ToString(), out resInt))
            {
                unionReportT5.UnionReportT5_ISUKR = resInt;
            }
            unionReportT5.UnionReportT5_TIN = reader["UnionReportT5_TIN"].ToString();
            unionReportT5.UnionReportT5_LName = reader["UnionReportT5_LName"].ToString();
            unionReportT5.UnionReportT5_FName = reader["UnionReportT5_FName"].ToString();
            unionReportT5.UnionReportT5_MName = reader["UnionReportT5_MName"].ToString();
            if (int.TryParse(reader["UnionReportT5_Category_Cd"].ToString(), out resInt))
            {
                unionReportT5.UnionReportT5_Category_Cd = resInt;
            }
            if (int.TryParse(reader["UnionReportT5_MaterialAidStart"].ToString(), out resInt))
            {
                unionReportT5.UnionReportT5_MaterialAidStart = resInt;
            }
            if (int.TryParse(reader["UnionReportT5_MaterialAidEnd"].ToString(), out resInt))
            {
                unionReportT5.UnionReportT5_MaterialAidEnd = resInt;
            }
            if (int.TryParse(reader["UnionReportT5_Accr_Cd"].ToString(), out resInt))
            {
                unionReportT5.UnionReportT5_Accr_Cd = resInt;
            }
            if (int.TryParse(reader["UnionReportT5_Month"].ToString(), out resInt))
            {
                unionReportT5.UnionReportT5_Month = resInt;
            }
            if (int.TryParse(reader["UnionReportT5_Year"].ToString(), out resInt))
            {
                unionReportT5.UnionReportT5_Year = resInt;
            }
            if (decimal.TryParse(reader["UnionReportT5_TotalSm"].ToString(), out resDec))
            {
                unionReportT5.UnionReportT5_TotalSm = resDec;
            }
            if (decimal.TryParse(reader["UnionReportT5_MaxSm"].ToString(), out resDec))
            {
                unionReportT5.UnionReportT5_MaxSm = resDec;
            }
            if (decimal.TryParse(reader["UnionReportT1_AccrUSTSm"].ToString(), out resDec))
            {
                unionReportT5.UnionReportT1_AccrUSTSm = resDec;
            }
        }

        #endregion

        //Получить таблицу 5 объединенной ведомости
        public List<UnionReportT5> GetAllUnionReportT5ByParams(int unionReportT5_CtId, out string error)
        {
            error = string.Empty;

            var unionReportT5s = new List<UnionReportT5>();

            if (conn == null)
            {
                error = "conn == null";
                return unionReportT5s;
            }
            if (unionReportT5_CtId == 0)
            {
                error = "Не задані вхідні параметри";
                return null;
            }

            SqlCommand command = new SqlCommand(spUnionReportT5Select, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@inUnionReportT5_CtId", unionReportT5_CtId);
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var unionReportT5 = new UnionReportT5();
                    FillDataRec(reader, unionReportT5);
                    unionReportT5s.Add(unionReportT5);
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
            return unionReportT5s;
        }

        //Удалить таблицу 5 объединенной ведомости
        public bool DeleteUnionReportT5ByParams(int unionReportT5_CtId, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spUnionReportT5Delete, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inUnionReportT5_CtId", unionReportT5_CtId);
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

        //Рассчитать таблицу 5 объединенной ведомости
        public bool CalcUnionReportT5(int unionReportT5_CtId, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            if (unionReportT5_CtId == 0)
            {
                error = "unionReportT5_CtId == 0";
                return false;
            }

            SqlCommand command = new SqlCommand(spUnionReportT5Clc, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inUnionReportT5_CtId", unionReportT5_CtId);
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
