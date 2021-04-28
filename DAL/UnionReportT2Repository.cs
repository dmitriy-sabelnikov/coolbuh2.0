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
    public class UnionReportT2Repository
    {
        private SqlConnection conn;
        private string spUnionReportT2Select = "spUnionReportT2Select";
        private string spUnionReportT2Delete = "spUnionReportT2Delete";
        private string spUnionReportT2Clc = "spUnionReportT2Clc";

        public UnionReportT2Repository(SqlConnection connection)
        {
            conn = connection;
        }

        #region Private methods

        private void FillDataRec(SqlDataReader reader, UnionReportT2 unionReportT2)
        {
            int resInt = 0;
            DateTime resDate = DateTime.MinValue;
            decimal resDec = 0;

            if (int.TryParse(reader["UnionReportT2_Id"].ToString(), out resInt))
            {
                unionReportT2.UnionReportT2_Id = resInt;
            }
            if (int.TryParse(reader["UnionReportT2_CtId"].ToString(), out resInt))
            {
                unionReportT2.UnionReportT2_CtId = resInt;
            }
            unionReportT2.UnionReportT2_USREOU = reader["UnionReportT2_USREOU"].ToString();

            if (int.TryParse(reader["UnionReportT2_Type"].ToString(), out resInt))
            {
                unionReportT2.UnionReportT2_Type = resInt;
            }
            unionReportT2.UnionReportT2_TIN = reader["UnionReportT2_TIN"].ToString();
            unionReportT2.UnionReportT2_LName = reader["UnionReportT2_LName"].ToString();
            unionReportT2.UnionReportT2_FName = reader["UnionReportT2_FName"].ToString();
            unionReportT2.UnionReportT2_MName = reader["UnionReportT2_MName"].ToString();
            if (decimal.TryParse(reader["UnionReportT2_AccrIncSm"].ToString(), out resDec))
            {
                unionReportT2.UnionReportT2_AccrIncSm = resDec;
            }
            if (decimal.TryParse(reader["UnionReportT2_PaidIncSm"].ToString(), out resDec))
            {
                unionReportT2.UnionReportT2_PaidIncSm = resDec;
            }
            if (decimal.TryParse(reader["UnionReportT2_AccrTaxSm"].ToString(), out resDec))
            {
                unionReportT2.UnionReportT2_AccrTaxSm = resDec;
            }
            if (decimal.TryParse(reader["UnionReportT2_TransfTaxSm"].ToString(), out resDec))
            {
                unionReportT2.UnionReportT2_TransfTaxSm = resDec;
            }
            if (int.TryParse(reader["UnionReportT2_IncFlg"].ToString(), out resInt))
            {
                unionReportT2.UnionReportT2_IncFlg = resInt;
            }
            if (DateTime.TryParse(reader["UnionReportT2_DOR"].ToString(), out resDate))
            {
                unionReportT2.UnionReportT2_DOR = resDate;
            }
            if (DateTime.TryParse(reader["UnionReportT2_DOD"].ToString(), out resDate))
            {
                unionReportT2.UnionReportT2_DOD = resDate;
            }
            if (int.TryParse(reader["UnionReportT2_SocBenefitFlg"].ToString(), out resInt))
            {
                unionReportT2.UnionReportT2_SocBenefitFlg = resInt;
            }
            if (decimal.TryParse(reader["UnionReportT2_AccrWarTaxSm"].ToString(), out resDec))
            {
                unionReportT2.UnionReportT2_AccrWarTaxSm = resDec;
            }
            if (decimal.TryParse(reader["UnionReportT2_TransWarTaxSm"].ToString(), out resDec))
            {
                unionReportT2.UnionReportT2_TransWarTaxSm = resDec;
            }
        }

        #endregion

        //Получить таблицу 2 объединенной ведомости
        public List<UnionReportT2> GetAllUnionReportT2ByParams(int unionReportT2_CtId, out string error)
        {
            error = string.Empty;

            var unionReportT2s = new List<UnionReportT2>();

            if (conn == null)
            {
                error = "conn == null";
                return unionReportT2s;
            }
            if (unionReportT2_CtId == 0)
            {
                error = "Не задані вхідні параметри";
                return null;
            }

            SqlCommand command = new SqlCommand(spUnionReportT2Select, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@inUnionReportT2_CtId", unionReportT2_CtId);
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var unionReportT2 = new UnionReportT2();
                    FillDataRec(reader, unionReportT2);
                    unionReportT2s.Add(unionReportT2);
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
            return unionReportT2s;
        }

        //Удалить таблицу 2 объединенной ведомости
        public bool DeleteUnionReportT2ByParams(int unionReportT2_CtId, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spUnionReportT2Delete, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inUnionReportT2_CtId", unionReportT2_CtId);
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

        //Рассчитать таблицу 2 объединенной ведомости
        public bool CalcUnionReportT2(int unionReportT2_CtId, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            if (unionReportT2_CtId == 0)
            {
                error = "unionReportT2_CtId == 0";
                return false;
            }

            SqlCommand command = new SqlCommand(spUnionReportT2Clc, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inUnionReportT2_CtId", unionReportT2_CtId);
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
