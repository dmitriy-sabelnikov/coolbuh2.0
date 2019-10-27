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
    public class UST6Repository
    {
        private SqlConnection conn;
        private string spUST6Select = "spUST6Select";
        private string spUST6Delete = "spUST6Delete";
        private string spUST6Clc    = "spUST6Clc";

        public UST6Repository(SqlConnection connection)
        {
            conn = connection;
        }
        private void FillDataRec(SqlDataReader reader, UST6 ust6)
        {
            int resInt = 0;
            DateTime resDate = DateTime.MinValue;
            decimal resDec = 0;

            if (int.TryParse(reader["UST6_Id"].ToString(), out resInt))
            {
                ust6.UST6_Id = resInt;
            }
            if (int.TryParse(reader["UST6_USTCt_Id"].ToString(), out resInt))
            {
                ust6.UST6_USTCt_Id = resInt;
            }
            if (int.TryParse(reader["UST6_ISUKR"].ToString(), out resInt))
            {
                ust6.UST6_ISUKR = resInt;
            }
            if (int.TryParse(reader["UST6_SEX"].ToString(), out resInt))
            {
                ust6.UST6_SEX = resInt;
            }
            ust6.UST6_TIN = reader["UST6_TIN"].ToString();
            ust6.UST6_LName = reader["UST6_LName"].ToString();
            ust6.UST6_FName = reader["UST6_FName"].ToString();
            ust6.UST6_MName = reader["UST6_MName"].ToString();
            if (int.TryParse(reader["UST6_Category_Cd"].ToString(), out resInt))
            {
                ust6.UST6_Category_Cd = resInt;
            }
            if (int.TryParse(reader["UST6_Accr_Cd"].ToString(), out resInt))
            {
                ust6.UST6_Accr_Cd = resInt;
            }
            if (int.TryParse(reader["UST6_Month"].ToString(), out resInt))
            {
                ust6.UST6_Month = resInt;
            }
            if (int.TryParse(reader["UST6_Year"].ToString(), out resInt))
            {
                ust6.UST6_Year = resInt;
            }
            if (int.TryParse(reader["UST6_DisabDays"].ToString(), out resInt))
            {
                ust6.UST6_DisabDays = resInt;
            }
            if (int.TryParse(reader["UST6_NoSalDays"].ToString(), out resInt))
            {
                ust6.UST6_NoSalDays = resInt;
            }
            if (int.TryParse(reader["UST6_EmplDays"].ToString(), out resInt))
            {
                ust6.UST6_EmplDays = resInt;
            }
            if (int.TryParse(reader["UST6_VocDays"].ToString(), out resInt))
            {
                ust6.UST6_VocDays = resInt;
            }
            if (decimal.TryParse(reader["UST6_TotalSm"].ToString(), out resDec))
            {
                ust6.UST6_TotalSm = resDec;
            }
            if (decimal.TryParse(reader["UST6_MaxSm"].ToString(), out resDec))
            {
                ust6.UST6_MaxSm = resDec;
            }
            if (decimal.TryParse(reader["UST6_DiffSm"].ToString(), out resDec))
            {
                ust6.UST6_DiffSm = resDec;
            }
            if (decimal.TryParse(reader["UST6_WithHeldUSTSm"].ToString(), out resDec))
            {
                ust6.UST6_WithHeldUSTSm = resDec;
            }
            if (decimal.TryParse(reader["UST6_AccrUSTSm"].ToString(), out resDec))
            {
                ust6.UST6_AccrUSTSm = resDec;
            }
            if (int.TryParse(reader["UST6_WB"].ToString(), out resInt))
            {
                ust6.UST6_WB = resInt;
            }
            if (int.TryParse(reader["UST6_SpecExp"].ToString(), out resInt))
            {
                ust6.UST6_SpecExp = resInt;
            }
            if (int.TryParse(reader["UST6_PWT"].ToString(), out resInt))
            {
                ust6.UST6_PWT = resInt;
            }
            if (int.TryParse(reader["UST6_NWP"].ToString(), out resInt))
            {
                ust6.UST6_NWP = resInt;
            }
        }
        //Получить таблицу6 ЕСВ
        public List<UST6> GetAllUST6ByParams(int ustct_Id, out string error)
        {
            error = string.Empty;

            List<UST6> ust6s = new List<UST6>();

            if (conn == null)
            {
                error = "conn == null";
                return ust6s;
            }
            if (ustct_Id == 0)
            {
                error = "Не задані вхідні параметри";
                return null;
            }

            SqlCommand command = new SqlCommand(spUST6Select, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@inUST6_USTCt_Id", ustct_Id);
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    UST6 ustCt = new UST6();
                    FillDataRec(reader, ustCt);
                    ust6s.Add(ustCt);
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
            return ust6s;
        }
        //Удалить таблицу6 ЕСВ
        public bool DeleteUST6ByParams(int ustct_Id, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spUST6Delete, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inUST6_USTCt_Id", ustct_Id);
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
        //Рассчитать таблицу 6 ЕСВ
        public bool CalcUST6(int ustct_Id, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            if (ustct_Id == 0 )
            {
                error = "ustct_Id == 0";
                return false;
            }
          
            SqlCommand command = new SqlCommand(spUST6Clc, conn);
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
