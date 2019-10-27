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
    public class RefPensAllwncRepository
    {
        private SqlConnection conn;
        private string spRefPensAllwncSelect = "spRefPensAllwncSelect";
        private string spRefPensAllwncInsert = "spRefPensAllwncInsert";
        private string spRefPensAllwncUpdate = "spRefPensAllwncUpdate";
        private string spRefPensAllwncDelete = "spRefPensAllwncDelete";
        public RefPensAllwncRepository(SqlConnection connection)
        {
            conn = connection;
        }

        private void FillDataRec(SqlDataReader reader, RefPensAllwnc pensAllwnc)
        {
            int resInt = 0;
            decimal resDecimal = 0;
            if (int.TryParse(reader["RefPensAllwnc_Id"].ToString(), out resInt))
            {
                pensAllwnc.RefPensAllwnc_Id = resInt;
            }
            pensAllwnc.RefPensAllwnc_Cd = reader["RefPensAllwnc_Cd"].ToString();
            pensAllwnc.RefPensAllwnc_Nm = reader["RefPensAllwnc_Nm"].ToString();
            if (decimal.TryParse(reader["RefPensAllwnc_Pct"].ToString(), out resDecimal))
            {
                pensAllwnc.RefPensAllwnc_Pct = resDecimal;
            }
            if (int.TryParse(reader["RefPensAllwnc_Flg"].ToString(), out resInt))
            {
                pensAllwnc.RefPensAllwnc_Flg = resInt;
            }
        }
        //Получить надбавки пенсионеру
        public List<RefPensAllwnc> GetAllPensAllwnc(out string error)
        {
            error = string.Empty;

            List<RefPensAllwnc> refPensAllwncs = new List<RefPensAllwnc>();

            if (conn == null)
            {
                error = "conn == null";
                return refPensAllwncs;
            }

            SqlCommand command = new SqlCommand(spRefPensAllwncSelect, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    RefPensAllwnc refPensAllwnc = new RefPensAllwnc();
                    FillDataRec(reader, refPensAllwnc);
                    refPensAllwncs.Add(refPensAllwnc);
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
            return refPensAllwncs;
        }

        //Получить надбавку пенсионеру по id
        public RefPensAllwnc GetPensAllwncById(int id, out string error)
        {
            error = string.Empty;
            RefPensAllwnc resPensAllwnc = null;
            if (conn == null)
            {
                error = "conn == null";
                return null;
            }
            SqlCommand command = new SqlCommand(spRefPensAllwncSelect, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inRefPensAllwnc_Id", id);
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    resPensAllwnc = new RefPensAllwnc();
                    FillDataRec(reader, resPensAllwnc);
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
            return resPensAllwnc;
        }
        //Добавить надбавку пенсионеру
        public int AddPensAllwnc(RefPensAllwnc pensAllwnc, out string error)
        {
            error = string.Empty;
            if (pensAllwnc == null)
            {
                error = "pensAllwnc == null";
                return 0;
            }
            if (conn == null)
            {
                error = "conn == null";
                return 0;
            }
            SqlCommand command = new SqlCommand(spRefPensAllwncInsert, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inRefPensAllwnc_Cd",  pensAllwnc.RefPensAllwnc_Cd);
            command.Parameters.AddWithValue("@inRefPensAllwnc_Nm",  pensAllwnc.RefPensAllwnc_Nm);
            command.Parameters.AddWithValue("@inRefPensAllwnc_Pct", pensAllwnc.RefPensAllwnc_Pct);
            command.Parameters.AddWithValue("@inRefPensAllwnc_Flg", pensAllwnc.RefPensAllwnc_Flg);
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
        //Изменить надбавку пенсионеру
        public bool ModifyPensAllwnc(RefPensAllwnc pensAllwnc, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            if (pensAllwnc == null)
            {
                error = "pensAllwnc == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spRefPensAllwncUpdate, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;

            command.Parameters.AddWithValue("@inRefPensAllwnc_Id",  pensAllwnc.RefPensAllwnc_Id);
            command.Parameters.AddWithValue("@inRefPensAllwnc_Cd",  pensAllwnc.RefPensAllwnc_Cd);
            command.Parameters.AddWithValue("@inRefPensAllwnc_Nm",  pensAllwnc.RefPensAllwnc_Nm);
            command.Parameters.AddWithValue("@inRefPensAllwnc_Pct", pensAllwnc.RefPensAllwnc_Pct);
            command.Parameters.AddWithValue("@inRefPensAllwnc_Flg", pensAllwnc.RefPensAllwnc_Flg);

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
        //Удалить надбавку за стаж
        public bool DeletePensAllwnc(int id, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spRefPensAllwncDelete, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inRefPensAllwnc_Id", id);
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
