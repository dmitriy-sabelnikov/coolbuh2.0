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
    public class USTCtRepository
    {
        private SqlConnection conn;
        private string spUSTCtSelect = "spUSTCtSelect";
        private string spUSTCtInsert = "spUSTCtInsert";
        private string spUSTCtUpdate = "spUSTCtUpdate";
        private string spUSTCtDelete = "spUSTCtDelete";
        public USTCtRepository(SqlConnection connection)
        {
            conn = connection;
        }
        private void FillDataRec(SqlDataReader reader, USTCt ustCt)
        {
            int resInt = 0;
            DateTime resDate = DateTime.MinValue;

            if (int.TryParse(reader["USTCt_Id"].ToString(), out resInt))
            {
                ustCt.USTCt_Id = resInt;
            }
            if (DateTime.TryParse(reader["USTCt_Date"].ToString(), out resDate))
            {
                ustCt.USTCt_Date = resDate;
            }
            if (int.TryParse(reader["USTCt_Nmr"].ToString(), out resInt))
            {
                ustCt.USTCt_Nmr = resInt;
            }
            ustCt.USTCt_Nm = reader["USTCt_Nm"].ToString();
            if (DateTime.TryParse(reader["USTCt_DateClc"].ToString(), out resDate))
            {
                ustCt.USTCt_DateClc = resDate;
            }
            if (int.TryParse(reader["USTCt_Flg"].ToString(), out resInt))
            {
                ustCt.USTCt_Flg = resInt;
            }
        }
        //Получить список каталогов ЕСВ
        public List<USTCt> GetAllUSTCts(out string error)
        {
            error = string.Empty;

            List<USTCt> ustCts = new List<USTCt>();

            if (conn == null)
            {
                error = "conn == null";
                return ustCts;
            }

            SqlCommand command = new SqlCommand(spUSTCtSelect, conn);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    USTCt ustCt = new USTCt();
                    FillDataRec(reader, ustCt);
                    ustCts.Add(ustCt);
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
            return ustCts;
        }
        //Добавить каталог ЕСВ
        public int AddUSTCt(USTCt ustCt, out string error)
        {
            error = string.Empty;
            if (ustCt == null)
            {
                error = "ustCt == null";
                return 0;
            }
            if (conn == null)
            {
                error = "conn == null";
                return 0;
            }
            SqlCommand command = new SqlCommand(spUSTCtInsert, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inUSTCt_Date",
                ustCt.USTCt_Date == DateTime.MinValue ? Convert.DBNull : ustCt.USTCt_Date);
            command.Parameters.AddWithValue("@inUSTCt_Nmr", ustCt.USTCt_Nmr.ToString());
            command.Parameters.AddWithValue("@inUSTCt_Nm", ustCt.USTCt_Nm);
            command.Parameters.AddWithValue("@inUSTCt_DateClc",
                ustCt.USTCt_DateClc == DateTime.MinValue ? Convert.DBNull : ustCt.USTCt_DateClc);
            command.Parameters.AddWithValue("@inUSTCt_Flg", ustCt.USTCt_Flg.ToString());
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
        //Изменить каталог ЕСВ
        public bool ModifyUSTCt(USTCt ustCt, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            if (ustCt == null)
            {
                error = "ustCt == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spUSTCtUpdate, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inUSTCt_Id", ustCt.USTCt_Id);
            command.Parameters.AddWithValue("@inUSTCt_Date",
                ustCt.USTCt_Date == DateTime.MinValue ? Convert.DBNull : ustCt.USTCt_Date);
            command.Parameters.AddWithValue("@inUSTCt_Nmr", ustCt.USTCt_Nmr.ToString());
            command.Parameters.AddWithValue("@inUSTCt_Nm", ustCt.USTCt_Nm);
            command.Parameters.AddWithValue("@inUSTCt_DateClc",
                ustCt.USTCt_DateClc == DateTime.MinValue ? Convert.DBNull : ustCt.USTCt_DateClc);
            command.Parameters.AddWithValue("@inUSTCt_Flg", ustCt.USTCt_Flg.ToString());
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
        //Удалить каталог ЕСВ
        public bool DeleteUSTCt(int id, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spUSTCtDelete, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inUSTCt_Id", id);
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
