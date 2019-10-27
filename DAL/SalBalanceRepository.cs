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
    public class SalBalanceRepository
    {
        private SqlConnection conn;
        private string spSalBalanceSelect = "spSalBalanceSelect";
        private string spSalBalanceInsert = "spSalBalanceInsert";
        private string spSalBalanceUpdate = "spSalBalanceUpdate";
        private string spSalBalanceDelete = "spSalBalanceDelete";
        private string spSalBalanceCalc   = "spSalBalanceCalc";

        public SalBalanceRepository(SqlConnection connection)
        {
            conn = connection;
        }
        private void FillDataRec(SqlDataReader reader, SalBalance SalBalance)
        {
            int resInt = 0;
            DateTime resDate = DateTime.MinValue;
            decimal resDec = 0;
            if (int.TryParse(reader["SalBalance_Id"].ToString(), out resInt))
            {
                SalBalance.SalBalance_Id = resInt;
            }
            if (int.TryParse(reader["SalBalance_PersCard_Id"].ToString(), out resInt))
            {
                SalBalance.SalBalance_PersCard_Id = resInt;
            }
            if (DateTime.TryParse(reader["SalBalance_Date"].ToString(), out resDate))
            {
                SalBalance.SalBalance_Date = resDate;
            }
            if (decimal.TryParse(reader["SalBalance_BegMonthSm"].ToString(), out resDec))
            {
                SalBalance.SalBalance_BegMonthSm = resDec;
            }
            if (decimal.TryParse(reader["SalBalance_EndMonthSm"].ToString(), out resDec))
            {
                SalBalance.SalBalance_EndMonthSm = resDec;
            }
            if (int.TryParse(reader["SalBalance_Flg"].ToString(), out resInt))
            {
                SalBalance.SalBalance_Flg = resInt;
            }
        }
        //Рассчет баланса
        public bool CalcBalance(DateTime datBeg, DateTime datEnd, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            if(datBeg > datEnd)
            {
                error = "datBeg > datEnd";
                return false;
            }
            SqlCommand command = new SqlCommand(spSalBalanceCalc, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inDatBeg", datBeg);
            command.Parameters.AddWithValue("@inDatEnd", datEnd);
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

        //Получить сальдо
        public List<SalBalance> GetAllSalBalancies(out string error)
        {
            error = string.Empty;

            List<SalBalance> salBalancies = new List<SalBalance>();

            if (conn == null)
            {
                error = "conn == null";
                return salBalancies;
            }

            SqlCommand command = new SqlCommand(spSalBalanceSelect, conn);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    SalBalance salBalance = new SalBalance();
                    FillDataRec(reader, salBalance);
                    salBalancies.Add(salBalance);
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
            return salBalancies;
        }
        //Получить сальдо по параметрам
        public List<SalBalance> GetSalBalanceByParams(int persCard_Id, DateTime datBeg, DateTime datEnd, out string error)
        {
            error = string.Empty;

            if (conn == null)
            {
                error = "conn == null";
                return null;
            }
            if (persCard_Id == 0 && datBeg == DateTime.MinValue && datEnd == DateTime.MinValue)
            {
                error = "Не задані вхідні параметри";
                return null;
            }
            List<SalBalance> salbalancies = new List<SalBalance>();

            SqlCommand command = new SqlCommand(spSalBalanceSelect, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;

            command.Parameters.AddWithValue("@inSalBalance_PersCard_Id", persCard_Id);
            command.Parameters.AddWithValue("@inSalBalance_DateBeg", datBeg != DateTime.MinValue ? datBeg : Convert.DBNull);
            command.Parameters.AddWithValue("@inSalBalance_DateEnd", datEnd != DateTime.MinValue ? datEnd : Convert.DBNull);

            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    SalBalance salBalance = new SalBalance();
                    FillDataRec(reader, salBalance);
                    salbalancies.Add(salBalance);
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                salbalancies = null;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
            return salbalancies;
        }
        //Добавить сальдо
        public int AddSalBalance(SalBalance salBalance, out string error)
        {
            error = string.Empty;
            if (salBalance == null)
            {
                error = "salBalance == null";
                return 0;
            }
            if (conn == null)
            {
                error = "conn == null";
                return 0;
            }
            SqlCommand command = new SqlCommand(spSalBalanceInsert, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inSalBalance_PersCard_Id",
                salBalance.SalBalance_PersCard_Id == 0 ? Convert.DBNull : salBalance.SalBalance_PersCard_Id);
            command.Parameters.AddWithValue("@inSalBalance_Date",salBalance.SalBalance_Date);
            command.Parameters.AddWithValue("@inSalBalance_BegMonthSm", salBalance.SalBalance_BegMonthSm);
            command.Parameters.AddWithValue("@inSalBalance_EndMonthSm", salBalance.SalBalance_EndMonthSm);
            command.Parameters.AddWithValue("@inSalBalance_Flg", salBalance.SalBalance_Flg);
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
        //Изменить сальдо
        public bool ModifySalBalance(SalBalance salBalance, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            if (salBalance == null)
            {
                error = "salBalance == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spSalBalanceUpdate, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inSalBalance_Id", salBalance.SalBalance_Id);
            command.Parameters.AddWithValue("@inSalBalance_PersCard_Id",
                salBalance.SalBalance_PersCard_Id == 0 ? Convert.DBNull : salBalance.SalBalance_PersCard_Id);
            command.Parameters.AddWithValue("@inSalBalance_Date", salBalance.SalBalance_Date);
            command.Parameters.AddWithValue("@inSalBalance_BegMonthSm", salBalance.SalBalance_BegMonthSm);
            command.Parameters.AddWithValue("@inSalBalance_EndMonthSm", salBalance.SalBalance_EndMonthSm);
            command.Parameters.AddWithValue("@inSalBalance_Flg", salBalance.SalBalance_Flg);
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
        //Удалить сальдо
        public bool DeleteSalBalance(int id, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spSalBalanceDelete, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inSalBalance_Id", id);
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
