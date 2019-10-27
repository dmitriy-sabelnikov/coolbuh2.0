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
    public class IncTaxRepository
    {
        private SqlConnection conn;
        private string spIncTaxSelect = "spIncTaxSelect";
        private string spIncTaxInsert = "spIncTaxInsert";
        private string spIncTaxUpdate = "spIncTaxUpdate";
        private string spIncTaxDelete = "spIncTaxDelete";
        public IncTaxRepository(SqlConnection connection)
        {
            conn = connection;
        }
        private void FillDataRec(SqlDataReader reader, IncTax incTax)
        {
            int resInt = 0;
            DateTime resDate = DateTime.MinValue;
            decimal resDec = 0;

            if (int.TryParse(reader["IncTax_Id"].ToString(), out resInt))
            {
                incTax.IncTax_Id = resInt;
            }
            if (int.TryParse(reader["IncTax_PersCard_Id"].ToString(), out resInt))
            {
                incTax.IncTax_PersCard_Id = resInt;
            }
            if (DateTime.TryParse(reader["IncTax_Date"].ToString(), out resDate))
            {
                incTax.IncTax_Date = resDate;
            }
            if (decimal.TryParse(reader["IncTax_Sm"].ToString(), out resDec))
            {
                incTax.IncTax_Sm = resDec;
            }
        }
        //Получить список сумм  подоходного налога
        public List<IncTax> GetAllIncTaxs(out string error)
        {
            error = string.Empty;

            List<IncTax> incTaxs = new List<IncTax>();

            if (conn == null)
            {
                error = "conn == null";
                return incTaxs;
            }

            SqlCommand command = new SqlCommand(spIncTaxSelect, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    IncTax incTax = new IncTax();
                    FillDataRec(reader, incTax);
                    incTaxs.Add(incTax);
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
            return incTaxs;
        }

        //Получить суммы подоходного налога по параметрам
        public List<IncTax> GetIncTaxByParams(int incTax_id, DateTime incTax_dateBeg, DateTime incTax_dateEnd, out string error)
        {
            error = string.Empty;

            if (conn == null)
            {
                error = "conn == null";
                return null;
            }
            if (incTax_id == 0 && incTax_dateBeg == DateTime.MinValue && incTax_dateEnd == DateTime.MinValue)
            {
                error = "Не задані вхідні параметри";
                return null;
            }
            if (incTax_dateBeg == DateTime.MinValue || incTax_dateEnd == DateTime.MinValue)
            {
                error = "Не заданий період";
                return null;
            }

            List<IncTax> incTaxs = new List<IncTax>();

            SqlCommand command = new SqlCommand(spIncTaxSelect, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;

            command.Parameters.AddWithValue("@inIncTax_Id", incTax_id);
            command.Parameters.AddWithValue("@inIncTax_DateBeg", (incTax_dateBeg == DateTime.MinValue) ? Convert.DBNull : incTax_dateBeg);
            command.Parameters.AddWithValue("@inIncTax_DateEnd", (incTax_dateEnd == DateTime.MinValue) ? Convert.DBNull : incTax_dateEnd);

            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    IncTax incTax = new IncTax();
                    FillDataRec(reader, incTax);
                    incTaxs.Add(incTax);
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                incTaxs = null;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
            return incTaxs;
        }
        //Добавить сумму подоходного налога
        public int AddIncTax(IncTax incTax, out string error)
        {
            error = string.Empty;
            if (incTax == null)
            {
                error = "incTax == null";
                return 0;
            }
            if (conn == null)
            {
                error = "conn == null";
                return 0;
            }
            SqlCommand command = new SqlCommand(spIncTaxInsert, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inIncTax_PersCard_Id",
                incTax.IncTax_PersCard_Id == 0 ? Convert.DBNull : incTax.IncTax_PersCard_Id);
            command.Parameters.AddWithValue("@inIncTax_Date",
                incTax.IncTax_Date == DateTime.MinValue ? Convert.DBNull : incTax.IncTax_Date);
            command.Parameters.AddWithValue("@inIncTax_Sm", incTax.IncTax_Sm);
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
        //Изменить сумму подоходного налога
        public bool ModifyIncTax(IncTax incTax, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            if (incTax == null)
            {
                error = "incTax == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spIncTaxUpdate, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inIncTax_Id", incTax.IncTax_Id);
            command.Parameters.AddWithValue("@inIncTax_PersCard_Id",
                incTax.IncTax_PersCard_Id == 0 ? Convert.DBNull : incTax.IncTax_PersCard_Id);
            command.Parameters.AddWithValue("@inIncTax_Date",
                incTax.IncTax_Date == DateTime.MinValue ? Convert.DBNull : incTax.IncTax_Date);
            command.Parameters.AddWithValue("@inIncTax_Sm", incTax.IncTax_Sm);
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
        //Удалить сумму подоходного налога
        public bool DeleteIncTax(int id, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spIncTaxDelete, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inIncTax_Id", id);
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
