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
    public class RefMinSalaryRepository
    {
        private SqlConnection conn;
        private string spRefMinSalarySelect = "spRefMinSalarySelect";
        private string spRefMinSalaryInsert = "spRefMinSalaryInsert";
        private string spRefMinSalaryUpdate = "spRefMinSalaryUpdate";
        private string spRefMinSalaryDelete = "spRefMinSalaryDelete";
        public RefMinSalaryRepository(SqlConnection connection)
        {
            conn = connection;
        }
        private void FillDataRec(SqlDataReader reader, RefMinSalary RefMinSalary)
        {
            int resInt = 0;
            DateTime resDate = DateTime.MinValue;
            decimal resDec = 0;
            if (int.TryParse(reader["RefMinSalary_Id"].ToString(), out resInt))
            {
                RefMinSalary.RefMinSalary_Id = resInt;
            }
            if (DateTime.TryParse(reader["RefMinSalary_PerBeg"].ToString(), out resDate))
            {
                RefMinSalary.RefMinSalary_PerBeg = resDate;
            }
            if (DateTime.TryParse(reader["RefMinSalary_PerEnd"].ToString(), out resDate))
            {
                RefMinSalary.RefMinSalary_PerEnd = resDate;
            }
            if (decimal.TryParse(reader["RefMinSalary_Sm"].ToString(), out resDec))
            {
                RefMinSalary.RefMinSalary_Sm = resDec;
            }
        }
        //Получить интервалы минимальной зп
        public List<RefMinSalary> GetAllRefMinSalaries(out string error)
        {
            error = string.Empty;

            List<RefMinSalary> refMinSalaries = new List<RefMinSalary>();

            if (conn == null)
            {
                error = "conn == null";
                return refMinSalaries;
            }

            SqlCommand command = new SqlCommand(spRefMinSalarySelect, conn);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    RefMinSalary refMinSalary = new RefMinSalary();
                    FillDataRec(reader, refMinSalary);
                    refMinSalaries.Add(refMinSalary);
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
            return refMinSalaries;
        }

        //Добавить интервал минимальной зп
        public int AddRefMinSalary(RefMinSalary refMinSalary, out string error)
        {
            error = string.Empty;
            if (refMinSalary == null)
            {
                error = "refMinSalary == null";
                return 0;
            }
            if (conn == null)
            {
                error = "conn == null";
                return 0;
            }
            SqlCommand command = new SqlCommand(spRefMinSalaryInsert, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inRefMinSalary_PerBeg",
                refMinSalary.RefMinSalary_PerBeg == DateTime.MinValue ? Convert.DBNull : refMinSalary.RefMinSalary_PerBeg);
            command.Parameters.AddWithValue("@inRefMinSalary_PerEnd",
                refMinSalary.RefMinSalary_PerEnd == DateTime.MinValue ? Convert.DBNull : refMinSalary.RefMinSalary_PerEnd);
            command.Parameters.AddWithValue("@inRefMinSalary_Sm", refMinSalary.RefMinSalary_Sm);
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
        //Изменить интервал минимальной зп
        public bool ModifyRefMinSalary(RefMinSalary refMinSalary, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            if (refMinSalary == null)
            {
                error = "refMinSalary == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spRefMinSalaryUpdate, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inRefMinSalary_Id", refMinSalary.RefMinSalary_Id);
            command.Parameters.AddWithValue("@inRefMinSalary_PerBeg",
                refMinSalary.RefMinSalary_PerBeg == DateTime.MinValue ? Convert.DBNull : refMinSalary.RefMinSalary_PerBeg);
            command.Parameters.AddWithValue("@inRefMinSalary_PerEnd",
                refMinSalary.RefMinSalary_PerEnd == DateTime.MinValue ? Convert.DBNull : refMinSalary.RefMinSalary_PerEnd);
            command.Parameters.AddWithValue("@inRefMinSalary_Sm", refMinSalary.RefMinSalary_Sm);
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
        //Удалить интервал минимальной зп
        public bool DeleteRefMinSalary(int id, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spRefMinSalaryDelete, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inRefMinSalary_Id", id);
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
