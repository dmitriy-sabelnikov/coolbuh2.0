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
    public class RefExpAllwncRepository
    {
        private SqlConnection conn;
        private string spRefExpAllwncSelect = "spRefExpAllwncSelect";
        private string spRefExpAllwncInsert = "spRefExpAllwncInsert";
        private string spRefExpAllwncUpdate = "spRefExpAllwncUpdate";
        private string spRefExpAllwncDelete = "spRefExpAllwncDelete";

        public RefExpAllwncRepository(SqlConnection connection)
        {
            conn = connection;
        }

        private void FillDataRec(SqlDataReader reader, RefExpAllwnc expAllwnc)
        {
            int resInt = 0;
            decimal resDecimal = 0;
            if (int.TryParse(reader["RefExpAllwnc_Id"].ToString(), out resInt))
            {
                expAllwnc.RefExpAllwnc_Id = resInt;
            }
            expAllwnc.RefExpAllwnc_Cd = reader["RefExpAllwnc_Cd"].ToString();
            expAllwnc.RefExpAllwnc_Nm = reader["RefExpAllwnc_Nm"].ToString();
            if (int.TryParse(reader["RefExpAllwnc_Year"].ToString(), out resInt))
            {
                expAllwnc.RefExpAllwnc_Year = resInt;
            }
            if (decimal.TryParse(reader["RefExpAllwnc_Mech"].ToString(), out resDecimal))
            {
                expAllwnc.RefExpAllwnc_Mech = resDecimal;
            }
            if (int.TryParse(reader["RefExpAllwncMech_RefDep_Id"].ToString(), out resInt))
            {
                expAllwnc.RefExpAllwncMech_RefDep_Id = resInt;
            }
            if (decimal.TryParse(reader["RefExpAllwnc_Oth"].ToString(), out resDecimal))
            {
                expAllwnc.RefExpAllwnc_Oth = resDecimal;
            }
            if (int.TryParse(reader["RefExpAllwnc_Flg"].ToString(), out resInt))
            {
                expAllwnc.RefExpAllwnc_Flg = resInt;
            }
        }
        //Получить надбавки за стаж
        public List<RefExpAllwnc> GetAllExpAllwnc(out string error)
        {
            error = string.Empty;

            List<RefExpAllwnc> refExpAllwncs = new List<RefExpAllwnc>();

            if (conn == null)
            {
                error = "conn == null";
                return refExpAllwncs;
            }

            SqlCommand command = new SqlCommand(spRefExpAllwncSelect, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    RefExpAllwnc refExpAllwnc = new RefExpAllwnc();
                    FillDataRec(reader, refExpAllwnc);
                    //for (int i = 0; i < reader.FieldCount; i++)
                    //{
                    //    FillDataRec(refExpAllwnc, reader.GetName(i), reader.GetValue(i).ToString());
                    //}
                    refExpAllwncs.Add(refExpAllwnc);
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
            return refExpAllwncs;
        }

        //Получить надбавку за стаж по id
        public RefExpAllwnc GetExpAllwncById(int id, out string error)
        {
            error = string.Empty;
            RefExpAllwnc resExpAllwnc = null;
            if (conn == null)
            {
                error = "conn == null";
                return null;
            }
            SqlCommand command = new SqlCommand(spRefExpAllwncSelect, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inRefExpAllwnc_Id", id);
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    resExpAllwnc = new RefExpAllwnc();
                    FillDataRec(reader, resExpAllwnc);
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
            return resExpAllwnc;
        }
        //Добавить надбавку за стаж
        public int AddExpAllwnc(RefExpAllwnc еxpAllwnc, out string error)
        {
            error = string.Empty;
            if (еxpAllwnc == null)
            {
                error = "еxpAllwnc == null";
                return 0;
            }
            if (conn == null)
            {
                error = "conn == null";
                return 0;
            }
            SqlCommand command = new SqlCommand(spRefExpAllwncInsert, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inRefExpAllwnc_Cd", еxpAllwnc.RefExpAllwnc_Cd);
            command.Parameters.AddWithValue("@inRefExpAllwnc_Nm", еxpAllwnc.RefExpAllwnc_Nm);
            command.Parameters.AddWithValue("@inRefExpAllwnc_Year", еxpAllwnc.RefExpAllwnc_Year);
            command.Parameters.AddWithValue("@inRefExpAllwnc_Mech", еxpAllwnc.RefExpAllwnc_Mech);
            command.Parameters.AddWithValue("@inRefExpAllwncMech_RefDep_Id", 
                еxpAllwnc.RefExpAllwncMech_RefDep_Id == 0 ? Convert.DBNull : еxpAllwnc.RefExpAllwncMech_RefDep_Id);
            command.Parameters.AddWithValue("@inRefExpAllwnc_Oth", еxpAllwnc.RefExpAllwnc_Oth);
            command.Parameters.AddWithValue("@inRefExpAllwnc_Flg", еxpAllwnc.RefExpAllwnc_Flg);
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
        //Изменить надбавку за стаж
        public bool ModifyExpAllwnc(RefExpAllwnc еxpAllwnc, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            if (еxpAllwnc == null)
            {
                error = "еxpAllwnc == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spRefExpAllwncUpdate, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;

            command.Parameters.AddWithValue("@inRefExpAllwnc_Id"  , еxpAllwnc.RefExpAllwnc_Id);
            command.Parameters.AddWithValue("@inRefExpAllwnc_Cd", еxpAllwnc.RefExpAllwnc_Cd);
            command.Parameters.AddWithValue("@inRefExpAllwnc_Nm", еxpAllwnc.RefExpAllwnc_Nm);
            command.Parameters.AddWithValue("@inRefExpAllwnc_Year", еxpAllwnc.RefExpAllwnc_Year);
            command.Parameters.AddWithValue("@inRefExpAllwnc_Mech", еxpAllwnc.RefExpAllwnc_Mech);
            command.Parameters.AddWithValue("@inRefExpAllwncMech_RefDep_Id",
                еxpAllwnc.RefExpAllwncMech_RefDep_Id == 0 ? Convert.DBNull : еxpAllwnc.RefExpAllwncMech_RefDep_Id);
            command.Parameters.AddWithValue("@inRefExpAllwnc_Oth", еxpAllwnc.RefExpAllwnc_Oth);
            command.Parameters.AddWithValue("@inRefExpAllwnc_Flg", еxpAllwnc.RefExpAllwnc_Flg);

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
        //Удалить надбавку за стаж
        public bool DeleteExpAllwnc(int id, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spRefExpAllwncDelete, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inRefExpAllwnc_Id", id);
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


