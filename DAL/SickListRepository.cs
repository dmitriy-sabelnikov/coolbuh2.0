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
    public class SickListRepository
    {
        private SqlConnection conn;
        private string spSickListSelect = "spSickListSelect";
        private string spSickListInsert = "spSickListInsert";
        private string spSickListUpdate = "spSickListUpdate";
        private string spSickListDelete = "spSickListDelete";
        public SickListRepository(SqlConnection connection)
        {
            conn = connection;
        }
        private void FillDataRec(SqlDataReader reader, SickList sickList)
        {
            int resInt = 0;
            DateTime resDate = DateTime.MinValue;
            decimal resDec = 0;

            if (int.TryParse(reader["SickList_Id"].ToString(), out resInt))
            {
                sickList.SickList_Id = resInt;
            }

            if (int.TryParse(reader["SickList_PersCard_Id"].ToString(), out resInt))
            {
                sickList.SickList_PersCard_Id = resInt;
            }
            if (int.TryParse(reader["SickList_RefDep_Id"].ToString(), out resInt))
            {
                sickList.SickList_RefDep_Id = resInt;
            }
            if (DateTime.TryParse(reader["SickList_Date"].ToString(), out resDate))
            {
                sickList.SickList_Date = resDate;
            }
            if (int.TryParse(reader["SickList_DaysEntprs"].ToString(), out resInt))
            {
                sickList.SickList_DaysEntprs = resInt;
            }
            if (decimal.TryParse(reader["SickList_SmEntprs"].ToString(), out resDec))
            {
                sickList.SickList_SmEntprs = resDec;
            }
            if (int.TryParse(reader["SickList_DaysSocInsrnc"].ToString(), out resInt))
            {
                sickList.SickList_DaysSocInsrnc = resInt;
            }
            if (decimal.TryParse(reader["SickList_SmSocInsrnc"].ToString(), out resDec))
            {
                sickList.SickList_SmSocInsrnc = resDec;
            }
            if (DateTime.TryParse(reader["SickList_PayDate"].ToString(), out resDate))
            {
                sickList.SickList_PayDate = resDate;
            }
            if (int.TryParse(reader["SickList_DaysTmpDis"].ToString(), out resInt))
            {
                sickList.SickList_DaysTmpDis = resInt;
            }
            if (decimal.TryParse(reader["SickList_ResSm"].ToString(), out resDec))
            {
                sickList.SickList_ResSm = resDec;
            }
        }
        //Получить список больничных
        public List<SickList> GetAllSickLists(out string error)
        {
            error = string.Empty;

            List<SickList> sickLists = new List<SickList>();

            if (conn == null)
            {
                error = "conn == null";
                return sickLists;
            }

            SqlCommand command = new SqlCommand(spSickListSelect, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    SickList sickList = new SickList();
                    FillDataRec(reader, sickList);
                    sickLists.Add(sickList);
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
            return sickLists;
        }
        //Получить больничные по параметрам
        public List<SickList> GetSickListsByParams(int sickList_id, int refDep_id, DateTime sickList_dateBeg, DateTime sickList_dateEnd, out string error)
        {
            error = string.Empty;

            List<SickList> sickLists = new List<SickList>();

            if (conn == null)
            {
                error = "conn == null";
                return sickLists;
            }
            if (sickList_id == 0 && refDep_id == 0 && sickList_dateBeg == DateTime.MinValue && sickList_dateEnd == DateTime.MinValue)
            {
                error = "Не задані вхідні параметри";
                return sickLists;
            }
            if (sickList_dateBeg == DateTime.MinValue || sickList_dateEnd == DateTime.MinValue)
            {
                error = "Не заданий період";
                return sickLists;
            }

            SqlCommand command = new SqlCommand(spSickListSelect, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;

            command.Parameters.AddWithValue("@inSickList_Id", sickList_id);
            command.Parameters.AddWithValue("@inSickList_RefDep_Id", refDep_id);
            command.Parameters.AddWithValue("@inSickList_DateBeg", (sickList_dateBeg == DateTime.MinValue) ? Convert.DBNull : sickList_dateBeg);
            command.Parameters.AddWithValue("@inSickList_DateEnd", (sickList_dateEnd == DateTime.MinValue) ? Convert.DBNull : sickList_dateEnd);

            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    SickList sickList = new SickList();
                    FillDataRec(reader, sickList);
                    sickLists.Add(sickList);
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
            return sickLists;
        }
        //Добавить больничный
        public int AddSickList(SickList sickList, out string error)
        {
            error = string.Empty;
            if (sickList == null)
            {
                error = "sickList == null";
                return 0;
            }
            if (conn == null)
            {
                error = "conn == null";
                return 0;
            }
            SqlCommand command = new SqlCommand(spSickListInsert, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inSickList_PersCard_Id", sickList.SickList_PersCard_Id == 0 ? Convert.DBNull : sickList.SickList_PersCard_Id);
            command.Parameters.AddWithValue("@inSickList_RefDep_Id", sickList.SickList_RefDep_Id == 0 ? Convert.DBNull : sickList.SickList_RefDep_Id);
            command.Parameters.AddWithValue("@inSickList_Date", sickList.SickList_Date == DateTime.MinValue ? Convert.DBNull : sickList.SickList_Date);
            command.Parameters.AddWithValue("@inSickList_DaysEntprs", sickList.SickList_DaysEntprs);
            command.Parameters.AddWithValue("@inSickList_SmEntprs", sickList.SickList_SmEntprs);
            command.Parameters.AddWithValue("@inSickList_DaysSocInsrnc", sickList.SickList_DaysSocInsrnc);
            command.Parameters.AddWithValue("@inSickList_SmSocInsrnc", sickList.SickList_SmSocInsrnc);
            command.Parameters.AddWithValue("@inSickList_PayDate", sickList.SickList_PayDate == DateTime.MinValue ? Convert.DBNull : sickList.SickList_PayDate);
            command.Parameters.AddWithValue("@inSickList_DaysTmpDis", sickList.SickList_DaysTmpDis);
            command.Parameters.AddWithValue("@inSickList_ResSm", sickList.SickList_ResSm);
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
        //Изменить запись больничного
        public bool ModifySickList(SickList sickList, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            if (sickList == null)
            {
                error = "sickList == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spSickListUpdate, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inSickList_Id", sickList.SickList_Id);
            command.Parameters.AddWithValue("@inSickList_PersCard_Id", sickList.SickList_PersCard_Id == 0 ? Convert.DBNull : sickList.SickList_PersCard_Id);
            command.Parameters.AddWithValue("@inSickList_RefDep_Id", sickList.SickList_RefDep_Id == 0 ? Convert.DBNull : sickList.SickList_RefDep_Id);
            command.Parameters.AddWithValue("@inSickList_Date", sickList.SickList_Date == DateTime.MinValue ? Convert.DBNull : sickList.SickList_Date);
            command.Parameters.AddWithValue("@inSickList_DaysEntprs", sickList.SickList_DaysEntprs);
            command.Parameters.AddWithValue("@inSickList_SmEntprs", sickList.SickList_SmEntprs);
            command.Parameters.AddWithValue("@inSickList_DaysSocInsrnc", sickList.SickList_DaysSocInsrnc);
            command.Parameters.AddWithValue("@inSickList_SmSocInsrnc", sickList.SickList_SmSocInsrnc);
            command.Parameters.AddWithValue("@inSickList_PayDate", sickList.SickList_PayDate == DateTime.MinValue ? Convert.DBNull : sickList.SickList_PayDate);
            command.Parameters.AddWithValue("@inSickList_DaysTmpDis", sickList.SickList_DaysTmpDis);
            command.Parameters.AddWithValue("@inSickList_ResSm", sickList.SickList_ResSm);
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
        public bool DeleteSickList(int id, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spSickListDelete, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inSickList_Id", id);
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
