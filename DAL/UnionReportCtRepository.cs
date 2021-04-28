using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class UnionReportCtRepository
    {
        private SqlConnection conn;
        private string spUnionReportCtSelect = "spUnionReportCtSelect";
        private string spUnionReportCtInsert = "spUnionReportCtInsert";
        private string spUnionReportCtUpdate = "spUnionReportCtUpdate";
        private string spUnionReportCtDelete = "spUnionReportCtDelete";

        public UnionReportCtRepository(SqlConnection connection)
        {
            conn = connection;
        }

        private void FillDataRec(SqlDataReader reader, UnionReportCt ustCt)
        {
            int resInt = 0;
            DateTime resDate = DateTime.MinValue;

            if (int.TryParse(reader["UnionReportCt_Id"].ToString(), out resInt))
            {
                ustCt.UnionReportCt_Id = resInt;
            }
            if (int.TryParse(reader["UnionReportCt_Qrt"].ToString(), out resInt))
            {
                ustCt.UnionReportCt_Qrt = resInt;
            }
            if (int.TryParse(reader["UnionReportCt_Year"].ToString(), out resInt))
            {
                ustCt.UnionReportCt_Year = resInt;
            }
            if (int.TryParse(reader["UnionReportCt_Nmr"].ToString(), out resInt))
            {
                ustCt.UnionReportCt_Nmr = resInt;
            }
            ustCt.UnionReportCt_Nm = reader["UnionReportCt_Nm"].ToString();
            if (DateTime.TryParse(reader["UnionReportCt_DateClc"].ToString(), out resDate))
            {
                ustCt.UnionReportCt_DateClc = resDate;
            }
            if (int.TryParse(reader["UnionReportCt_Flg"].ToString(), out resInt))
            {
                ustCt.UnionReportCt_Flg = resInt;
            }
        }

        //Получить список каталогов объединенной ведомости
        public List<UnionReportCt> GetAllUnionReportCts(out string error)
        {
            error = string.Empty;

            List<UnionReportCt> unionReportCts = new List<UnionReportCt>();

            if (conn == null)
            {
                error = "conn == null";
                return unionReportCts;
            }

            SqlCommand command = new SqlCommand(spUnionReportCtSelect, conn);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    UnionReportCt unionReportCt = new UnionReportCt();
                    FillDataRec(reader, unionReportCt);
                    unionReportCts.Add(unionReportCt);
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
            return unionReportCts;
        }
        //Добавить каталог объединенной ведомости
        public int AddUnionReportCt(UnionReportCt unionReportCt, out string error)
        {
            error = string.Empty;
            if (unionReportCt == null)
            {
                error = "unionReportCt == null";
                return 0;
            }
            if (conn == null)
            {
                error = "conn == null";
                return 0;
            }
            SqlCommand command = new SqlCommand(spUnionReportCtInsert, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inUnionReportCt_Qrt", unionReportCt.UnionReportCt_Qrt.ToString());
            command.Parameters.AddWithValue("@inUnionReportCt_Year", unionReportCt.UnionReportCt_Year.ToString());
            command.Parameters.AddWithValue("@inUnionReportCt_Nmr", unionReportCt.UnionReportCt_Nmr.ToString());
            command.Parameters.AddWithValue("@inUnionReportCt_Nm", unionReportCt.UnionReportCt_Nm);
            command.Parameters.AddWithValue("@inUnionReportCt_DateClc", unionReportCt.UnionReportCt_DateClc == DateTime.MinValue 
                ? Convert.DBNull : unionReportCt.UnionReportCt_DateClc);
            command.Parameters.AddWithValue("@inUnionReportCt_Flg", unionReportCt.UnionReportCt_Flg.ToString());
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
        //Изменить каталог объединенной ведомости
        public bool ModifyUnionReportCt(UnionReportCt unionReportCt, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            if (unionReportCt == null)
            {
                error = "unionReportCt == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spUnionReportCtUpdate, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inUnionReportCt_Id", unionReportCt.UnionReportCt_Id);
            command.Parameters.AddWithValue("@inUnionReportCt_Qrt", unionReportCt.UnionReportCt_Qrt.ToString());
            command.Parameters.AddWithValue("@inUnionReportCt_Year", unionReportCt.UnionReportCt_Year.ToString());
            command.Parameters.AddWithValue("@inUnionReportCt_Nmr", unionReportCt.UnionReportCt_Nmr.ToString());
            command.Parameters.AddWithValue("@inUnionReportCt_Nm", unionReportCt.UnionReportCt_Nm);
            command.Parameters.AddWithValue("@inUnionReportCt_DateClc", unionReportCt.UnionReportCt_DateClc == DateTime.MinValue
                ? Convert.DBNull : unionReportCt.UnionReportCt_DateClc);
            command.Parameters.AddWithValue("@inUnionReportCt_Flg", unionReportCt.UnionReportCt_Flg.ToString());
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

        //Удалить каталог объединенной ведомости
        public bool DeleteUnionReportCt(int id, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spUnionReportCtDelete, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inUnionReportCt_Id", id);
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
