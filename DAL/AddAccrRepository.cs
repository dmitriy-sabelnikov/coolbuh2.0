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
    public class AddAccrRepository
    {
        private SqlConnection conn;
        private string spAddAccrSelect = "spAddAccrSelect";
        private string spAddAccrInsert = "spAddAccrInsert";
        private string spAddAccrUpdate = "spAddAccrUpdate";
        private string spAddAccrDelete = "spAddAccrDelete";

        public AddAccrRepository(SqlConnection connection)
        {
            conn = connection;
        }

        private void FillDataRec(SqlDataReader reader, AddAccr addAccr)
        {
            int resInt = 0;
            DateTime resDate = DateTime.MinValue;
            decimal resDec = 0;

            if (int.TryParse(reader["AddAccr_Id"].ToString(), out resInt))
            {
                addAccr.AddAccr_Id = resInt;
            }

            if (int.TryParse(reader["AddAccr_PersCard_Id"].ToString(), out resInt))
            {
                addAccr.AddAccr_PersCard_Id = resInt;
            }
            if (int.TryParse(reader["AddAccr_RefDep_Id"].ToString(), out resInt))
            {
                addAccr.AddAccr_RefDep_Id = resInt;
            }
            if (int.TryParse(reader["AddAccr_RefTypeAddAccr_Id"].ToString(), out resInt))
            {
                addAccr.AddAccr_RefTypeAddAccr_Id = resInt;
            }
            if (DateTime.TryParse(reader["AddAccr_Date"].ToString(), out resDate))
            {
                addAccr.AddAccr_Date = resDate;
            }
            if (decimal.TryParse(reader["AddAccr_Sm"].ToString(), out resDec))
            {
                addAccr.AddAccr_Sm = resDec;
            }
        }
        //Получить список доп начислений
        public List<AddAccr> GetAllAddAccrs(out string error)
        {
            error = string.Empty;

            List<AddAccr> addAccrs = new List<AddAccr>();

            if (conn == null)
            {
                error = "conn == null";
                return addAccrs;
            }

            SqlCommand command = new SqlCommand(spAddAccrSelect, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    AddAccr addAccr = new AddAccr();
                    FillDataRec(reader, addAccr);
                    addAccrs.Add(addAccr);
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
            return addAccrs;
        }
        //Получить доп. начисления по параметрам
        public List<AddAccr> GetAddAccrByParams(int addAccr_id, int refDep_id, DateTime addAccr_dateBeg, DateTime addAccr_dateEnd, out string error)
        {
            error = string.Empty;

            if (conn == null)
            {
                error = "conn == null";
                return null;
            }
            if (addAccr_id == 0 && refDep_id == 0 && addAccr_dateBeg == DateTime.MinValue && addAccr_dateEnd == DateTime.MinValue)
            {
                error = "Не задані вхідні параметри";
                return null;
            }
            if (addAccr_dateBeg == DateTime.MinValue || addAccr_dateEnd == DateTime.MinValue)
            {
                error = "Не заданий період";
                return null;
            }

            List<AddAccr> addAccrs = new List<AddAccr>();

            SqlCommand command = new SqlCommand(spAddAccrSelect, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;

            command.Parameters.AddWithValue("@inAddAccr_Id", addAccr_id);
            command.Parameters.AddWithValue("@inAddAccr_RefDep_Id", refDep_id);
            command.Parameters.AddWithValue("@inAddAccr_DateBeg", (addAccr_dateBeg == DateTime.MinValue) ? Convert.DBNull : addAccr_dateBeg);
            command.Parameters.AddWithValue("@inAddAccr_DateEnd", (addAccr_dateEnd == DateTime.MinValue) ? Convert.DBNull : addAccr_dateEnd);

            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    AddAccr addAccr = new AddAccr();
                    FillDataRec(reader, addAccr);
                    addAccrs.Add(addAccr);
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                addAccrs = null;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
            return addAccrs;
        }
        //Добавить доп. начисление
        public int AddAddAccr(AddAccr addAccr, out string error)
        {
            error = string.Empty;
            if (addAccr == null)
            {
                error = "addAccr == null";
                return 0;
            }
            if (conn == null)
            {
                error = "conn == null";
                return 0;
            }
            SqlCommand command = new SqlCommand(spAddAccrInsert, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inAddAccr_PersCard_Id", 
                addAccr.AddAccr_PersCard_Id == 0 ? Convert.DBNull : addAccr.AddAccr_PersCard_Id);
            command.Parameters.AddWithValue("@inAddAccr_RefDep_Id", 
                addAccr.AddAccr_RefDep_Id == 0 ? Convert.DBNull : addAccr.AddAccr_RefDep_Id);
            command.Parameters.AddWithValue("@inAddAccr_RefTypeAddAccr_Id", 
                addAccr.AddAccr_RefTypeAddAccr_Id == 0 ? Convert.DBNull : addAccr.AddAccr_RefTypeAddAccr_Id);
            command.Parameters.AddWithValue("@inAddAccr_Date", 
                addAccr.AddAccr_Date == DateTime.MinValue ? Convert.DBNull : addAccr.AddAccr_Date);
            command.Parameters.AddWithValue("@inAddAccr_Sm", addAccr.AddAccr_Sm);
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
            return id; ;
        }
        //Изменить доп. начисление
        public bool ModifyAddAccr(AddAccr addAccr, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            if (addAccr == null)
            {
                error = "addAccr == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spAddAccrUpdate, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inAddAccr_Id", addAccr.AddAccr_Id);
            command.Parameters.AddWithValue("@inAddAccr_PersCard_Id",
                addAccr.AddAccr_PersCard_Id == 0 ? Convert.DBNull : addAccr.AddAccr_PersCard_Id);
            command.Parameters.AddWithValue("@inAddAccr_RefDep_Id",
                addAccr.AddAccr_RefDep_Id == 0 ? Convert.DBNull : addAccr.AddAccr_RefDep_Id);
            command.Parameters.AddWithValue("@inAddAccr_RefTypeAddAccr_Id",
                addAccr.AddAccr_RefTypeAddAccr_Id == 0 ? Convert.DBNull : addAccr.AddAccr_RefTypeAddAccr_Id);
            command.Parameters.AddWithValue("@inAddAccr_Date",
                addAccr.AddAccr_Date == DateTime.MinValue ? Convert.DBNull : addAccr.AddAccr_Date);
            command.Parameters.AddWithValue("@inAddAccr_Sm", addAccr.AddAccr_Sm);
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
        //Удалить доп. начисление
        public bool DeleteAddAccr(int id, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spAddAccrDelete, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inAddAccr_Id", id);
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
