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
    public class PaymentRepository
    {
        private SqlConnection conn;
        private string spPaymentSelect = "spPaymentSelect";
        private string spPaymentInsert = "spPaymentInsert";
        private string spPaymentUpdate = "spPaymentUpdate";
        private string spPaymentDelete = "spPaymentDelete";
        public PaymentRepository(SqlConnection connection)
        {
            conn = connection;
        }
        private void FillDataRec(SqlDataReader reader, Payment payment)
        {
            int resInt = 0;
            DateTime resDate = DateTime.MinValue;
            decimal resDec = 0;

            if (int.TryParse(reader["Payment_Id"].ToString(), out resInt))
            {
                payment.Payment_Id = resInt;
            }
            if (int.TryParse(reader["Payment_PersCard_Id"].ToString(), out resInt))
            {
                payment.Payment_PersCard_Id = resInt;
            }
            if (DateTime.TryParse(reader["Payment_Date"].ToString(), out resDate))
            {
                payment.Payment_Date = resDate;
            }
            if (int.TryParse(reader["Payment_Type"].ToString(), out resInt))
            {
                payment.Payment_Type = resInt;
            }
            if (decimal.TryParse(reader["Payment_Amt"].ToString(), out resDec))
            {
                payment.Payment_Amt = resDec;
            }
            if (decimal.TryParse(reader["Payment_Price"].ToString(), out resDec))
            {
                payment.Payment_Price = resDec;
            }
            if (decimal.TryParse(reader["Payment_Sm"].ToString(), out resDec))
            {
                payment.Payment_Sm = resDec;
            }
        }
        //Получить список выплат
        public List<Payment> GetAllPayments(out string error)
        {
            error = string.Empty;

            List<Payment> payments = new List<Payment>();

            if (conn == null)
            {
                error = "conn == null";
                return payments;
            }

            SqlCommand command = new SqlCommand(spPaymentSelect, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Payment payment = new Payment();
                    FillDataRec(reader, payment);
                    payments.Add(payment);
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
            return payments;
        }
        //Получить суммы подоходного налога по параметрам
        public List<Payment> GetPaymentByParams(int payment_id, int payment_type, DateTime payment_dateBeg, DateTime payment_dateEnd, out string error)
        {
            error = string.Empty;

            if (conn == null)
            {
                error = "conn == null";
                return null;
            }
            if (payment_id == 0 && payment_type == 0 && payment_dateBeg == DateTime.MinValue && payment_dateEnd == DateTime.MinValue)
            {
                error = "Не задані вхідні параметри";
                return null;
            }
            if (payment_dateBeg == DateTime.MinValue || payment_dateEnd == DateTime.MinValue)
            {
                error = "Не заданий період";
                return null;
            }

            List<Payment> payments = new List<Payment>();

            SqlCommand command = new SqlCommand(spPaymentSelect, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;

            command.Parameters.AddWithValue("@inPayment_Id", payment_id);
            command.Parameters.AddWithValue("@inPayment_Type", payment_type);
            command.Parameters.AddWithValue("@inPayment_DateBeg", (payment_dateBeg == DateTime.MinValue) ? Convert.DBNull : payment_dateBeg);
            command.Parameters.AddWithValue("@inPayment_DateEnd", (payment_dateEnd == DateTime.MinValue) ? Convert.DBNull : payment_dateEnd);

            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Payment payment = new Payment();
                    FillDataRec(reader, payment);
                    payments.Add(payment);
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                payments = null;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
            return payments;
        }
        //Добавить выплату
        public int AddPayment(Payment payment, out string error)
        {
            error = string.Empty;
            if (payment == null)
            {
                error = "payment == null";
                return 0;
            }
            if (conn == null)
            {
                error = "conn == null";
                return 0;
            }
            SqlCommand command = new SqlCommand(spPaymentInsert, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inPayment_PersCard_Id",
                payment.Payment_PersCard_Id == 0 ? Convert.DBNull : payment.Payment_PersCard_Id);
            command.Parameters.AddWithValue("@inPayment_Date",
                payment.Payment_Date == DateTime.MinValue ? Convert.DBNull : payment.Payment_Date);
            command.Parameters.AddWithValue("@inPayment_Type",
                payment.Payment_Type == 0 ? Convert.DBNull : payment.Payment_Type);
            command.Parameters.AddWithValue("@inPayment_Amt", payment.Payment_Amt);
            command.Parameters.AddWithValue("@inPayment_Price", payment.Payment_Price);
            command.Parameters.AddWithValue("@inPayment_Sm", payment.Payment_Sm);
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
        //Изменить выплату
        public bool ModifyPayment(Payment payment, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            if (payment == null)
            {
                error = "payment == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spPaymentUpdate, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inPayment_Id", payment.Payment_Id);
            command.Parameters.AddWithValue("@inPayment_PersCard_Id",
                payment.Payment_PersCard_Id == 0 ? Convert.DBNull : payment.Payment_PersCard_Id);
            command.Parameters.AddWithValue("@inPayment_Date",
                payment.Payment_Date == DateTime.MinValue ? Convert.DBNull : payment.Payment_Date);
            command.Parameters.AddWithValue("@inPayment_Type",
                payment.Payment_Type == 0 ? Convert.DBNull : payment.Payment_Type);
            command.Parameters.AddWithValue("@inPayment_Amt", payment.Payment_Amt);
            command.Parameters.AddWithValue("@inPayment_Price", payment.Payment_Price);
            command.Parameters.AddWithValue("@inPayment_Sm", payment.Payment_Sm);
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
        //Удалить выплату
        public bool DeletePayment(int id, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spPaymentDelete, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inPayment_Id", id);
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
