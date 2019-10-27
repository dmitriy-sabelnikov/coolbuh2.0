using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entities;

namespace DAL
{
    public class RefSocBenefitRepository
    {
        private SqlConnection conn;
        private string spRefSocBenefitSelect = "spRefSocBenefitSelect";
        private string spRefSocBenefitInsert = "spRefSocBenefitInsert";
        private string spRefSocBenefitUpdate = "spRefSocBenefitUpdate";
        private string spRefSocBenefitDelete = "spRefSocBenefitDelete";
        public RefSocBenefitRepository(SqlConnection connection)
        {
            conn = connection;
        }
        private void FillDataRec(SqlDataReader reader, RefSocBenefit RefSocBenefit)
        {
            int resInt = 0;
            DateTime resDate = DateTime.MinValue;
            decimal resDec = 0;
            if (int.TryParse(reader["RefSocBenefit_Id"].ToString(), out resInt))
            {
                RefSocBenefit.RefSocBenefit_Id = resInt;
            }
            if (DateTime.TryParse(reader["RefSocBenefit_PerBeg"].ToString(), out resDate))
            {
                RefSocBenefit.RefSocBenefit_PerBeg = resDate;
            }
            if (DateTime.TryParse(reader["RefSocBenefit_PerEnd"].ToString(), out resDate))
            {
                RefSocBenefit.RefSocBenefit_PerEnd = resDate;
            }
            if (decimal.TryParse(reader["RefSocBenefit_Sm"].ToString(), out resDec))
            {
                RefSocBenefit.RefSocBenefit_Sm = resDec;
            }
            if (decimal.TryParse(reader["RefSocBenefit_LimSm"].ToString(), out resDec))
            {
                RefSocBenefit.RefSocBenefit_LimSm = resDec;
            }
        }
        //Получить интервалы социальной льготы
        public List<RefSocBenefit> GetAllRefSocBenefits(out string error)
        {
            error = string.Empty;

            List<RefSocBenefit> refSocBenefits = new List<RefSocBenefit>();

            if (conn == null)
            {
                error = "conn == null";
                return refSocBenefits;
            }

            SqlCommand command = new SqlCommand(spRefSocBenefitSelect, conn);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    RefSocBenefit refMinSalary = new RefSocBenefit();
                    FillDataRec(reader, refMinSalary);
                    refSocBenefits.Add(refMinSalary);
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
            return refSocBenefits;
        }
        //Добавить интервал социальной льготы
        public int AddRefSocBenefit(RefSocBenefit refSocBenefit, out string error)
        {
            error = string.Empty;
            if (refSocBenefit == null)
            {
                error = "refSocBenefit == null";
                return 0;
            }
            if (conn == null)
            {
                error = "conn == null";
                return 0;
            }
            SqlCommand command = new SqlCommand(spRefSocBenefitInsert, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inRefSocBenefit_PerBeg",
                refSocBenefit.RefSocBenefit_PerBeg == DateTime.MinValue ? Convert.DBNull : refSocBenefit.RefSocBenefit_PerBeg);
            command.Parameters.AddWithValue("@inRefSocBenefit_PerEnd",
                refSocBenefit.RefSocBenefit_PerEnd == DateTime.MinValue ? Convert.DBNull : refSocBenefit.RefSocBenefit_PerEnd);
            command.Parameters.AddWithValue("@inRefSocBenefit_Sm", refSocBenefit.RefSocBenefit_Sm);
            command.Parameters.AddWithValue("@inRefSocBenefit_LimSm", refSocBenefit.RefSocBenefit_LimSm);
            // определяем выходной параметр
            SqlParameter outId = new SqlParameter
            {
                ParameterName = "outId",
                Direction = ParameterDirection.Output,
                SqlDbType = SqlDbType.Int
            };
            command.Parameters.Add(outId);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return 0;
            }
            int id = 0;
            int.TryParse(command.Parameters["outId"].Value.ToString(), out id);
            return id;
        }
        //Изменить интервал прожиточного минимума
        public bool ModifyRefSocBenefit(RefSocBenefit refSocBenefit, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            if (refSocBenefit == null)
            {
                error = "refSocBenefit == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spRefSocBenefitUpdate, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inRefSocBenefit_Id", refSocBenefit.RefSocBenefit_Id);
            command.Parameters.AddWithValue("@inRefSocBenefit_PerBeg",
                refSocBenefit.RefSocBenefit_PerBeg == DateTime.MinValue ? Convert.DBNull : refSocBenefit.RefSocBenefit_PerBeg);
            command.Parameters.AddWithValue("@inRefSocBenefit_PerEnd",
                refSocBenefit.RefSocBenefit_PerEnd == DateTime.MinValue ? Convert.DBNull : refSocBenefit.RefSocBenefit_PerEnd);
            command.Parameters.AddWithValue("@inRefSocBenefit_Sm", refSocBenefit.RefSocBenefit_Sm);
            command.Parameters.AddWithValue("@inRefSocBenefit_LimSm", refSocBenefit.RefSocBenefit_LimSm);
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
        //Удалить интервал прожиточного минимума
        public bool DeleteRefSocBenefit(int id, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spRefSocBenefitDelete, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inRefSocBenefit_Id", id);
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
