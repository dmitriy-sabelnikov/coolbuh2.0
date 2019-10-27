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
    public class AddPaymentRepository
    {
        private SqlConnection conn;
        private string spAddPaymentSelect = "spAddPaymentSelect";
        private string spAddPaymentInsert = "spAddPaymentInsert";
        private string spAddPaymentUpdate = "spAddPaymentUpdate";
        private string spAddPaymentDelete = "spAddPaymentDelete";
        public AddPaymentRepository(SqlConnection connection)
        {
            conn = connection;
        }

        private void FillDataRec(SqlDataReader reader, AddPayment addPayment)
        {
            int resInt = 0;
            DateTime resDate = DateTime.MinValue;
            decimal resDec = 0;

            if (int.TryParse(reader["AddPayment_Id"].ToString(), out resInt))
            {
                addPayment.AddPayment_Id = resInt;
            }

            if (int.TryParse(reader["AddPayment_PersCard_Id"].ToString(), out resInt))
            {
                addPayment.AddPayment_PersCard_Id = resInt;
            }
            if (DateTime.TryParse(reader["AddPayment_Date"].ToString(), out resDate))
            {
                addPayment.AddPayment_Date = resDate;
            }
            if (int.TryParse(reader["AddPayment_TypeAddPayment_Id"].ToString(), out resInt))
            {
                addPayment.AddPayment_TypeAddPayment_Id = resInt;
            }

            if (decimal.TryParse(reader["AddPayment_Sm"].ToString(), out resDec))
            {
                addPayment.AddPayment_Sm = resDec;
            }
        }
        //Получить список доп выплат
        public List<AddPayment> GetAllAddPayments(out string error)
        {
            error = string.Empty;

            List<AddPayment> addPayments = new List<AddPayment>();

            if (conn == null)
            {
                error = "conn == null";
                return addPayments;
            }

            SqlCommand command = new SqlCommand(spAddPaymentSelect, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    AddPayment addPayment = new AddPayment();
                    FillDataRec(reader, addPayment);
                    addPayments.Add(addPayment);
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
            return addPayments;
        }
        //Получить список доп выплат по параметрам
        public List<AddPayment> GetAddPaymentsByParams(int addPayment_id, int typeAddPayment_id, DateTime addPayment_dateBeg, DateTime addPayment_dateEnd, out string error)
        {
            error = string.Empty;

            List<AddPayment> addPayments = new List<AddPayment>();

            if (conn == null)
            {
                error = "conn == null";
                return addPayments;
            }
            if (addPayment_id == 0 && typeAddPayment_id == 0 && addPayment_dateBeg == DateTime.MinValue && addPayment_dateEnd == DateTime.MinValue)
            {
                error = "Не задані вхідні параметри";
                return addPayments;
            }
            if (addPayment_dateBeg == DateTime.MinValue || addPayment_dateEnd == DateTime.MinValue)
            {
                error = "Не заданий період";
                return addPayments;
            }

            SqlCommand command = new SqlCommand(spAddPaymentSelect, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;

            command.Parameters.AddWithValue("@inAddPayment_Id", addPayment_id);
            command.Parameters.AddWithValue("@inAddPayment_TypeAddPayment_id", typeAddPayment_id);
            command.Parameters.AddWithValue("@inAddPayment_DateBeg", (addPayment_dateBeg == DateTime.MinValue) ? Convert.DBNull : addPayment_dateBeg);
            command.Parameters.AddWithValue("@inAddPayment_DateEnd", (addPayment_dateEnd == DateTime.MinValue) ? Convert.DBNull : addPayment_dateEnd);

            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    AddPayment addPayment = new AddPayment();
                    FillDataRec(reader, addPayment);
                    addPayments.Add(addPayment);
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
            return addPayments;
        }
        //Добавить доп выплату
        public int AddAddPayment(AddPayment addPayment, out string error)
        {
            error = string.Empty;
            if (addPayment == null)
            {
                error = "addPayment == null";
                return 0;
            }
            if (conn == null)
            {
                error = "conn == null";
                return 0;
            }
            SqlCommand command = new SqlCommand(spAddPaymentInsert, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inAddPayment_PersCard_Id", addPayment.AddPayment_PersCard_Id == 0 
                ? Convert.DBNull : addPayment.AddPayment_PersCard_Id);
            command.Parameters.AddWithValue("@inAddPayment_TypeAddPayment_Id", addPayment.AddPayment_TypeAddPayment_Id == 0 
                ? Convert.DBNull : addPayment.AddPayment_TypeAddPayment_Id);
            command.Parameters.AddWithValue("@inAddPayment_Date", addPayment.AddPayment_Date == DateTime.MinValue 
                ? Convert.DBNull : addPayment.AddPayment_Date);
            command.Parameters.AddWithValue("@inAddPayment_Sm", addPayment.AddPayment_Sm);
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
        //Изменить доп выплату
        public bool ModifyAddPayment(AddPayment addPayment, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            if (addPayment == null)
            {
                error = "addPayment == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spAddPaymentUpdate, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inAddPayment_Id", addPayment.AddPayment_Id);
            command.Parameters.AddWithValue("@inAddPayment_PersCard_Id", addPayment.AddPayment_PersCard_Id == 0 
                ? Convert.DBNull : addPayment.AddPayment_PersCard_Id);
            command.Parameters.AddWithValue("@inAddPayment_TypeAddPayment_Id", addPayment.AddPayment_TypeAddPayment_Id == 0 
                ? Convert.DBNull : addPayment.AddPayment_TypeAddPayment_Id);
            command.Parameters.AddWithValue("@inAddPayment_Date", addPayment.AddPayment_Date == DateTime.MinValue 
                ? Convert.DBNull : addPayment.AddPayment_Date);
            command.Parameters.AddWithValue("@inAddPayment_Sm", addPayment.AddPayment_Sm);
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
        //Удалить запись больничных
        public bool DeleteAddPayment(int id, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spAddPaymentDelete, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inAddPayment_Id", id);
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
