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
    public class TaxReliefRepository
    {
        private SqlConnection conn;
        private string spTaxReliefSelect = "spTaxReliefSelect";
        private string spTaxReliefInsert = "spTaxReliefInsert";
        private string spTaxReliefUpdate = "spTaxReliefUpdate";
        private string spTaxReliefDelete = "spTaxReliefDelete";
        public TaxReliefRepository(SqlConnection connection)
        {
            conn = connection;
        }
        private void FillDataRec(SqlDataReader reader, TaxRelief TaxRelief)
        {
            int resInt = 0;
            DateTime resDate = DateTime.MinValue;
            decimal resDec = 0;
            if (int.TryParse(reader["TaxRelief_Id"].ToString(), out resInt))
            {
                TaxRelief.TaxRelief_Id = resInt;
            }
            if (int.TryParse(reader["TaxRelief_PersCard_Id"].ToString(), out resInt))
            {
                TaxRelief.TaxRelief_PersCard_Id = resInt;
            }
            if (DateTime.TryParse(reader["TaxRelief_PerBeg"].ToString(), out resDate))
            {
                TaxRelief.TaxRelief_PerBeg = resDate;
            }
            if (DateTime.TryParse(reader["TaxRelief_PerEnd"].ToString(), out resDate))
            {
                TaxRelief.TaxRelief_PerEnd = resDate;
            }
            if (decimal.TryParse(reader["TaxRelief_Koef"].ToString(), out resDec))
            {
                TaxRelief.TaxRelief_Koef = resDec;
            }
        }
        //Получить интервалы налоговых льгот
        public List<TaxRelief> GetAllTaxReliefs(out string error)
        {
            error = string.Empty;

            List<TaxRelief> taxReliefs = new List<TaxRelief>();

            if (conn == null)
            {
                error = "conn == null";
                return taxReliefs;
            }

            SqlCommand command = new SqlCommand(spTaxReliefSelect, conn);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    TaxRelief taxRelief = new TaxRelief();
                    FillDataRec(reader, taxRelief);
                    taxReliefs.Add(taxRelief);
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
            return taxReliefs;
        }

        //Получить интервалы налоговых льгот по параметрам
        public List<TaxRelief> GetTaxReliefByParams(int persCard_Id, out string error)
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
            List<TaxRelief> taxReliefs = new List<TaxRelief>();

            SqlCommand command = new SqlCommand(spTaxReliefSelect, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;

            command.Parameters.AddWithValue("@inTaxRelief_PersCard_Id", persCard_Id);

            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    TaxRelief taxRelief = new TaxRelief();
                    FillDataRec(reader, taxRelief);
                    taxReliefs.Add(taxRelief);
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                taxReliefs = null;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
            return taxReliefs;
        }
        //Добавить интервал налоговой льготы
        public int AddTaxRelief(TaxRelief taxRelief, out string error)
        {
            error = string.Empty;
            if (taxRelief == null)
            {
                error = "taxRelief == null";
                return 0;
            }
            if (conn == null)
            {
                error = "conn == null";
                return 0;
            }
            SqlCommand command = new SqlCommand(spTaxReliefInsert, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inTaxRelief_PersCard_Id",
                taxRelief.TaxRelief_PersCard_Id == 0 ? Convert.DBNull : taxRelief.TaxRelief_PersCard_Id);
            command.Parameters.AddWithValue("@inTaxRelief_PerBeg",
                taxRelief.TaxRelief_PerBeg == DateTime.MinValue ? Convert.DBNull : taxRelief.TaxRelief_PerBeg);
            command.Parameters.AddWithValue("@inTaxRelief_PerEnd",
                taxRelief.TaxRelief_PerEnd == DateTime.MinValue ? Convert.DBNull : taxRelief.TaxRelief_PerEnd);
            command.Parameters.AddWithValue("@inTaxRelief_Koef", taxRelief.TaxRelief_Koef);
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
        //Изменить интервал налоговой льготы
        public bool ModifyTaxRelief(TaxRelief taxRelief, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            if (taxRelief == null)
            {
                error = "taxRelief == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spTaxReliefUpdate, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inTaxRelief_Id", taxRelief.TaxRelief_Id);
            command.Parameters.AddWithValue("@inTaxRelief_PersCard_Id",
                taxRelief.TaxRelief_PersCard_Id == 0 ? Convert.DBNull : taxRelief.TaxRelief_PersCard_Id);
            command.Parameters.AddWithValue("@inTaxRelief_PerBeg",
                taxRelief.TaxRelief_PerBeg == DateTime.MinValue ? Convert.DBNull : taxRelief.TaxRelief_PerBeg);
            command.Parameters.AddWithValue("@inTaxRelief_PerEnd",
                taxRelief.TaxRelief_PerEnd == DateTime.MinValue ? Convert.DBNull : taxRelief.TaxRelief_PerEnd);
            command.Parameters.AddWithValue("@inTaxRelief_Koef", taxRelief.TaxRelief_Koef);
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
        //Удалить интервал налоговой льготы
        public bool DeleteTaxRelief(int id, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spTaxReliefDelete, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inTaxRelief_Id", id);
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
        //Удалить интервал налоговой льготы по параметрам
        public bool DeleteTaxReliefByParams(int persCard_Id, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }

            SqlCommand command = new SqlCommand(spTaxReliefDelete, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inTaxRelief_PersCard_Id", persCard_Id);
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
        //Создать строку вставки интервала налоговой льготы
        public string CreateStrInsertTaxRelief(TaxRelief taxRelief)
        {
            if (taxRelief == null)
                return string.Empty;

            StringBuilder sql = new StringBuilder();
            sql.Append(@"Insert into TaxRelief (TaxRelief_PersCard_Id");
            if (taxRelief.TaxRelief_PerBeg != DateTime.MinValue)
            {
                sql.Append(@",TaxRelief_PerBeg");
            }
            if (taxRelief.TaxRelief_PerEnd != DateTime.MinValue)
            {
                sql.Append(@",TaxRelief_PerEnd");
            }
            sql.Append(@",TaxRelief_Koef) values (");
            sql.Append(taxRelief.TaxRelief_PersCard_Id);
            if (taxRelief.TaxRelief_PerBeg != DateTime.MinValue)
            {
                sql.AppendFormat(", {{d'{0}'}}", taxRelief.TaxRelief_PerBeg.ToString("yyyy-MM-dd"));
            }
            if (taxRelief.TaxRelief_PerEnd != DateTime.MinValue)
            {
                sql.AppendFormat(", {{d'{0}'}}", taxRelief.TaxRelief_PerEnd.ToString("yyyy-MM-dd"));
            }
            sql.AppendFormat(", {0} );", taxRelief.TaxRelief_Koef.ToString().Replace(',', '.'));
            return sql.ToString();
        }
        //Создать строку удаления интервала налоговой льготы
        public string CreateStrDeleteTaxReliefByParam(int PersCard_Id)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(
                "Delete from TaxRelief where TaxRelief_PersCard_Id = {0};", PersCard_Id);
            return sql.ToString();
        }
    }
}
