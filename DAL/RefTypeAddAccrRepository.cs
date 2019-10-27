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
    public class RefTypeAddAccrRepository
    {
        private SqlConnection conn;

        private string spRefTypeAddAccrSelect = "spRefTypeAddAccrSelect";
        private string spRefTypeAddAccrInsert = "spRefTypeAddAccrInsert";
        private string spRefTypeAddAccrUpdate = "spRefTypeAddAccrUpdate";
        private string spRefTypeAddAccrDelete = "spRefTypeAddAccrDelete";
        public RefTypeAddAccrRepository(SqlConnection connection)
        {
            conn = connection;
        }

        private void FillDataRec(SqlDataReader reader, RefTypeAddAccr typeAddAccr)
        {
            int resInt = 0;
            if (int.TryParse(reader["RefTypeAddAccr_Id"].ToString(), out resInt))
            {
                typeAddAccr.RefTypeAddAccr_Id = resInt;
            }
            typeAddAccr.RefTypeAddAccr_Cd = reader["RefTypeAddAccr_Cd"].ToString();
            typeAddAccr.RefTypeAddAccr_Nm = reader["RefTypeAddAccr_Nm"].ToString();
            if (int.TryParse(reader["RefTypeAddAccr_Flg"].ToString(), out resInt))
            {
                typeAddAccr.RefTypeAddAccr_Flg = resInt;
            }
        }
        //Получить справочник типов доп. удержаний
        public List<RefTypeAddAccr> GetAllTypeAddAccr(out string error)
        {
            error = string.Empty;

            List<RefTypeAddAccr> typeAddAccrs = new List<RefTypeAddAccr>();

            if (conn == null)
            {
                error = "conn == null";
                return typeAddAccrs;
            }

            SqlCommand command = new SqlCommand(spRefTypeAddAccrSelect, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    RefTypeAddAccr refTypeAddAccr = new RefTypeAddAccr();
                    FillDataRec(reader, refTypeAddAccr);
                    typeAddAccrs.Add(refTypeAddAccr);
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
            return typeAddAccrs;
        }
        //Получить строку типа доп. удержания
        public RefTypeAddAccr GetTypeAaddAccrById(int id, out string error)
        {
            error = string.Empty;
            RefTypeAddAccr resTypeAddAccr = null;
            if (conn == null)
            {
                error = "conn == null";
                return null;
            }
            SqlCommand command = new SqlCommand(spRefTypeAddAccrSelect, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inRefTypeAddAccr_Id", id);
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    resTypeAddAccr = new RefTypeAddAccr();
                    FillDataRec(reader, resTypeAddAccr);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return resTypeAddAccr;
        }
        //Добавить тип доп. начисления
        public int AddTypeAaddAccr(RefTypeAddAccr typeAddAccr, out string error)
        {
            error = string.Empty;
            if (typeAddAccr == null)
            {
                error = "typeAddAccr == null";
                return 0;
            }
            if (conn == null)
            {
                error = "conn == null";
                return 0;
            }
            SqlCommand command = new SqlCommand(spRefTypeAddAccrInsert, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;

            command.Parameters.AddWithValue("@inRefTypeAddAccr_Cd", typeAddAccr.RefTypeAddAccr_Cd);
            command.Parameters.AddWithValue("@inRefTypeAddAccr_Nm", typeAddAccr.RefTypeAddAccr_Nm);
            command.Parameters.AddWithValue("@inRefTypeAddAccr_Flg", typeAddAccr.RefTypeAddAccr_Flg);
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
        //Изменить тип доп. начисления
        public bool ModifyTypeAaddAccr(RefTypeAddAccr typeAddAccr, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            if (typeAddAccr == null)
            {
                error = "typeAddAccr == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spRefTypeAddAccrUpdate, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;

            command.Parameters.AddWithValue("@inRefTypeAddAccr_Id", typeAddAccr.RefTypeAddAccr_Id);
            command.Parameters.AddWithValue("@inRefTypeAddAccr_Cd", typeAddAccr.RefTypeAddAccr_Cd);
            command.Parameters.AddWithValue("@inRefTypeAddAccr_Nm", typeAddAccr.RefTypeAddAccr_Nm);
            command.Parameters.AddWithValue("@inRefTypeAddAccr_Flg", typeAddAccr.RefTypeAddAccr_Flg);

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
        //Удалить тип доп. начисления
        public bool DeleteTypeAddAccr(int id, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spRefTypeAddAccrDelete, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inRefTypeAddAccr_Id", id);
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
