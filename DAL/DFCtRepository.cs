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
    public class DFCtRepository
    {
        private SqlConnection conn;
        private string spDFCtSelect = "spDFCtSelect";
        private string spDFCtInsert = "spDFCtInsert";
        private string spDFCtUpdate = "spDFCtUpdate";
        private string spDFCtDelete = "spDFCtDelete";
        public DFCtRepository(SqlConnection connection)
        {
            conn = connection;
        }
        private void FillDataRec(SqlDataReader reader, DFCt ustCt)
        {
            int resInt = 0;
            DateTime resDate = DateTime.MinValue;

            if (int.TryParse(reader["DFCt_Id"].ToString(), out resInt))
            {
                ustCt.DFCt_Id = resInt;
            }
            if (DateTime.TryParse(reader["DFCt_Date"].ToString(), out resDate))
            {
                ustCt.DFCt_Date = resDate;
            }
            if (int.TryParse(reader["DFCt_Nmr"].ToString(), out resInt))
            {
                ustCt.DFCt_Nmr = resInt;
            }
            ustCt.DFCt_Nm = reader["DFCt_Nm"].ToString();
            if (DateTime.TryParse(reader["DFCt_DateClc"].ToString(), out resDate))
            {
                ustCt.DFCt_DateClc = resDate;
            }
            if (int.TryParse(reader["DFCt_Flg"].ToString(), out resInt))
            {
                ustCt.DFCt_Flg = resInt;
            }
        }
        //Получить список каталогов 1ДФ
        public List<DFCt> GetAllDFCts(out string error)
        {
            error = string.Empty;

            List<DFCt> dfCts = new List<DFCt>();

            if (conn == null)
            {
                error = "conn == null";
                return dfCts;
            }

            SqlCommand command = new SqlCommand(spDFCtSelect, conn);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    DFCt dfCt = new DFCt();
                    FillDataRec(reader, dfCt);
                    dfCts.Add(dfCt);
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
            return dfCts;
        }
        //Добавить каталог ЕСВ
        public int AddDFCt(DFCt dfCt, out string error)
        {
            error = string.Empty;
            if (dfCt == null)
            {
                error = "dfCt == null";
                return 0;
            }
            if (conn == null)
            {
                error = "conn == null";
                return 0;
            }
            SqlCommand command = new SqlCommand(spDFCtInsert, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inDFCt_Date",
                dfCt.DFCt_Date == DateTime.MinValue ? Convert.DBNull : dfCt.DFCt_Date);
            command.Parameters.AddWithValue("@inDFCt_Nmr", dfCt.DFCt_Nmr.ToString());
            command.Parameters.AddWithValue("@inDFCt_Nm", dfCt.DFCt_Nm);
            command.Parameters.AddWithValue("@inDFCt_DateClc",
                dfCt.DFCt_DateClc == DateTime.MinValue ? Convert.DBNull : dfCt.DFCt_DateClc);
            command.Parameters.AddWithValue("@inDFCt_Flg", dfCt.DFCt_Flg.ToString());
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
        public bool ModifyDFCt(DFCt dfCt, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            if (dfCt == null)
            {
                error = "dfCt == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spDFCtUpdate, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inDFCt_Id", dfCt.DFCt_Id);
            command.Parameters.AddWithValue("@inDFCt_Date",
                dfCt.DFCt_Date == DateTime.MinValue ? Convert.DBNull : dfCt.DFCt_Date);
            command.Parameters.AddWithValue("@inDFCt_Nmr", dfCt.DFCt_Nmr.ToString());
            command.Parameters.AddWithValue("@inDFCt_Nm", dfCt.DFCt_Nm);
            command.Parameters.AddWithValue("@inDFCt_DateClc",
                dfCt.DFCt_DateClc == DateTime.MinValue ? Convert.DBNull : dfCt.DFCt_DateClc);
            command.Parameters.AddWithValue("@inDFCt_Flg", dfCt.DFCt_Flg.ToString());
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
        public bool DeleteDFCt(int id, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spDFCtDelete, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inDFCt_Id", id);
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
