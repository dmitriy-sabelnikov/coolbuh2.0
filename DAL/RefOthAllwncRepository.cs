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
    public class RefOthAllwncRepository
    {
        private SqlConnection conn;
        private string spRefOthAllwncSelect = "spRefOthAllwncSelect";
        private string spRefOthAllwncInsert = "spRefOthAllwncInsert";
        private string spRefOthAllwncUpdate = "spRefOthAllwncUpdate";
        private string spRefOthAllwncDelete = "spRefOthAllwncDelete";
        public RefOthAllwncRepository(SqlConnection connection)
        {
            conn = connection;
        }
        private void FillDataRec(SqlDataReader reader, RefOthAllwnc OthAllwnc)
        {
            int resInt = 0;
            decimal resDecimal = 0;
            if (int.TryParse(reader["RefOthAllwnc_Id"].ToString(), out resInt))
            {
                OthAllwnc.RefOthAllwnc_Id = resInt;
            }
            OthAllwnc.RefOthAllwnc_Cd = reader["RefOthAllwnc_Cd"].ToString();
            OthAllwnc.RefOthAllwnc_Nm = reader["RefOthAllwnc_Nm"].ToString();
            if (decimal.TryParse(reader["RefOthAllwnc_Pct"].ToString(), out resDecimal))
            {
                OthAllwnc.RefOthAllwnc_Pct = resDecimal;
            }
            if (int.TryParse(reader["RefOthAllwnc_Flg"].ToString(), out resInt))
            {
                OthAllwnc.RefOthAllwnc_Flg = resInt;
            }
        }
        //Получить другие надбавки
        public List<RefOthAllwnc> GetAllOthAllwnc(out string error)
        {
            error = string.Empty;

            List<RefOthAllwnc> refOthAllwncs = new List<RefOthAllwnc>();

            if (conn == null)
            {
                error = "conn == null";
                return refOthAllwncs;
            }

            SqlCommand command = new SqlCommand(spRefOthAllwncSelect, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    RefOthAllwnc refOthAllwnc = new RefOthAllwnc();
                    FillDataRec(reader, refOthAllwnc);
                    refOthAllwncs.Add(refOthAllwnc);
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
            return refOthAllwncs;
        }

        //Получить другие надбавки  по id
        public RefOthAllwnc GetOthAllwncById(int id, out string error)
        {
            error = string.Empty;
            RefOthAllwnc resOthAllwnc = null;
            if (conn == null)
            {
                error = "conn == null";
                return null;
            }
            SqlCommand command = new SqlCommand(spRefOthAllwncSelect, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inRefOthAllwnc_Id", id);
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    resOthAllwnc = new RefOthAllwnc();
                    FillDataRec(reader, resOthAllwnc);
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
            return resOthAllwnc;
        }
        //Добавить другую надбавку
        public int AddOthAllwnc(RefOthAllwnc othAllwnc, out string error)
        {
            error = string.Empty;
            if (othAllwnc == null)
            {
                error = "othAllwnc == null";
                return 0;
            }
            if (conn == null)
            {
                error = "conn == null";
                return 0;
            }
            SqlCommand command = new SqlCommand(spRefOthAllwncInsert, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inRefOthAllwnc_Cd",  othAllwnc.RefOthAllwnc_Cd);
            command.Parameters.AddWithValue("@inRefOthAllwnc_Nm",  othAllwnc.RefOthAllwnc_Nm);
            command.Parameters.AddWithValue("@inRefOthAllwnc_Pct", othAllwnc.RefOthAllwnc_Pct);
            command.Parameters.AddWithValue("@inRefOthAllwnc_Flg", othAllwnc.RefOthAllwnc_Flg);
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
        //Изменить другую надбавку
        public bool ModifyOthAllwnc(RefOthAllwnc othAllwnc, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            if (othAllwnc == null)
            {
                error = "othAllwnc == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spRefOthAllwncUpdate, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;

            command.Parameters.AddWithValue("@inRefOthAllwnc_Id",  othAllwnc.RefOthAllwnc_Id);
            command.Parameters.AddWithValue("@inRefOthAllwnc_Cd",  othAllwnc.RefOthAllwnc_Cd);
            command.Parameters.AddWithValue("@inRefOthAllwnc_Nm", othAllwnc.RefOthAllwnc_Nm);
            command.Parameters.AddWithValue("@inRefOthAllwnc_Pct", othAllwnc.RefOthAllwnc_Pct);
            command.Parameters.AddWithValue("@inRefOthAllwnc_Flg", othAllwnc.RefOthAllwnc_Flg);

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
        //Удалить другую надбавку
        public bool DeleteOthAllwnc(int id, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spRefOthAllwncDelete, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inRefOthAllwnc_Id", id);
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
