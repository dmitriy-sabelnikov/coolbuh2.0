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
    public class CardSpecExpRepository
    {
        private SqlConnection conn;
        private string spCardSpecExpSelect = "spCardSpecExpSelect";
        private string spCardSpecExpInsert = "spCardSpecExpInsert";
        private string spCardSpecExpUpdate = "spCardSpecExpUpdate";
        private string spCardSpecExpDelete = "spCardSpecExpDelete";
        public CardSpecExpRepository(SqlConnection connection)
        {
            conn = connection;
        }
        private void FillDataRec(SqlDataReader reader, CardSpecExp CardSpecExp)
        {
            int resInt = 0;
            DateTime resDate = DateTime.MinValue;
            if (int.TryParse(reader["CardSpecExp_Id"].ToString(), out resInt))
            {
                CardSpecExp.CardSpecExp_Id = resInt;
            }
            if (int.TryParse(reader["CardSpecExp_PersCard_Id"].ToString(), out resInt))
            {
                CardSpecExp.CardSpecExp_PersCard_Id = resInt;
            }
            if (DateTime.TryParse(reader["CardSpecExp_PerBeg"].ToString(), out resDate))
            {
                CardSpecExp.CardSpecExp_PerBeg = resDate;
            }
            if (DateTime.TryParse(reader["CardSpecExp_PerEnd"].ToString(), out resDate))
            {
                CardSpecExp.CardSpecExp_PerEnd = resDate;
            }
            if (int.TryParse(reader["CardSpecExp_RefSpecExp_Id"].ToString(), out resInt))
            {
                CardSpecExp.CardSpecExp_RefSpecExp_Id = resInt;
            }
        }
        //Получить интервалы спецстажа работников
        public List<CardSpecExp> GetAllCardSpecExps(out string error)
        {
            error = string.Empty;

            List<CardSpecExp> cardSpecExps = new List<CardSpecExp>();

            if (conn == null)
            {
                error = "conn == null";
                return cardSpecExps;
            }

            SqlCommand command = new SqlCommand(spCardSpecExpSelect, conn);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    CardSpecExp cardSpecExp = new CardSpecExp();
                    FillDataRec(reader, cardSpecExp);
                    cardSpecExps.Add(cardSpecExp);
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
            return cardSpecExps;
        }
        //Получить интервалы спецстажа работника по параметрам
        public List<CardSpecExp> GetCardSpecExpByParams(int persCard_Id, out string error)
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
            List<CardSpecExp> cardSpecExpes = new List<CardSpecExp>();

            SqlCommand command = new SqlCommand(spCardSpecExpSelect, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;

            command.Parameters.AddWithValue("@inCardSpecExp_PersCard_Id", persCard_Id);

            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CardSpecExp cardSpecExp = new CardSpecExp();
                    FillDataRec(reader, cardSpecExp);
                    cardSpecExpes.Add(cardSpecExp);
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                cardSpecExpes = null;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
            return cardSpecExpes;
        }
        //Добавить интервал статуса работника
        public int AddCardSpecExp(CardSpecExp cardSpecExp, out string error)
        {
            error = string.Empty;
            if (cardSpecExp == null)
            {
                error = "cardSpecExp == null";
                return 0;
            }
            if (conn == null)
            {
                error = "conn == null";
                return 0;
            }
            SqlCommand command = new SqlCommand(spCardSpecExpInsert, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inCardSpecExp_PersCard_Id",
                cardSpecExp.CardSpecExp_PersCard_Id == 0 ? Convert.DBNull : cardSpecExp.CardSpecExp_PersCard_Id);
            command.Parameters.AddWithValue("@inCardSpecExp_PerBeg",
                cardSpecExp.CardSpecExp_PerBeg == DateTime.MinValue ? Convert.DBNull : cardSpecExp.CardSpecExp_PerBeg);
            command.Parameters.AddWithValue("@inCardSpecExp_PerEnd",
                cardSpecExp.CardSpecExp_PerEnd == DateTime.MinValue ? Convert.DBNull : cardSpecExp.CardSpecExp_PerEnd);
            command.Parameters.AddWithValue("@inCardSpecExp_RefSpecExp_Id", 
                cardSpecExp.CardSpecExp_RefSpecExp_Id == 0 ? Convert.DBNull : cardSpecExp.CardSpecExp_RefSpecExp_Id);
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
        public bool ModifyCardSpecExp(CardSpecExp cardSpecExp, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            if (cardSpecExp == null)
            {
                error = "cardSpecExp == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spCardSpecExpUpdate, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inCardSpecExp_Id", cardSpecExp.CardSpecExp_Id);
            command.Parameters.AddWithValue("@inCardSpecExp_PersCard_Id",
                cardSpecExp.CardSpecExp_PersCard_Id == 0 ? Convert.DBNull : cardSpecExp.CardSpecExp_PersCard_Id);
            command.Parameters.AddWithValue("@inCardSpecExp_PerBeg",
                cardSpecExp.CardSpecExp_PerBeg == DateTime.MinValue ? Convert.DBNull : cardSpecExp.CardSpecExp_PerBeg);
            command.Parameters.AddWithValue("@inCardSpecExp_PerEnd",
                cardSpecExp.CardSpecExp_PerEnd == DateTime.MinValue ? Convert.DBNull : cardSpecExp.CardSpecExp_PerEnd);
            command.Parameters.AddWithValue("@inCardSpecExp_RefSpecExp_Id",
                cardSpecExp.CardSpecExp_RefSpecExp_Id == 0 ? Convert.DBNull : cardSpecExp.CardSpecExp_RefSpecExp_Id);
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
        public bool DeleteCardSpecExp(int id, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spCardSpecExpDelete, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inCardSpecExp_Id", id);
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
        public bool DeleteCardSpecExpByParams(int persCard_Id, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }

            SqlCommand command = new SqlCommand(spCardSpecExpDelete, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inCardSpecExp_PersCard_Id", persCard_Id);
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
        public string CreateStrInsertCardSpecExp(CardSpecExp cardSpecExp)
        {
            if (cardSpecExp == null)
                return string.Empty;

            StringBuilder sql = new StringBuilder();
            sql.Append(@"Insert into CardSpecExp (CardSpecExp_PersCard_Id");
            if (cardSpecExp.CardSpecExp_PerBeg != DateTime.MinValue)
            {
                sql.Append(@",CardSpecExp_PerBeg");
            }
            if (cardSpecExp.CardSpecExp_PerEnd != DateTime.MinValue)
            {
                sql.Append(@",CardSpecExp_PerEnd");
            }
            sql.Append(@",CardSpecExp_RefSpecExp_Id) values (");
            sql.Append(cardSpecExp.CardSpecExp_PersCard_Id);
            if (cardSpecExp.CardSpecExp_PerBeg != DateTime.MinValue)
            {
                sql.AppendFormat(", {{d'{0}'}}", cardSpecExp.CardSpecExp_PerBeg.ToString("yyyy-MM-dd"));
            }
            if (cardSpecExp.CardSpecExp_PerEnd != DateTime.MinValue)
            {
                sql.AppendFormat(", {{d'{0}'}}", cardSpecExp.CardSpecExp_PerEnd.ToString("yyyy-MM-dd"));
            }
            sql.AppendFormat(", {0} );", cardSpecExp.CardSpecExp_RefSpecExp_Id);
            return sql.ToString();
        }
        //Создать строку удаления интервала статуса работника
        public string CreateStrDeleteCardSpecExpByParam(int PersCard_Id)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(
                "Delete from CardSpecExp where CardSpecExp_PersCard_Id = {0};", PersCard_Id);
            return sql.ToString();
        }
    }
}
