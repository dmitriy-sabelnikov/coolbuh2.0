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
    public class DFRecRepository
    {
        private SqlConnection conn;
        private string spDFRecSelect = "spDFRecSelect";
        private string spDFRecDelete = "spDFRecDelete";
        private string spDFRecClc = "spDFRecClc";

        public DFRecRepository(SqlConnection connection)
        {
            conn = connection;

        }
        private void FillDataRec(SqlDataReader reader, DFRec dfrec)
        {
            int resInt = 0;
            decimal resDec = 0;
            DateTime resDate = DateTime.MinValue;

            if (int.TryParse(reader["DFRec_Id"].ToString(), out resInt))
            {
                dfrec.DFRec_Id = resInt;
            }
            if (int.TryParse(reader["DFRec_DFCt_Id"].ToString(), out resInt))
            {
                dfrec.DFRec_DFCt_Id = resInt;
            }
            dfrec.DFRec_USREOU = reader["DFRec_USREOU"].ToString();
            if (int.TryParse(reader["DFRec_Type"].ToString(), out resInt))
            {
                dfrec.DFRec_Type = resInt;
            }
            dfrec.DFRec_FName = reader["DFRec_FName"].ToString();
            dfrec.DFRec_MName = reader["DFRec_MName"].ToString();
            dfrec.DFRec_LName = reader["DFRec_LName"].ToString();
            dfrec.DFRec_TIN = reader["DFRec_TIN"].ToString();
            if (decimal.TryParse(reader["DFRec_AccrIncSm"].ToString(), out resDec))
            {
                dfrec.DFRec_AccrIncSm = resDec;
            }
            if (decimal.TryParse(reader["DFRec_PaidIncSm"].ToString(), out resDec))
            {
                dfrec.DFRec_PaidIncSm = resDec;
            }
            if (decimal.TryParse(reader["DFRec_AccrTaxSm"].ToString(), out resDec))
            {
                dfrec.DFRec_AccrTaxSm = resDec;
            }
            if (decimal.TryParse(reader["DFRec_TransfTaxSm"].ToString(), out resDec))
            {
                dfrec.DFRec_TransfTaxSm = resDec;
            }
            if (int.TryParse(reader["DFRec_IncFlg"].ToString(), out resInt))
            {
                dfrec.DFRec_IncFlg = resInt;
            }
            if (DateTime.TryParse(reader["DFRec_DOR"].ToString(), out resDate))
            {
                dfrec.DFRec_DOR = resDate;
            }
            if (DateTime.TryParse(reader["DFRec_DOD"].ToString(), out resDate))
            {
                dfrec.DFRec_DOD = resDate;
            }
            if (int.TryParse(reader["DFRec_SocBenefitFlg"].ToString(), out resInt))
            {
                dfrec.DFRec_SocBenefitFlg = resInt;
            }
            if (int.TryParse(reader["DFRec_Flg"].ToString(), out resInt))
            {
                dfrec.DFRec_Flg = resInt;
            }
        }
        //Получить строки 1 ДФ
        public List<DFRec> GetAllDFRecByParams(int dfct_Id, out string error)
        {
            error = string.Empty;

            List<DFRec> dfRecs = new List<DFRec>();

            if (conn == null)
            {
                error = "conn == null";
                return dfRecs;
            }
            if (dfct_Id == 0)
            {
                error = "Не задані вхідні параметри";
                return null;
            }

            SqlCommand command = new SqlCommand(spDFRecSelect, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@inDFRec_DFCt_Id", dfct_Id);
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    DFRec dfRec = new DFRec();
                    FillDataRec(reader, dfRec);
                    dfRecs.Add(dfRec);
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
            return dfRecs;
        }
        //Удалить строки 1 ДФ
        public bool DeleteDFRecByParams(int dfct_Id, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spDFRecDelete, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inDFRec_DFCt_Id", dfct_Id);
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
        //Рассчитать  строки 1 ДФ
        public bool CalcDFRec(int dfct_Id, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
 
            SqlCommand command = new SqlCommand(spDFRecClc, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inDFCt_Id", dfct_Id);
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
