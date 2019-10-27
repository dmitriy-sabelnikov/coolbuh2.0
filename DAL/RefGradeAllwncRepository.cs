using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class RefGradeAllwncRepository
    {
        private SqlConnection conn;
        private string spRefGradeAllwncSelect = "spRefGradeAllwncSelect";
        private string spRefGradeAllwncInsert = "spRefGradeAllwncInsert";
        private string spRefGradeAllwncUpdate = "spRefGradeAllwncUpdate";
        private string spRefGradeAllwncDelete = "spRefGradeAllwncDelete";

        public RefGradeAllwncRepository(SqlConnection connection)
        {
            conn = connection;
        }

        private void FillDataRec(SqlDataReader reader, RefGradeAllwnc gradeAllwnc)
        {
            int resInt = 0;
            decimal resDecimal = 0;
            DateTime resDt = DateTime.MinValue;

            if (int.TryParse(reader["RefGradeAllwnc_Id"].ToString(), out resInt))
            {
                gradeAllwnc.RefGradeAllwnc_Id = resInt;
            }
            gradeAllwnc.RefGradeAllwnc_Cd = reader["RefGradeAllwnc_Cd"].ToString();
            gradeAllwnc.RefGradeAllwnc_Nm = reader["RefGradeAllwnc_Nm"].ToString();
            if (decimal.TryParse(reader["RefGradeAllwnc_Pct"].ToString(), out resDecimal))
            {
                gradeAllwnc.RefGradeAllwnc_Pct = resDecimal;
            }
            if (int.TryParse(reader["RefGradeAllwnc_Grade"].ToString(), out resInt))
            {
                gradeAllwnc.RefGradeAllwnc_Grade = resInt;
            }
            if (int.TryParse(reader["RefGradeAllwnc_RefDep_Id"].ToString(), out resInt))
            {
                gradeAllwnc.RefGradeAllwnc_RefDep_Id = resInt;
            }
            if (int.TryParse(reader["RefGradeAllwnc_Flg"].ToString(), out resInt))
            {
                gradeAllwnc.RefGradeAllwnc_Flg = resInt;
            }
        }

        ////Получить надбавки 
        public List<RefGradeAllwnc> GetAllGradeAllwnc(out string error)
        {
            error = string.Empty;
        
            List<RefGradeAllwnc> allowances = new List<RefGradeAllwnc>();
        
            if (conn == null)
            {
                error = "conn == null";
                return allowances;
            }
        
            SqlCommand command = new SqlCommand(spRefGradeAllwncSelect, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();
        
                while (reader.Read())
                {
                    RefGradeAllwnc allowance = new RefGradeAllwnc();
                    FillDataRec(reader, allowance);
                    allowances.Add(allowance);
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
            return allowances;
        }

        //Получить надбавку по id
        public RefGradeAllwnc GetGradeAllwncById(int id, out string error)
        {
            error = string.Empty;
            RefGradeAllwnc allowance = null;
            if (conn == null)
            {
                error = "conn == null";
                return null;
            }
            SqlCommand command = new SqlCommand(spRefGradeAllwncSelect, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inRefGradeAllwnc_Id", id);
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    allowance = new RefGradeAllwnc();
                    FillDataRec(reader, allowance);
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
            return allowance;
        }
        //Добавить надбавку 
        public int AddGradeAllwnc(RefGradeAllwnc allowance, out string error)
        {
            error = string.Empty;
            if (allowance == null)
            {
                error = "allowance == null";
                return 0;
            }
            if (conn == null)
            {
                error = "conn == null";
                return 0;
            }
            SqlCommand command = new SqlCommand(spRefGradeAllwncInsert, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inRefGradeAllwnc_Cd", allowance.RefGradeAllwnc_Cd);
            command.Parameters.AddWithValue("@inRefGradeAllwnc_Nm", allowance.RefGradeAllwnc_Nm);
            command.Parameters.AddWithValue("@inRefGradeAllwnc_Pct", allowance.RefGradeAllwnc_Pct);
            command.Parameters.AddWithValue("@inRefGradeAllwnc_Grade", allowance.RefGradeAllwnc_Grade);
            command.Parameters.AddWithValue("@inRefGradeAllwnc_RefDep_Id", 
                allowance.RefGradeAllwnc_RefDep_Id == 0 ? Convert.DBNull : allowance.RefGradeAllwnc_RefDep_Id);
            command.Parameters.AddWithValue("@inRefGradeAllwnc_Flg", allowance.RefGradeAllwnc_Flg);
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

        //Изменить надбавку
        public bool ModifyGradeAllwnc(RefGradeAllwnc allowance, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            if (allowance == null)
            {
                error = "allowance == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spRefGradeAllwncUpdate, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inRefGradeAllwnc_Id", allowance.RefGradeAllwnc_Id);
            command.Parameters.AddWithValue("@inRefGradeAllwnc_Cd", allowance.RefGradeAllwnc_Cd);
            command.Parameters.AddWithValue("@inRefGradeAllwnc_Nm", allowance.RefGradeAllwnc_Nm);
            command.Parameters.AddWithValue("@inRefGradeAllwnc_Pct", allowance.RefGradeAllwnc_Pct);
            command.Parameters.AddWithValue("@inRefGradeAllwnc_Grade", allowance.RefGradeAllwnc_Grade);
            command.Parameters.AddWithValue("@inRefGradeAllwnc_RefDep_Id",
                allowance.RefGradeAllwnc_RefDep_Id == 0 ? Convert.DBNull : allowance.RefGradeAllwnc_RefDep_Id);
            command.Parameters.AddWithValue("@inRefGradeAllwnc_Flg", allowance.RefGradeAllwnc_Flg);
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

        //Удалить надбавку
        public bool DeleteGradeAllwnc(int id, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spRefGradeAllwncDelete, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inRefGradeAllwnc_Id", id);
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
