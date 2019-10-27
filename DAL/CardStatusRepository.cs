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
    public class CardStatusRepository
    {
        private SqlConnection conn;
        private string spCardStatusSelect = "spCardStatusSelect";
        private string spCardStatusInsert = "spCardStatusInsert";
        private string spCardStatusUpdate = "spCardStatusUpdate";
        private string spCardStatusDelete = "spCardStatusDelete";
        public CardStatusRepository(SqlConnection connection)
        {
            conn = connection;
        }
        private void FillDataRec(SqlDataReader reader, CardStatus CardStatus)
        {
            int resInt = 0;
            DateTime resDate = DateTime.MinValue;
            if (int.TryParse(reader["CardStatus_Id"].ToString(), out resInt))
            {
                CardStatus.CardStatus_Id = resInt;
            }
            if (int.TryParse(reader["CardStatus_PersCard_Id"].ToString(), out resInt))
            {
                CardStatus.CardStatus_PersCard_Id = resInt;
            }
            if (DateTime.TryParse(reader["CardStatus_PerBeg"].ToString(), out resDate))
            {
                CardStatus.CardStatus_PerBeg = resDate;
            }
            if (DateTime.TryParse(reader["CardStatus_PerEnd"].ToString(), out resDate))
            {
                CardStatus.CardStatus_PerEnd = resDate;
            }
            if (int.TryParse(reader["CardStatus_Type"].ToString(), out resInt))
            {
                CardStatus.CardStatus_Type = resInt;
            }
        }
        //Получить интервалы статуса работников
        public List<CardStatus> GetAllCardStatuses(out string error)
        {
            error = string.Empty;

            List<CardStatus> cardStatuses = new List<CardStatus>();

            if (conn == null)
            {
                error = "conn == null";
                return cardStatuses;
            }

            SqlCommand command = new SqlCommand(spCardStatusSelect, conn);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    CardStatus cardStatus = new CardStatus();
                    FillDataRec(reader, cardStatus);
                    cardStatuses.Add(cardStatus);
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
            return cardStatuses;
        }
        //Получить интервалы статуса работника по параметрам
        public List<CardStatus> GetCardStatusByParams(int persCard_Id, out string error)
        {
            error = string.Empty;

            if (conn == null)
            {
                error = "conn == null";
                return null;
            }
            if (persCard_Id == 0)
            {
                error = "Не задані вхідні параметри";
                return null;
            }
            List<CardStatus> сardStatuses = new List<CardStatus>();

            SqlCommand command = new SqlCommand(spCardStatusSelect, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;

            command.Parameters.AddWithValue("@inCardStatus_PersCard_Id", persCard_Id);

            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CardStatus сardStatus = new CardStatus();
                    FillDataRec(reader, сardStatus);
                    сardStatuses.Add(сardStatus);
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                сardStatuses = null;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
            return сardStatuses;
        }
        //Добавить интервал статуса работника
        public int AddCardStatus(CardStatus сardStatus, out string error)
        {
            error = string.Empty;
            if (сardStatus == null)
            {
                error = "сardStatus == null";
                return 0;
            }
            if (conn == null)
            {
                error = "conn == null";
                return 0;
            }
            SqlCommand command = new SqlCommand(spCardStatusInsert, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inCardStatus_PersCard_Id",
                сardStatus.CardStatus_PersCard_Id == 0 ? Convert.DBNull : сardStatus.CardStatus_PersCard_Id);
            command.Parameters.AddWithValue("@inCardStatus_PerBeg",
                сardStatus.CardStatus_PerBeg == DateTime.MinValue ? Convert.DBNull : сardStatus.CardStatus_PerBeg);
            command.Parameters.AddWithValue("@inCardStatus_PerEnd",
                сardStatus.CardStatus_PerEnd == DateTime.MinValue ? Convert.DBNull : сardStatus.CardStatus_PerEnd);
            command.Parameters.AddWithValue("@inCardStatus_Type", сardStatus.CardStatus_Type);
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
        //Изменить интервал статуса работника
        public bool ModifyCardStatus(CardStatus сardStatus, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            if (сardStatus == null)
            {
                error = "сardStatus == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spCardStatusUpdate, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inCardStatus_Id", сardStatus.CardStatus_Id);
            command.Parameters.AddWithValue("@inCardStatus_PersCard_Id",
                сardStatus.CardStatus_PersCard_Id == 0 ? Convert.DBNull : сardStatus.CardStatus_PersCard_Id);
            command.Parameters.AddWithValue("@inCardStatus_PerBeg",
                сardStatus.CardStatus_PerBeg == DateTime.MinValue ? Convert.DBNull : сardStatus.CardStatus_PerBeg);
            command.Parameters.AddWithValue("@inCardStatus_PerEnd",
                сardStatus.CardStatus_PerEnd == DateTime.MinValue ? Convert.DBNull : сardStatus.CardStatus_PerEnd);
            command.Parameters.AddWithValue("@inCardStatus_Type", сardStatus.CardStatus_Type);
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
        //Удалить интервал статуса работника
        public bool DeleteCardStatus(int id, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spCardStatusDelete, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inCardStatus_Id", id);
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
        //Удалить интервал статуса работника по параметрам
        public bool DeleteCardStatusByParams(int persCard_Id, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }

            SqlCommand command = new SqlCommand(spCardStatusDelete, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inCardStatus_PersCard_Id", persCard_Id);
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
        //Создать строку вставки интервала статуса работника
        public string CreateStrInsertCardStatus(CardStatus сardStatus)
        {
            if (сardStatus == null)
                return string.Empty;

            StringBuilder sql = new StringBuilder();
            sql.Append(@"Insert into CardStatus (CardStatus_PersCard_Id");
            if (сardStatus.CardStatus_PerBeg != DateTime.MinValue)
            {
                sql.Append(@",CardStatus_PerBeg");
            }
            if (сardStatus.CardStatus_PerEnd != DateTime.MinValue)
            {
                sql.Append(@",CardStatus_PerEnd");
            }
            sql.Append(@",CardStatus_Type) values (");
            sql.Append(сardStatus.CardStatus_PersCard_Id);
            if (сardStatus.CardStatus_PerBeg != DateTime.MinValue)
            {
                sql.AppendFormat(", {{d'{0}'}}", сardStatus.CardStatus_PerBeg.ToString("yyyy-MM-dd"));
            }
            if (сardStatus.CardStatus_PerEnd != DateTime.MinValue)
            {
                sql.AppendFormat(", {{d'{0}'}}", сardStatus.CardStatus_PerEnd.ToString("yyyy-MM-dd"));
            }
            sql.AppendFormat(", {0} );", сardStatus.CardStatus_Type);
            return sql.ToString();
        }

        //Создать строку удаления интервала статуса работника
        public string CreateStrDeleteCardStatusByParam(int PersCard_Id)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(
                "Delete from CardStatus where CardStatus_PersCard_Id = {0};", PersCard_Id);
            return sql.ToString();
        }
    }
}
