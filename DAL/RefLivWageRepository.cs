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
    public class RefLivWageRepository
    {
        private SqlConnection conn;
        private string spRefLivWageSelect = "spRefLivWageSelect";
        private string spRefLivWageInsert = "spRefLivWageInsert";
        private string spRefLivWageUpdate = "spRefLivWageUpdate";
        private string spRefLivWageDelete = "spRefLivWageDelete";
        public RefLivWageRepository(SqlConnection connection)
        {
            conn = connection;
        }
        private void FillDataRec(SqlDataReader reader, RefLivWage RefLivWage)
        {
            int resInt = 0;
            DateTime resDate = DateTime.MinValue;
            decimal resDec = 0;
            if (int.TryParse(reader["RefLivWage_Id"].ToString(), out resInt))
            {
                RefLivWage.RefLivWage_Id = resInt;
            }
            if (DateTime.TryParse(reader["RefLivWage_PerBeg"].ToString(), out resDate))
            {
                RefLivWage.RefLivWage_PerBeg = resDate;
            }
            if (DateTime.TryParse(reader["RefLivWage_PerEnd"].ToString(), out resDate))
            {
                RefLivWage.RefLivWage_PerEnd = resDate;
            }
            if (decimal.TryParse(reader["RefLivWage_Sm"].ToString(), out resDec))
            {
                RefLivWage.RefLivWage_Sm = resDec;
            }
        }
        //Получить интервалы прожиточного минимума
        public List<RefLivWage> GetAllRefLivWages(out string error)
        {
            error = string.Empty;

            List<RefLivWage> refLivWages = new List<RefLivWage>();

            if (conn == null)
            {
                error = "conn == null";
                return refLivWages;
            }

            SqlCommand command = new SqlCommand(spRefLivWageSelect, conn);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    RefLivWage refMinSalary = new RefLivWage();
                    FillDataRec(reader, refMinSalary);
                    refLivWages.Add(refMinSalary);
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
            return refLivWages;
        }
        //Добавить интервал прожиточного минимума
        public int AddRefLivWage(RefLivWage refLivWage, out string error)
        {
            error = string.Empty;
            if (refLivWage == null)
            {
                error = "refLivWage == null";
                return 0;
            }
            if (conn == null)
            {
                error = "conn == null";
                return 0;
            }
            SqlCommand command = new SqlCommand(spRefLivWageInsert, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inRefLivWage_PerBeg",
                refLivWage.RefLivWage_PerBeg == DateTime.MinValue ? Convert.DBNull : refLivWage.RefLivWage_PerBeg);
            command.Parameters.AddWithValue("@inRefLivWage_PerEnd",
                refLivWage.RefLivWage_PerEnd == DateTime.MinValue ? Convert.DBNull : refLivWage.RefLivWage_PerEnd);
            command.Parameters.AddWithValue("@inRefLivWage_Sm", refLivWage.RefLivWage_Sm);
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
        public bool ModifyRefLivWage(RefLivWage refLivWage, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            if (refLivWage == null)
            {
                error = "refLivWage == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spRefLivWageUpdate, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inRefLivWage_Id", refLivWage.RefLivWage_Id);
            command.Parameters.AddWithValue("@inRefLivWage_PerBeg",
                refLivWage.RefLivWage_PerBeg == DateTime.MinValue ? Convert.DBNull : refLivWage.RefLivWage_PerBeg);
            command.Parameters.AddWithValue("@inRefLivWage_PerEnd",
                refLivWage.RefLivWage_PerEnd == DateTime.MinValue ? Convert.DBNull : refLivWage.RefLivWage_PerEnd);
            command.Parameters.AddWithValue("@inRefLivWage_Sm", refLivWage.RefLivWage_Sm);
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
        public bool DeleteRefLivWage(int id, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spRefLivWageDelete, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inRefLivWage_Id", id);
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
