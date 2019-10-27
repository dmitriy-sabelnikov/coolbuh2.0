using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.SqlClient;

namespace DAL
{
    public class SetupAppRepository
    {
        private SqlConnection conn;
        private string spSetupAppSelect = "spSetupAppSelect";
        private string spSetupAppInsert = "spSetupAppInsert";
        private string spSetupAppUpdate = "spSetupAppUpdate";
        private string spSetupAppDelete = "spSetupAppDelete";

        public SetupAppRepository(SqlConnection connection)
        {
            conn = connection;
        }
        private void FillDataRec(SqlDataReader reader, SetupApp setup)
        {
            int resInt = 0;
            if (int.TryParse(reader["SetupApp_Type"].ToString(), out resInt))
            {
                setup.SetupApp_Type = resInt;
            }
            if (int.TryParse(reader["SetupApp_ValueDigit"].ToString(), out resInt))
            {
                setup.SetupApp_ValueDigit = resInt;
            }
            setup.SetupApp_ValueString = reader["SetupApp_ValueString"].ToString();
        }


        //Зачитать все настройки
        public List<SetupApp> GetAllSetups(out string error)
        {
            error = string.Empty;
            List<SetupApp> setups = new List<SetupApp>();
            if(conn == null)
            {
                error = "conn == null";
                return setups;
            }

            SqlCommand command = new SqlCommand(spSetupAppSelect, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    SetupApp addSetup = new SetupApp();
                    FillDataRec(reader, addSetup);
                    //for (int i = 0; i < reader.FieldCount; i++)
                    //{
                    //    switch (reader.GetName(i))
                    //    {
                    //        case "SetupApp_Type":
                    //            addSetup.SetupApp_Type = reader.GetInt32(i);
                    //            break;
                    //        case "SetupApp_ValueDigit":
                    //            addSetup.SetupApp_ValueDigit = reader.GetInt32(i);
                    //            break;
                    //        case "SetupApp_ValueString":
                    //            addSetup.SetupApp_ValueString = reader.GetString(i);
                    //            break;
                    //    }
                    //}
                    setups.Add(addSetup);
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
            return setups;
        }
        //Получить настройку по id(типу)
        public SetupApp GetSetupById(int SetupApp_Type, out string error)
        {
            error = string.Empty;
            SetupApp resSetup = null;
            if (conn == null)
            {
                error = "conn == null";
                return null;
            }
            SqlCommand command = new SqlCommand(spSetupAppSelect, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inSetupApp_Type", SetupApp_Type);
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();
                if(reader.HasRows)
                {
                    reader.Read();
                    resSetup = new SetupApp();
                    FillDataRec(reader, resSetup);
                    //for (int i = 0; i < reader.FieldCount; i++)
                    //{
                    //    switch (reader.GetName(i))
                    //    {
                    //        case "SetupApp_ValueDigit":
                    //            resSetup.SetupApp_ValueDigit = reader.GetInt32(i);
                    //            break;
                    //        case "SetupApp_ValueString":
                    //            resSetup.SetupApp_ValueString = reader.GetString(i);
                    //            break;
                    //    }
                    //}
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
            return resSetup;
        }
        //Записать в базу настройку
        public bool AddSetupApp(SetupApp setup, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spSetupAppInsert, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inSetupApp_Type",        setup.SetupApp_Type);
            command.Parameters.AddWithValue("@inSetupApp_ValueDigit",  setup.SetupApp_ValueDigit);
            command.Parameters.AddWithValue("@inSetupApp_ValueString", setup.SetupApp_ValueString);
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
        //Модификация настройки в базе
        public bool ModifySetupApp(SetupApp setup, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            if (setup == null)
            {
                error = "setup == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spSetupAppUpdate, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inSetupApp_Type", setup.SetupApp_Type);
            command.Parameters.AddWithValue("@inSetupApp_ValueDigit", setup.SetupApp_ValueDigit);
            command.Parameters.AddWithValue("@inSetupApp_ValueString", setup.SetupApp_ValueString);
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
        //Удаление настройки из базе
        public bool DeleteSetupApp(int SetupApp_Type, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spSetupAppDelete, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inSetupApp_Type", SetupApp_Type);
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
