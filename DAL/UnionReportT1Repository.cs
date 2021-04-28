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
    public class UnionReportT1Repository
    {
        private SqlConnection conn;
        private string spUnionReportT1Select = "spUnionReportT1Select";
        private string spUnionReportT1Delete = "spUnionReportT1Delete";
        private string spUnionReportT1Clc    = "spUnionReportT1Clc";

        public UnionReportT1Repository(SqlConnection connection)
        {
            conn = connection;
        }

        #region Private methods

        private void FillDataRec(SqlDataReader reader, UnionReportT1 unionReportT1)
        {
            int resInt = 0;
            DateTime resDate = DateTime.MinValue;
            decimal resDec = 0;

            if (int.TryParse(reader["UnionReportT1_Id"].ToString(), out resInt))
            {
                unionReportT1.UnionReportT1_Id = resInt;
            }
            if (int.TryParse(reader["UnionReportT1_CtId"].ToString(), out resInt))
            {
                unionReportT1.UnionReportT1_CtId = resInt;
            }
            if (DateTime.TryParse(reader["UnionReportT1_Date"].ToString(), out resDate))
            {
                unionReportT1.UnionReportT1_Date = resDate;
            }
            if (int.TryParse(reader["UnionReportT1_ExportFile"].ToString(), out resInt))
            {
                unionReportT1.UnionReportT1_ExportFile = resInt;
            }
            if (int.TryParse(reader["UnionReportT1_ISUKR"].ToString(), out resInt))
            {
                unionReportT1.UnionReportT1_ISUKR = resInt;
            }
            if (int.TryParse(reader["UnionReportT1_SEX"].ToString(), out resInt))
            {
                unionReportT1.UnionReportT1_SEX = resInt;
            }
            unionReportT1.UnionReportT1_TIN = reader["UnionReportT1_TIN"].ToString();
            unionReportT1.UnionReportT1_LName = reader["UnionReportT1_LName"].ToString();
            unionReportT1.UnionReportT1_FName = reader["UnionReportT1_FName"].ToString();
            unionReportT1.UnionReportT1_MName = reader["UnionReportT1_MName"].ToString();
            if (int.TryParse(reader["UnionReportT1_Category_Cd"].ToString(), out resInt))
            {
                unionReportT1.UnionReportT1_Category_Cd = resInt;
            }
            if (int.TryParse(reader["UnionReportT1_Accr_Cd"].ToString(), out resInt))
            {
                unionReportT1.UnionReportT1_Accr_Cd = resInt;
            }
            if (int.TryParse(reader["UnionReportT1_Month"].ToString(), out resInt))
            {
                unionReportT1.UnionReportT1_Month = resInt;
            }
            if (int.TryParse(reader["UnionReportT1_Year"].ToString(), out resInt))
            {
                unionReportT1.UnionReportT1_Year = resInt;
            }
            if (int.TryParse(reader["UnionReportT1_DisabDays"].ToString(), out resInt))
            {
                unionReportT1.UnionReportT1_DisabDays = resInt;
            }
            if (int.TryParse(reader["UnionReportT1_NoSalDays"].ToString(), out resInt))
            {
                unionReportT1.UnionReportT1_NoSalDays = resInt;
            }
            if (int.TryParse(reader["UnionReportT1_EmplDays"].ToString(), out resInt))
            {
                unionReportT1.UnionReportT1_EmplDays = resInt;
            }
            if (int.TryParse(reader["UnionReportT1_VocDays"].ToString(), out resInt))
            {
                unionReportT1.UnionReportT1_VocDays = resInt;
            }
            if (decimal.TryParse(reader["UnionReportT1_TotalSm"].ToString(), out resDec))
            {
                unionReportT1.UnionReportT1_TotalSm = resDec;
            }
            if (decimal.TryParse(reader["UnionReportT1_MaxSm"].ToString(), out resDec))
            {
                unionReportT1.UnionReportT1_MaxSm = resDec;
            }
            if (decimal.TryParse(reader["UnionReportT1_DiffSm"].ToString(), out resDec))
            {
                unionReportT1.UnionReportT1_DiffSm = resDec;
            }
            if (decimal.TryParse(reader["UnionReportT1_WithHeldUSTSm"].ToString(), out resDec))
            {
                unionReportT1.UnionReportT1_WithHeldUSTSm = resDec;
            }
            if (decimal.TryParse(reader["UnionReportT1_AccrUSTSm"].ToString(), out resDec))
            {
                unionReportT1.UnionReportT1_AccrUSTSm = resDec;
            }
            if (int.TryParse(reader["UnionReportT1_WB"].ToString(), out resInt))
            {
                unionReportT1.UnionReportT1_WB = resInt;
            }
            if (int.TryParse(reader["UnionReportT1_SpecExp"].ToString(), out resInt))
            {
                unionReportT1.UnionReportT1_SpecExp = resInt;
            }
            if (int.TryParse(reader["UnionReportT1_PWT"].ToString(), out resInt))
            {
                unionReportT1.UnionReportT1_PWT = resInt;
            }
            if (int.TryParse(reader["UnionReportT1_NWP"].ToString(), out resInt))
            {
                unionReportT1.UnionReportT1_NWP = resInt;
            }
        }

        #endregion

        //Получить таблицу 1 объединенной ведомости
        public List<UnionReportT1> GetAllUnionReportT1ByParams(int unionReportT1_CtId, out string error)
        {
            error = string.Empty;

            var unionReportT1s = new List<UnionReportT1>();

            if (conn == null)
            {
                error = "conn == null";
                return unionReportT1s;
            }
            if (unionReportT1_CtId == 0)
            {
                error = "Не задані вхідні параметри";
                return null;
            }

            SqlCommand command = new SqlCommand(spUnionReportT1Select, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@inUnionReportT1_CtId", unionReportT1_CtId);
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var unionReportT1 = new UnionReportT1();
                    FillDataRec(reader, unionReportT1);
                    unionReportT1s.Add(unionReportT1);
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
            return unionReportT1s;
        }

        //Удалить таблицу 1 объединенной ведомости
        public bool DeleteUnionReportT1ByParams(int unionReportT1_CtId, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spUnionReportT1Delete, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inUnionReportT1_CtId", unionReportT1_CtId);
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

        //Рассчитать таблицу 1 объединенной ведомости
        public bool CalcUnionReportT1(int unionReportT1_CtId, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            if (unionReportT1_CtId == 0)
            {
                error = "unionReportT1_CtId == 0";
                return false;
            }

            SqlCommand command = new SqlCommand(spUnionReportT1Clc, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inUnionReportT1_CtId", unionReportT1_CtId);
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
