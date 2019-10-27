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
    public class RefDepRepository
    {
        private SqlConnection conn;
        private string spRefDepSelect = "spRefDepSelect";
        private string spRefDepInsert = "spRefDepInsert";
        private string spRefDepUpdate = "spRefDepUpdate";
        private string spRefDepDelete = "spRefDepDelete";

        private void FillDataRec(SqlDataReader reader, RefDep dep)
        {
            int resInt = 0;
            if (int.TryParse(reader["RefDep_Id"].ToString(), out resInt))
            {
                dep.RefDep_Id = resInt;
            }
            dep.RefDep_Cd   = reader["RefDep_Cd"].ToString();
            dep.RefDep_Nm = reader["RefDep_Nm"].ToString();
        }
        public RefDepRepository(SqlConnection connection)
        {
            conn = connection;
        }
        //Получить все подразделения
        public List<RefDep> GetAllDeps(out string error)
        {
            error = string.Empty;

            List<RefDep> refDeps = new List<RefDep>();

            if (conn == null)
            {
                error = "conn == null";
                return refDeps;
            }

            SqlCommand command = new SqlCommand(spRefDepSelect, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    RefDep refDep = new RefDep();
                    FillDataRec(reader, refDep);
                    refDeps.Add(refDep);
                }
            }
            catch(Exception exc)
            {
                error = exc.Message;   
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
            return refDeps;
        }
        //Получить подразделения по id
        public RefDep GetDepById(int id, out string error)
        {
            error = string.Empty;
            RefDep resRefDep = null;
            if (conn == null)
            {
                error = "conn == null";
                return null;
            }
            SqlCommand command = new SqlCommand(spRefDepSelect, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inRefDep_Id", id);
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    resRefDep = new RefDep();
                    FillDataRec(reader, resRefDep);
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
            return resRefDep;
        }
        //Добавить подразделение
        public int AddDep(RefDep department, out string error)
        {
            error = string.Empty;
            if(department == null)
            {
                error = "department == null";
                return 0;
            }
            if (conn == null)
            {
                error = "conn == null";
                return 0;
            }
            SqlCommand command = new SqlCommand(spRefDepInsert, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inRefDep_Cd", department.RefDep_Cd);
            command.Parameters.AddWithValue("@inRefDep_Nm", department.RefDep_Nm);
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
        //Изменить подразделение
        public bool ModifyDep(RefDep department, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            if (department == null)
            {
                error = "setup == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spRefDepUpdate, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inRefDep_Id", department.RefDep_Id);
            command.Parameters.AddWithValue("@inRefDep_Cd", department.RefDep_Cd);
            command.Parameters.AddWithValue("@inRefDep_Nm", department.RefDep_Nm);
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
        //Удалить подразделение
        public bool DeleteDep(int id, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spRefDepDelete, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inRefDep_Id", id);
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
