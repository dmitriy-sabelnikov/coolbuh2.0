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
    public class RefAdmRepository
    {
        private SqlConnection conn;
        private string spRefAdmSelect = "spRefAdmSelect";
        private string spRefAdmInsert = "spRefAdmInsert";
        private string spRefAdmUpdate = "spRefAdmUpdate";
        private string spRefAdmDelete = "spRefAdmDelete";

        public RefAdmRepository(SqlConnection connection)
        {
            conn = connection;
        }

        private void FillDataRec(SqlDataReader reader, RefAdm adm)
        {
            int resInt = 0;
            if (int.TryParse(reader["RefAdm_Id"].ToString(), out resInt))
            {
                adm.RefAdm_Id = resInt;
            }
            adm.RefAdm_TIN = reader["RefAdm_TIN"].ToString();
            adm.RefAdm_FIO = reader["RefAdm_FIO"].ToString();
            if (int.TryParse(reader["RefAdm_TypDol"].ToString(), out resInt))
            {
                adm.RefAdm_TypDol = resInt;
            }
            if (int.TryParse(reader["RefAdm_Tel"].ToString(), out resInt))
            {
                adm.RefAdm_Tel = resInt;
            }
        }

        //Получить всю администрацию
        public List<RefAdm> GetAllAdms(out string error)
        {
            error = string.Empty;

            List<RefAdm> refAdms = new List<RefAdm>();

            if (conn == null)
            {
                error = "conn == null";
                return refAdms;
            }

            SqlCommand command = new SqlCommand(spRefAdmSelect, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    RefAdm refAdm = new RefAdm();
                    FillDataRec(reader, refAdm);
                    refAdms.Add(refAdm);
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
            return refAdms;
        }

        //Получить администрацию по id
        public RefAdm GetAdmById(int id, out string error)
        {
            error = string.Empty;
            RefAdm resRefAdm = null;
            if (conn == null)
            {
                error = "conn == null";
                return null;
            }
            SqlCommand command = new SqlCommand(spRefAdmSelect, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inRefAdm_Id", id);
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    resRefAdm = new RefAdm();
                    FillDataRec(reader, resRefAdm);
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
            return resRefAdm;
        }
        //Добавить администрацию
        public int AddAdm(RefAdm adm, out string error)
        {
            error = string.Empty;
            if (adm == null)
            {
                error = "card == null";
                return 0;
            }
            if (conn == null)
            {
                error = "conn == null";
                return 0;
            }
            SqlCommand command = new SqlCommand(spRefAdmInsert, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;

            command.Parameters.AddWithValue("@inRefAdm_TIN", adm.RefAdm_TIN);
            command.Parameters.AddWithValue("@inRefAdm_FIO", adm.RefAdm_FIO);
            command.Parameters.AddWithValue("@inRefAdm_TypDol", adm.RefAdm_TypDol);
            command.Parameters.AddWithValue("@inRefAdm_Tel", adm.RefAdm_Tel);
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

        //Изменить администрацию
        public bool ModifyAdm(RefAdm adm, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            if (adm == null)
            {
                error = "adm == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spRefAdmUpdate, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;

            command.Parameters.AddWithValue("@inRefAdm_Id"   , adm.RefAdm_Id);
            command.Parameters.AddWithValue("@inRefAdm_TIN"  , adm.RefAdm_TIN);
            command.Parameters.AddWithValue("@inRefAdm_FIO"  , adm.RefAdm_FIO);
            command.Parameters.AddWithValue("@inRefAdm_TypDol", adm.RefAdm_TypDol);
            command.Parameters.AddWithValue("@inRefAdm_Tel"  , adm.RefAdm_Tel);
           
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
        //Удалить администрацию
        public bool DeleteAdm(int id, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spRefAdmDelete, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inRefAdm_Id", id);
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
