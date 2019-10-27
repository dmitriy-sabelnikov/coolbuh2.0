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
    public class SalaryRepository
    {
        private SqlConnection conn;
        private string spSalarySelect = "spSalarySelect";
        private string spSalaryInsert = "spSalaryInsert";
        private string spSalaryUpdate = "spSalaryUpdate";
        private string spSalaryDelete = "spSalaryDelete";
        public SalaryRepository(SqlConnection connection)
        {
            conn = connection;
        }
        private void FillDataRec(SqlDataReader reader, Salary salary)
        {
            int resInt = 0;
            DateTime resDate = DateTime.MinValue;
            decimal resDec = 0;
            if (int.TryParse(reader["Salary_Id"].ToString(), out resInt))
            {
                salary.Salary_Id = resInt;
            }
            if (int.TryParse(reader["Salary_PersCard_Id"].ToString(), out resInt))
            {
                salary.Salary_PersCard_Id = resInt;
            }
            if (int.TryParse(reader["Salary_RefDep_Id"].ToString(), out resInt))
            {
                salary.Salary_RefDep_Id = resInt;
            }
            if (DateTime.TryParse(reader["Salary_Date"].ToString(), out resDate))
            {
                salary.Salary_Date = resDate;
            }
            if (int.TryParse(reader["Salary_Days"].ToString(), out resInt))
            {
                salary.Salary_Days = resInt;
            }
            if (decimal.TryParse(reader["Salary_Hours"].ToString(), out resDec))
            {
                salary.Salary_Hours = resDec;
            }
            if (decimal.TryParse(reader["Salary_BaseSm"].ToString(), out resDec))
            {
                salary.Salary_BaseSm = resDec;
            }
            if (int.TryParse(reader["Salary_PensId"].ToString(), out resInt))
            {
                salary.Salary_PensId = resInt;
            }
            if (decimal.TryParse(reader["Salary_PensPct"].ToString(), out resDec))
            {
                salary.Salary_PensPct = resDec;
            }
            if (decimal.TryParse(reader["Salary_PensSm"].ToString(), out resDec))
            {
                salary.Salary_PensSm = resDec;
            }
            if (int.TryParse(reader["Salary_ExpId"].ToString(), out resInt))
            {
                salary.Salary_ExpId = resInt;
            }
            if (decimal.TryParse(reader["Salary_ExpPct"].ToString(), out resDec))
            {
                salary.Salary_ExpPct = resDec;
            }
            if (decimal.TryParse(reader["Salary_ExpSm"].ToString(), out resDec))
            {
                salary.Salary_ExpSm = resDec;
            }
            if (int.TryParse(reader["Salary_GradeId"].ToString(), out resInt))
            {
                salary.Salary_GradeId = resInt;
            }
            if (decimal.TryParse(reader["Salary_GradePct"].ToString(), out resDec))
            {
                salary.Salary_GradePct = resDec;
            }
            if (decimal.TryParse(reader["Salary_GradeSm"].ToString(), out resDec))
            {
                salary.Salary_GradeSm = resDec;
            }
            if (int.TryParse(reader["Salary_OthId"].ToString(), out resInt))
            {
                salary.Salary_OthId = resInt;
            }
            if (decimal.TryParse(reader["Salary_OthPct"].ToString(), out resDec))
            {
                salary.Salary_OthPct = resDec;
            }
            if (decimal.TryParse(reader["Salary_OthSm"].ToString(), out resDec))
            {
                salary.Salary_OthSm = resDec;
            }
            if (decimal.TryParse(reader["Salary_KTU"].ToString(), out resDec))
            {
                salary.Salary_KTU = resDec;
            }
            if (decimal.TryParse(reader["Salary_KTUSm"].ToString(), out resDec))
            {
                salary.Salary_KTUSm = resDec;
            }
            if (decimal.TryParse(reader["Salary_ResSm"].ToString(), out resDec))
            {
                salary.Salary_ResSm = resDec;
            }
        }
        //Получить зарплату
        public List<Salary> GetAllSalaries(out string error)
        {
            error = string.Empty;

            List<Salary> salaries = new List<Salary>();

            if (conn == null)
            {
                error = "conn == null";
                return salaries;
            }

            SqlCommand command = new SqlCommand(spSalarySelect, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Salary salary = new Salary();
                    FillDataRec(reader, salary);
                    salaries.Add(salary);
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
            return salaries;
        }
        //Получить зарплату по параметрам
        public List<Salary> GetSalariesByParams(int salary_id, int refDep_id, DateTime salary_dateBeg, DateTime salary_dateEnd, out string error)
        {
            error = string.Empty;

            List<Salary> salaries = new List<Salary>();

            if (conn == null)
            {
                error = "conn == null";
                return salaries;
            }
            if (salary_id == 0 && refDep_id == 0 && salary_dateBeg == DateTime.MinValue && salary_dateEnd == DateTime.MinValue)
            {
                error = "Не задані вхідні параметри";
                return salaries;
            }
            if (salary_dateBeg == DateTime.MinValue || salary_dateEnd == DateTime.MinValue)
            {
                error = "Не заданий період";
                return salaries;
            }

            SqlCommand command = new SqlCommand(spSalarySelect, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;

            command.Parameters.AddWithValue("@inSalary_Id", salary_id);
            command.Parameters.AddWithValue("@inSalary_RefDep_Id", refDep_id);
            command.Parameters.AddWithValue("@inSalary_DateBeg", (salary_dateBeg == DateTime.MinValue) ? Convert.DBNull : salary_dateBeg);
            command.Parameters.AddWithValue("@inSalary_DateEnd", (salary_dateEnd == DateTime.MinValue) ? Convert.DBNull : salary_dateEnd);

            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Salary salary = new Salary();
                    FillDataRec(reader, salary);
                    salaries.Add(salary);
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
            return salaries;
        }

        //Добавить зарплату
        public int AddSalary(Salary salary, out string error)
        {
            error = string.Empty;
            if (salary == null)
            {
                error = "salary == null";
                return 0;
            }
            if (conn == null)
            {
                error = "conn == null";
                return 0;
            }
            SqlCommand command = new SqlCommand(spSalaryInsert, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;

            command.Parameters.AddWithValue("@inSalary_PersCard_Id", salary.Salary_PersCard_Id == 0 ? Convert.DBNull : salary.Salary_PersCard_Id);
            command.Parameters.AddWithValue("@inSalary_RefDep_Id", salary.Salary_RefDep_Id == 0 ? Convert.DBNull : salary.Salary_RefDep_Id);
            command.Parameters.AddWithValue("@inSalary_Date", salary.Salary_Date == DateTime.MinValue ? Convert.DBNull : salary.Salary_Date);
            command.Parameters.AddWithValue("@inSalary_Days", salary.Salary_Days);
            command.Parameters.AddWithValue("@inSalary_Hours", salary.Salary_Hours);
            command.Parameters.AddWithValue("@inSalary_BaseSm", salary.Salary_BaseSm);
            command.Parameters.AddWithValue("@inSalary_PensId", (salary.Salary_PensId == 0) ? Convert.DBNull : salary.Salary_PensId);
            command.Parameters.AddWithValue("@inSalary_PensPct", salary.Salary_PensPct);
            command.Parameters.AddWithValue("@inSalary_PensSm", salary.Salary_PensSm);
            command.Parameters.AddWithValue("@inSalary_ExpId", (salary.Salary_ExpId == 0) ? Convert.DBNull : salary.Salary_ExpId);
            command.Parameters.AddWithValue("@inSalary_ExpPct", salary.Salary_ExpPct);
            command.Parameters.AddWithValue("@inSalary_ExpSm", salary.Salary_ExpSm);
            command.Parameters.AddWithValue("@inSalary_GradeId", (salary.Salary_GradeId == 0) ? Convert.DBNull : salary.Salary_GradeId);
            command.Parameters.AddWithValue("@inSalary_GradePct", salary.Salary_GradePct);
            command.Parameters.AddWithValue("@inSalary_GradeSm", salary.Salary_GradeSm);
            command.Parameters.AddWithValue("@inSalary_OthId", (salary.Salary_OthId == 0) ? Convert.DBNull : salary.Salary_OthId);
            command.Parameters.AddWithValue("@inSalary_OthPct", salary.Salary_OthPct);
            command.Parameters.AddWithValue("@inSalary_OthSm", salary.Salary_OthSm);
            command.Parameters.AddWithValue("@inSalary_KTU", salary.Salary_KTU);
            command.Parameters.AddWithValue("@inSalary_KTUSm", salary.Salary_KTUSm);
            command.Parameters.AddWithValue("@inSalary_ResSm", salary.Salary_ResSm);
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
        //Изменить запись зарплаты
        public bool ModifySalary(Salary salary, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            if (salary == null)
            {
                error = "salary == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spSalaryUpdate, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inSalary_Id", salary.Salary_Id);
            command.Parameters.AddWithValue("@inSalary_PersCard_Id", salary.Salary_PersCard_Id == 0 ? Convert.DBNull : salary.Salary_PersCard_Id);
            command.Parameters.AddWithValue("@inSalary_RefDep_Id", salary.Salary_RefDep_Id == 0 ? Convert.DBNull : salary.Salary_RefDep_Id);
            command.Parameters.AddWithValue("@inSalary_Date", salary.Salary_Date == DateTime.MinValue ? Convert.DBNull : salary.Salary_Date);
            command.Parameters.AddWithValue("@inSalary_Days", salary.Salary_Days);
            command.Parameters.AddWithValue("@inSalary_Hours", salary.Salary_Hours);
            command.Parameters.AddWithValue("@inSalary_BaseSm", salary.Salary_BaseSm);
            command.Parameters.AddWithValue("@inSalary_PensId", (salary.Salary_PensId == 0) ? Convert.DBNull : salary.Salary_PensId);
            command.Parameters.AddWithValue("@inSalary_PensPct", salary.Salary_PensPct);
            command.Parameters.AddWithValue("@inSalary_PensSm", salary.Salary_PensSm);
            command.Parameters.AddWithValue("@inSalary_ExpId", (salary.Salary_ExpId == 0) ? Convert.DBNull : salary.Salary_ExpId);
            command.Parameters.AddWithValue("@inSalary_ExpPct", salary.Salary_ExpPct);
            command.Parameters.AddWithValue("@inSalary_ExpSm", salary.Salary_ExpSm);
            command.Parameters.AddWithValue("@inSalary_GradeId", (salary.Salary_GradeId == 0) ? Convert.DBNull : salary.Salary_GradeId);
            command.Parameters.AddWithValue("@inSalary_GradePct", salary.Salary_GradePct);
            command.Parameters.AddWithValue("@inSalary_GradeSm", salary.Salary_GradeSm);
            command.Parameters.AddWithValue("@inSalary_OthId", (salary.Salary_OthId == 0) ? Convert.DBNull : salary.Salary_OthId);
            command.Parameters.AddWithValue("@inSalary_OthPct", salary.Salary_OthPct);
            command.Parameters.AddWithValue("@inSalary_OthSm", salary.Salary_OthSm);
            command.Parameters.AddWithValue("@inSalary_KTU", salary.Salary_KTU);
            command.Parameters.AddWithValue("@inSalary_KTUSm", salary.Salary_KTUSm);
            command.Parameters.AddWithValue("@inSalary_ResSm", salary.Salary_ResSm);
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
        //Удалить запись зарплаты
        public bool DeleteSalary(int id, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spSalaryDelete, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inSalary_Id", id);
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