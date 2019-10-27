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
    public class RefTypeAddPaymentRepository
    {
        private SqlConnection conn;
        private string spRefTypeAddPaymentSelect = "spRefTypeAddPaymentSelect";
        private string spRefTypeAddPaymentInsert = "spRefTypeAddPaymentInsert";
        private string spRefTypeAddPaymentUpdate = "spRefTypeAddPaymentUpdate";
        private string spRefTypeAddPaymentDelete = "spRefTypeAddPaymentDelete";
        
        public RefTypeAddPaymentRepository(SqlConnection connection)
        {
            conn = connection;
        }
        private void FillDataRec(SqlDataReader reader, RefTypeAddPayment typeAddPayment)
        {
            int resInt = 0;
            if (int.TryParse(reader["RefTypeAddPayment_Id"].ToString(), out resInt))
            {
                typeAddPayment.RefTypeAddPayment_Id = resInt;
            }
            typeAddPayment.RefTypeAddPayment_Cd = reader["RefTypeAddPayment_Cd"].ToString();
            typeAddPayment.RefTypeAddPayment_Nm = reader["RefTypeAddPayment_Nm"].ToString();
        }
        //Получить все типы доп. выплат
        public List<RefTypeAddPayment> GetAllTypeAddPayments(out string error)
        {
            error = string.Empty;

            List<RefTypeAddPayment> typeAddPayments = new List<RefTypeAddPayment>();

            if (conn == null)
            {
                error = "conn == null";
                return typeAddPayments;
            }

            SqlCommand command = new SqlCommand(spRefTypeAddPaymentSelect, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    RefTypeAddPayment typeAddPayment = new RefTypeAddPayment();
                    FillDataRec(reader, typeAddPayment);
                    typeAddPayments.Add(typeAddPayment);
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
            return typeAddPayments;
        }

        //Получить тип доп. выплат id
        public RefTypeAddPayment GetTypeAddPaymentById(int id, out string error)
        {
            error = string.Empty;
            RefTypeAddPayment resTypeAddPayment = null;
            if (conn == null)
            {
                error = "conn == null";
                return null;
            }
            SqlCommand command = new SqlCommand(spRefTypeAddPaymentSelect, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inRefTypeAddPayment_Id", id);
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    resTypeAddPayment = new RefTypeAddPayment();
                    FillDataRec(reader, resTypeAddPayment);
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
            return resTypeAddPayment;
        }
        //Добавить тип доп. выплат
        public int AddTypeAddPayment(RefTypeAddPayment typeAddPayment, out string error)
        {
            error = string.Empty;
            if (typeAddPayment == null)
            {
                error = "typeAddPayment == null";
                return 0;
            }
            if (conn == null)
            {
                error = "conn == null";
                return 0;
            }
            SqlCommand command = new SqlCommand(spRefTypeAddPaymentInsert, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inRefTypeAddPayment_Cd", typeAddPayment.RefTypeAddPayment_Cd);
            command.Parameters.AddWithValue("@inRefTypeAddPayment_Nm", typeAddPayment.RefTypeAddPayment_Nm);
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
        //Изменить тип доп. выплат
        public bool ModifyTypeAddPayment(RefTypeAddPayment typeAddPayment, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            if (typeAddPayment == null)
            {
                error = "typeAddPayment == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spRefTypeAddPaymentUpdate, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inRefTypeAddPayment_Id", typeAddPayment.RefTypeAddPayment_Id);
            command.Parameters.AddWithValue("@inRefTypeAddPayment_Cd", typeAddPayment.RefTypeAddPayment_Cd);
            command.Parameters.AddWithValue("@inRefTypeAddPayment_Nm", typeAddPayment.RefTypeAddPayment_Nm);
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
        //Удалить тип доп. выплат
        public bool DeleteTypeAddPayment(int id, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spRefTypeAddPaymentDelete, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inRefTypeAddPayment_Id", id);
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
