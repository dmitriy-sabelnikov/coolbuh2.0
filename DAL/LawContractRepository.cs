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
    public class LawContractRepository
    {
        private SqlConnection conn;
        private string spLawContractSelect = "spLawContractSelect";
        private string spLawContractInsert = "spLawContractInsert";
        private string spLawContractUpdate = "spLawContractUpdate";
        private string spLawContractDelete = "spLawContractDelete";
        public LawContractRepository(SqlConnection connection)
        {
            conn = connection;
        }
        private void FillDataRec(SqlDataReader reader, LawContract lawContract)
        {
            int resInt = 0;
            DateTime resDate = DateTime.MinValue;
            decimal resDec = 0;

            if (int.TryParse(reader["LawContract_Id"].ToString(), out resInt))
            {
                lawContract.LawContract_Id = resInt;
            }

            if (int.TryParse(reader["LawContract_PersCard_Id"].ToString(), out resInt))
            {
                lawContract.LawContract_PersCard_Id = resInt;
            }
            if (int.TryParse(reader["LawContract_RefDep_Id"].ToString(), out resInt))
            {
                lawContract.LawContract_RefDep_Id = resInt;
            }
            if (DateTime.TryParse(reader["LawContract_Date"].ToString(), out resDate))
            {
                lawContract.LawContract_Date = resDate;
            }
            if (int.TryParse(reader["LawContract_Days"].ToString(), out resInt))
            {
                lawContract.LawContract_Days = resInt;
            }
            if (decimal.TryParse(reader["LawContract_Sm"].ToString(), out resDec))
            {
                lawContract.LawContract_Sm = resDec;
            }
            if (DateTime.TryParse(reader["LawContract_PayDate"].ToString(), out resDate))
            {
                lawContract.LawContract_PayDate = resDate;
            }
        }
        //Получить список договоров ГПХ
        public List<LawContract> GetAllLawContracts(out string error)
        {
            error = string.Empty;

            List<LawContract> lawContracts = new List<LawContract>();

            if (conn == null)
            {
                error = "conn == null";
                return lawContracts;
            }

            SqlCommand command = new SqlCommand(spLawContractSelect, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    LawContract lawContract = new LawContract();
                    FillDataRec(reader, lawContract);
                    lawContracts.Add(lawContract);
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
            return lawContracts;
        }
        //Получить договора ГПХ по параметрам
        public List<LawContract> GetLawContractsByParams(int lawContract_id, int refDep_id, DateTime lawContract_dateBeg, DateTime lawContract_dateEnd, out string error)
        {
            error = string.Empty;

            List<LawContract> lawContracts = new List<LawContract>();

            if (conn == null)
            {
                error = "conn == null";
                return lawContracts;
            }
            if (lawContract_id == 0 && refDep_id == 0 && lawContract_dateBeg == DateTime.MinValue && lawContract_dateEnd == DateTime.MinValue)
            {
                error = "Не задані вхідні параметри";
                return lawContracts;
            }
            if (lawContract_dateBeg == DateTime.MinValue || lawContract_dateEnd == DateTime.MinValue)
            {
                error = "Не заданий період";
                return lawContracts;
            }

            SqlCommand command = new SqlCommand(spLawContractSelect, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;

            command.Parameters.AddWithValue("@inLawContract_Id", lawContract_id);
            command.Parameters.AddWithValue("@inLawContract_RefDep_Id", refDep_id);
            command.Parameters.AddWithValue("@inLawContract_DateBeg", (lawContract_dateBeg == DateTime.MinValue) ? Convert.DBNull : lawContract_dateBeg);
            command.Parameters.AddWithValue("@inLawContract_DateEnd", (lawContract_dateEnd == DateTime.MinValue) ? Convert.DBNull : lawContract_dateEnd);

            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    LawContract lawContract = new LawContract();
                    FillDataRec(reader, lawContract);
                    lawContracts.Add(lawContract);
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
            return lawContracts;
        }
        //Добавить договора ГПХ
        public int AddLawContract(LawContract lawContract, out string error)
        {
            error = string.Empty;
            if (lawContract == null)
            {
                error = "lawContract == null";
                return 0;
            }
            if (conn == null)
            {
                error = "conn == null";
                return 0;
            }
            SqlCommand command = new SqlCommand(spLawContractInsert, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inLawContract_PersCard_Id", lawContract.LawContract_PersCard_Id == 0 ? Convert.DBNull : lawContract.LawContract_PersCard_Id);
            command.Parameters.AddWithValue("@inLawContract_RefDep_Id", lawContract.LawContract_RefDep_Id == 0 ? Convert.DBNull : lawContract.LawContract_RefDep_Id);
            command.Parameters.AddWithValue("@inLawContract_Date", lawContract.LawContract_Date == DateTime.MinValue ? Convert.DBNull : lawContract.LawContract_Date);
            command.Parameters.AddWithValue("@inLawContract_Days", lawContract.LawContract_Days);
            command.Parameters.AddWithValue("@inLawContract_Sm", lawContract.LawContract_Sm);
            command.Parameters.AddWithValue("@inLawContract_PayDate", lawContract.LawContract_PayDate == DateTime.MinValue ? Convert.DBNull : lawContract.LawContract_PayDate);
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
        //Изменить запись договора ГПХ
        public bool ModifyLawContract(LawContract lawContract, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            if (lawContract == null)
            {
                error = "lawContract == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spLawContractUpdate, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inLawContract_Id", lawContract.LawContract_Id);
            command.Parameters.AddWithValue("@inLawContract_PersCard_Id", lawContract.LawContract_PersCard_Id == 0 ? Convert.DBNull : lawContract.LawContract_PersCard_Id);
            command.Parameters.AddWithValue("@inLawContract_RefDep_Id", lawContract.LawContract_RefDep_Id == 0 ? Convert.DBNull : lawContract.LawContract_RefDep_Id);
            command.Parameters.AddWithValue("@inLawContract_Date", lawContract.LawContract_Date == DateTime.MinValue ? Convert.DBNull : lawContract.LawContract_Date);
            command.Parameters.AddWithValue("@inLawContract_Days", lawContract.LawContract_Days);
            command.Parameters.AddWithValue("@inLawContract_Sm", lawContract.LawContract_Sm);
            command.Parameters.AddWithValue("@inLawContract_PayDate", lawContract.LawContract_PayDate == DateTime.MinValue ? Convert.DBNull : lawContract.LawContract_PayDate);
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
        //Удалить запись договора ГПХ
        public bool DeleteLawContract(int id, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spLawContractDelete, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inLawContract_Id", id);
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
