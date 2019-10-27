using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class PersCardRepository
    {
        private SqlConnection conn;
        private string spPersCardSelect = "spPersCardSelect";
        private string spPersCardInsert = "spPersCardInsert";
        private string spPersCardUpdate = "spPersCardUpdate";
        private string spPersCardDelete = "spPersCardDelete";

        private void FillDataRec(SqlDataReader reader, PersCard card)
        {
            int resInt = 0;
            DateTime resDt = DateTime.MinValue;

            if (int.TryParse(reader["PersCard_Id"].ToString(), out resInt))
            {
                card.PersCard_Id = resInt;
            }
            card.PersCard_FName = reader["PersCard_FName"].ToString();
            card.PersCard_MName = reader["PersCard_MName"].ToString();
            card.PersCard_LName = reader["PersCard_LName"].ToString();
            card.PersCard_TIN   = reader["PersCard_TIN"].ToString();
            if (int.TryParse(reader["PersCard_Exp"].ToString(), out resInt))
            {
                card.PersCard_Exp = resInt;
            }
            if (int.TryParse(reader["PersCard_Grade"].ToString(), out resInt))
            {
                card.PersCard_Grade = resInt;
            }
            if (int.TryParse(reader["PersCard_Grade"].ToString(), out resInt))
            {
                card.PersCard_Grade = resInt;
            }
            if (DateTime.TryParse(reader["PersCard_DOB"].ToString(), out resDt))
            {
                card.PersCard_DOB = resDt;
            }
            if (DateTime.TryParse(reader["PersCard_DOR"].ToString(), out resDt))
            {
                card.PersCard_DOR = resDt;
            }
            if (DateTime.TryParse(reader["PersCard_DOD"].ToString(), out resDt))
            {
                card.PersCard_DOD = resDt;
            }
            if (DateTime.TryParse(reader["PersCard_DOP"].ToString(), out resDt))
            {
                card.PersCard_DOP = resDt;
            }
            if (int.TryParse(reader["PersCard_Sex"].ToString(), out resInt))
            {
                card.PersCard_Sex = resInt;
            }
        }

        public PersCardRepository(SqlConnection connection)
        {
            conn = connection;
        }
        //Получить все карточки
        public List<PersCard> GetAllCards(out string error)
        {
            error = string.Empty;

            List<PersCard> persCards = new List<PersCard>();

            if (conn == null)
            {
                error = "conn == null";
                return persCards;
            }

            SqlCommand command = new SqlCommand(this.spPersCardSelect, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    PersCard persCard = new PersCard();
                    FillDataRec(reader, persCard);
                    persCards.Add(persCard);
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
            return persCards;
        }
        //Получить карточку по id
        public PersCard GetCardById(int id, out string error)
        {
            error = string.Empty;
            PersCard resPersDep = null;
            if (conn == null)
            {
                error = "conn == null";
                return null;
            }
            SqlCommand command = new SqlCommand(spPersCardSelect, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inPersCard_Id", id);
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    resPersDep = new PersCard();
                    FillDataRec(reader, resPersDep);
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
            return resPersDep;
        }
        //Добавить карточку
        public int AddCard(PersCard card, out string error)
        {
            error = string.Empty;
            if (card == null)
            {
                error = "card == null";
                return 0;
            }
            if (conn == null)
            {
                error = "conn == null";
                return 0;
            }
            SqlCommand command = new SqlCommand(spPersCardInsert, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inPersCard_FName", card.PersCard_FName);
            command.Parameters.AddWithValue("@inPersCard_MName", card.PersCard_MName);
            command.Parameters.AddWithValue("@inPersCard_LName", card.PersCard_LName);
            command.Parameters.AddWithValue("@inPersCard_TIN",   card.PersCard_TIN);
            command.Parameters.AddWithValue("@inPersCard_Exp",   card.PersCard_Exp);
            command.Parameters.AddWithValue("@inPersCard_Grade", card.PersCard_Grade);
            command.Parameters.AddWithValue("@inPersCard_DOB",   card.PersCard_DOB == DateTime.MinValue ? Convert.DBNull : card.PersCard_DOB);
            command.Parameters.AddWithValue("@inPersCard_DOR",   card.PersCard_DOR == DateTime.MinValue ? Convert.DBNull : card.PersCard_DOR);
            command.Parameters.AddWithValue("@inPersCard_DOD",   card.PersCard_DOD == DateTime.MinValue ? Convert.DBNull : card.PersCard_DOD);
            command.Parameters.AddWithValue("@inPersCard_DOP",   card.PersCard_DOP == DateTime.MinValue ? Convert.DBNull : card.PersCard_DOP);
            command.Parameters.AddWithValue("@inPersCard_Sex",   card.PersCard_Sex);
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
        //Изменить карточку
        public bool ModifyCard(PersCard card, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            if (card == null)
            {
                error = "card == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spPersCardUpdate, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inPersCard_Id"   , card.PersCard_Id);
            command.Parameters.AddWithValue("@inPersCard_FName", card.PersCard_FName);
            command.Parameters.AddWithValue("@inPersCard_MName", card.PersCard_MName);
            command.Parameters.AddWithValue("@inPersCard_LName", card.PersCard_LName);
            command.Parameters.AddWithValue("@inPersCard_TIN"  , card.PersCard_TIN);
            command.Parameters.AddWithValue("@inPersCard_Exp"  , card.PersCard_Exp);
            command.Parameters.AddWithValue("@inPersCard_Grade", card.PersCard_Grade);
            command.Parameters.AddWithValue("@inPersCard_DOB",  card.PersCard_DOB == DateTime.MinValue ? Convert.DBNull : card.PersCard_DOB);
            command.Parameters.AddWithValue("@inPersCard_DOR",  card.PersCard_DOR == DateTime.MinValue ? Convert.DBNull : card.PersCard_DOR);
            command.Parameters.AddWithValue("@inPersCard_DOD",  card.PersCard_DOD == DateTime.MinValue ? Convert.DBNull : card.PersCard_DOD);
            command.Parameters.AddWithValue("@inPersCard_DOP",  card.PersCard_DOP == DateTime.MinValue ? Convert.DBNull : card.PersCard_DOP);
            command.Parameters.AddWithValue("@inPersCard_Sex",  card.PersCard_Sex);
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
        //Удалить карточку
        public bool DeleteCard(int id, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spPersCardDelete, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inPersCard_Id", id);
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
