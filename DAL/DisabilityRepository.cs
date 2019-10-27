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
    public class DisabilityRepository
    {
        private SqlConnection conn;
        private string spDisabilitySelect = "spDisabilitySelect";
        private string spDisabilityInsert = "spDisabilityInsert";
        private string spDisabilityUpdate = "spDisabilityUpdate";
        private string spDisabilityDelete = "spDisabilityDelete";
        public DisabilityRepository(SqlConnection connection)
        {
            conn = connection;
        }
        private void FillDataRec(SqlDataReader reader, Disability Disability)
        {
            int resInt = 0;
            DateTime resDate = DateTime.MinValue;
            if (int.TryParse(reader["Disability_Id"].ToString(), out resInt))
            {
                Disability.Disability_Id = resInt;
            }
            if (int.TryParse(reader["Disability_PersCard_Id"].ToString(), out resInt))
            {
                Disability.Disability_PersCard_Id = resInt;
            }
            if (DateTime.TryParse(reader["Disability_PerBeg"].ToString(), out resDate))
            {
                Disability.Disability_PerBeg = resDate;
            }
            if (DateTime.TryParse(reader["Disability_PerEnd"].ToString(), out resDate))
            {
                Disability.Disability_PerEnd = resDate;
            }
            if (int.TryParse(reader["Disability_Attr"].ToString(), out resInt))
            {
                Disability.Disability_Attr = resInt;
            }
        }
        //Получить интервалы инвалидности
        public List<Disability> GetAllDisabilities(out string error)
        {
            error = string.Empty;

            List<Disability> disabilities = new List<Disability>();

            if (conn == null)
            {
                error = "conn == null";
                return disabilities;
            }

            SqlCommand command = new SqlCommand(spDisabilitySelect, conn);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Disability Disability = new Disability();
                    FillDataRec(reader, Disability);
                    disabilities.Add(Disability);
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
            return disabilities;
        }
        //Получить интервалы инвалидности по параметрам
        public List<Disability> GetDisabilitiesByParams(int persCard_Id, out string error)
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
            List<Disability> disabilities = new List<Disability>();

            SqlCommand command = new SqlCommand(spDisabilitySelect, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;

            command.Parameters.AddWithValue("@inDisability_PersCard_Id", persCard_Id);

            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Disability disability = new Disability();
                    FillDataRec(reader, disability);
                    disabilities.Add(disability);
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                disabilities = null;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
            return disabilities;
        }
        //Добавить интервал инвалидности
        public int AddDisability(Disability disability, out string error)
        {
            error = string.Empty;
            if (disability == null)
            {
                error = "disability == null";
                return 0;
            }
            if (conn == null)
            {
                error = "conn == null";
                return 0;
            }
            SqlCommand command = new SqlCommand(spDisabilityInsert, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inDisability_PersCard_Id",
                disability.Disability_PersCard_Id == 0 ? Convert.DBNull : disability.Disability_PersCard_Id);
            command.Parameters.AddWithValue("@inDisability_PerBeg",
                disability.Disability_PerBeg == DateTime.MinValue ? Convert.DBNull : disability.Disability_PerBeg);
            command.Parameters.AddWithValue("@inDisability_PerEnd",
                disability.Disability_PerEnd == DateTime.MinValue ? Convert.DBNull : disability.Disability_PerEnd);
            command.Parameters.AddWithValue("@inDisability_Attr", disability.Disability_Attr);
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
        //Изменить интервал инвалидности
        public bool ModifyDisability(Disability disability, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            if (disability == null)
            {
                error = "disability == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spDisabilityUpdate, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inDisability_Id", disability.Disability_Id);
            command.Parameters.AddWithValue("@inDisability_PersCard_Id",
                disability.Disability_PersCard_Id == 0 ? Convert.DBNull : disability.Disability_PersCard_Id);
            command.Parameters.AddWithValue("@inDisability_PerBeg",
                disability.Disability_PerBeg == DateTime.MinValue ? Convert.DBNull : disability.Disability_PerBeg);
            command.Parameters.AddWithValue("@inDisability_PerEnd",
                disability.Disability_PerEnd == DateTime.MinValue ? Convert.DBNull : disability.Disability_PerEnd);
            command.Parameters.AddWithValue("@inDisability_Attr", disability.Disability_Attr);
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
        //Удалить интервал инвалидности
        public bool DeleteDisability(int id, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spDisabilityDelete, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inDisability_Id", id);
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
        //Удалить интервал инвалидности по параметрам
        public bool DeleteDisabilityByParams(int persCard_Id, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }

            SqlCommand command = new SqlCommand(spDisabilityDelete, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inDisability_PersCard_Id", persCard_Id);
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
        //Создать строку вставки интервала инвалидности
        public string CreateStrInsertDisability(Disability disability)
        {
            if (disability == null)
                return string.Empty;

            StringBuilder sql = new StringBuilder();
            sql.Append(@"Insert into Disability (Disability_PersCard_Id");
            if (disability.Disability_PerBeg != DateTime.MinValue)
            {
                sql.Append(@",Disability_PerBeg");
            }
            if (disability.Disability_PerEnd != DateTime.MinValue)
            {
                sql.Append(@",Disability_PerEnd");
            }
            sql.Append(@",Disability_Attr) values (");
            sql.Append(disability.Disability_PersCard_Id);
            if (disability.Disability_PerBeg != DateTime.MinValue)
            {
                sql.AppendFormat(", {{d'{0}'}}", disability.Disability_PerBeg.ToString("yyyy-MM-dd"));
            }
            if (disability.Disability_PerEnd != DateTime.MinValue)
            {
                sql.AppendFormat(", {{d'{0}'}}", disability.Disability_PerEnd.ToString("yyyy-MM-dd"));
            }
            sql.AppendFormat(", {0} );", disability.Disability_Attr);
            return sql.ToString();
        }
        //Создать строку удаления интервала инвалидности
        public string CreateStrDeleteDisabilityByParam(int PersCard_Id)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(
                "Delete from Disability where Disability_PersCard_Id = {0};", PersCard_Id);
            return sql.ToString();
        }
    }
}
