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
    public class ACSRepository
    {
        private SqlConnection conn;
        private string spACSSelect = "spACSSelect";
        public ACSRepository(SqlConnection connection)
        {
            conn = connection;
        }
        private void FillDataRec(SqlDataReader reader, ACS acs)
        {
            int resInt = 0;
            DateTime resDate = DateTime.MinValue;
            decimal resDec = 0;

            if (int.TryParse(reader["PersCard_Id"].ToString(), out resInt))
            {
                acs.PersCard_Id = resInt;
            }
            acs.PersCard_LName = reader["PersCard_LName"].ToString();
            acs.PersCard_FName = reader["PersCard_FName"].ToString();
            acs.PersCard_MName = reader["PersCard_MName"].ToString();
            acs.PersCard_TIN = reader["PersCard_TIN"].ToString();
            if (int.TryParse(reader["PersCard_Exp"].ToString(), out resInt))
            {
                acs.PersCard_Exp = resInt;
            }
            if (int.TryParse(reader["PersCard_Grade"].ToString(), out resInt))
            {
                acs.PersCard_Grade = resInt;
            }
            if (DateTime.TryParse(reader["PersCard_DOB"].ToString(), out resDate))
            {
                acs.PersCard_DOB = resDate;
            }
            if (DateTime.TryParse(reader["PersCard_DOR"].ToString(), out resDate))
            {
                acs.PersCard_DOR = resDate;
            }
            if (DateTime.TryParse(reader["PersCard_DOD"].ToString(), out resDate))
            {
                acs.PersCard_DOD = resDate;
            }
            if (DateTime.TryParse(reader["PersCard_DOP"].ToString(), out resDate))
            {
                acs.PersCard_DOP = resDate;
            }
            if (int.TryParse(reader["PersCard_Sex"].ToString(), out resInt))
            {
                acs.PersCard_Sex = resInt;
            }
            if (int.TryParse(reader["CardStatus_Type"].ToString(), out resInt))
            {
                acs.CardStatus_Type = resInt;
            }
            if (int.TryParse(reader["Disability_Attr"].ToString(), out resInt))
            {
                acs.Disability_Attr = resInt;
            }
            if (int.TryParse(reader["Child_Count"].ToString(), out resInt))
            {
                acs.Child_Count = resInt;
            }
            if (int.TryParse(reader["Salary_Days"].ToString(), out resInt))
            {
                acs.Salary_Days = resInt;
            }
            if (decimal.TryParse(reader["Salary_Hours"].ToString(), out resDec))
            {
                acs.Salary_Hours = resDec;
            }
            if (decimal.TryParse(reader["Salary_BaseSm"].ToString(), out resDec))
            {
                acs.Salary_BaseSm = resDec;
            }
            if (decimal.TryParse(reader["Salary_PensSm"].ToString(), out resDec))
            {
                acs.Salary_PensSm = resDec;
            }
            if (decimal.TryParse(reader["Salary_GradeSm"].ToString(), out resDec))
            {
                acs.Salary_GradeSm = resDec;
            }
            if (decimal.TryParse(reader["Salary_ExpSm"].ToString(), out resDec))
            {
                acs.Salary_ExpSm = resDec;
            }
            if (decimal.TryParse(reader["Salary_OthSm"].ToString(), out resDec))
            {
                acs.Salary_OthSm = resDec;
            }
            if (decimal.TryParse(reader["Salary_KTU"].ToString(), out resDec))
            {
                acs.Salary_KTU = resDec;
            }
            if (decimal.TryParse(reader["Salary_KTUSm"].ToString(), out resDec))
            {
                acs.Salary_KTUSm = resDec;
            }
            if (decimal.TryParse(reader["Salary_ResSm"].ToString(), out resDec))
            {
                acs.Salary_ResSm = resDec;
            }
            if (int.TryParse(reader["SickList_DaysEntprs"].ToString(), out resInt))
            {
                acs.SickList_DaysEntprs = resInt;
            }
            if (decimal.TryParse(reader["SickList_SmEntprs"].ToString(), out resDec))
            {
                acs.SickList_SmEntprs = resDec;
            }
            if (int.TryParse(reader["SickList_DaysSocInsrnc"].ToString(), out resInt))
            {
                acs.SickList_DaysSocInsrnc = resInt;
            }
            if (decimal.TryParse(reader["SickList_SmSocInsrnc"].ToString(), out resDec))
            {
                acs.SickList_SmSocInsrnc = resDec;
            }
            if (int.TryParse(reader["SickList_DaysTmpDis"].ToString(), out resInt))
            {
                acs.SickList_DaysTmpDis = resInt;
            }
            if (decimal.TryParse(reader["SickList_ResSm"].ToString(), out resDec))
            {
                acs.SickList_ResSm = resDec;
            }
            if (int.TryParse(reader["Vocation_Days"].ToString(), out resInt))
            {
                acs.Vocation_Days = resInt;
            }
            if (decimal.TryParse(reader["Vocation_Sm"].ToString(), out resDec))
            {
                acs.Vocation_Sm = resDec;
            }
            if (int.TryParse(reader["LawContract_Days"].ToString(), out resInt))
            {
                acs.LawContract_Days = resInt;
            }
            if (decimal.TryParse(reader["LawContract_Sm"].ToString(), out resDec))
            {
                acs.LawContract_Sm = resDec;
            }
            if (decimal.TryParse(reader["AddAccr_SmClc"].ToString(), out resDec))
            {
                acs.AddAccr_SmClc = resDec;
            }
            if (decimal.TryParse(reader["AddAccr_SmNoClc"].ToString(), out resDec))
            {
                acs.AddAccr_SmNoClc = resDec;
            }
            if (decimal.TryParse(reader["Tax_Sm"].ToString(), out resDec))
            {
                acs.Tax_Sm = resDec;
            }
            if (decimal.TryParse(reader["SalBalance_BegMonthSm"].ToString(), out resDec))
            {
                acs.SalBalance_BegMonthSm = resDec;
            }
            if (decimal.TryParse(reader["SalBalance_EndMonthSm"].ToString(), out resDec))
            {
                acs.SalBalance_EndMonthSm = resDec;
            }
            if (decimal.TryParse(reader["Prof_Sm"].ToString(), out resDec))
            {
                acs.Prof_Sm = resDec;
            }
            if (decimal.TryParse(reader["Military_Sm"].ToString(), out resDec))
            {
                acs.Military_Sm = resDec;
            }
            if (decimal.TryParse(reader["IncTax_Sm"].ToString(), out resDec))
            {
                acs.IncTax_Sm = resDec;
            }
            if (decimal.TryParse(reader["CashBox_Sm"].ToString(), out resDec))
            {
                acs.CashBox_Sm = resDec;
            }
            if (decimal.TryParse(reader["Excerpt_Sm"].ToString(), out resDec))
            {
                acs.Excerpt_Sm = resDec;
            }
            if (decimal.TryParse(reader["list_Sm"].ToString(), out resDec))
            {
                acs.list_Sm = resDec;
            }
            if (decimal.TryParse(reader["InKindPay_Sm"].ToString(), out resDec))
            {
                acs.InKindPay_Sm = resDec;
            }
            if (decimal.TryParse(reader["AddPayment_Sm"].ToString(), out resDec))
            {
                acs.AddPayment_Sm = resDec;
            }
    }
    //Получить список доп начислений
    public List<ACS> GetAllACSByParam(DateTime datClc, out string error)
        {
            error = string.Empty;

            List<ACS> acses = new List<ACS>();

            if (conn == null)
            {
                error = "conn == null";
                return acses;
            }
            if(datClc == DateTime.MinValue)
            {
                error = "datClc == DateTime.MinValue";
                return acses;
            }

            SqlCommand command = new SqlCommand(spACSSelect, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@inDate_Clc", datClc);

            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ACS acs = new ACS();
                    FillDataRec(reader, acs);
                    acses.Add(acs);
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
            return acses;
        }
    }
}
