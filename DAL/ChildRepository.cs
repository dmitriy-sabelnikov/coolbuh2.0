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
    public class ChildRepository
    {
        private SqlConnection conn;
        private string spChildSelect = "spChildSelect";
        private string spChildInsert = "spChildInsert";
        private string spChildUpdate = "spChildUpdate";
        private string spChildDelete = "spChildDelete";
        public ChildRepository(SqlConnection connection)
        {
            conn = connection;
        }
        private void FillDataRec(SqlDataReader reader, Child child)
        {
            int resInt = 0;
            DateTime resDate = DateTime.MinValue;
            if (int.TryParse(reader["Child_Id"].ToString(), out resInt))
            {
                child.Child_Id = resInt;
            }
            if (int.TryParse(reader["Child_PersCard_Id"].ToString(), out resInt))
            {
                child.Child_PersCard_Id = resInt;
            }
            if (DateTime.TryParse(reader["Child_PerBeg"].ToString(), out resDate))
            {
                child.Child_PerBeg = resDate;
            }
            if (DateTime.TryParse(reader["Child_PerEnd"].ToString(), out resDate))
            {
                child.Child_PerEnd = resDate;
            }
            if (int.TryParse(reader["Child_Count"].ToString(), out resInt))
            {
                child.Child_Count = resInt;
            }
        }
        //Получить интервалы детей
        public List<Child> GetAllChilds(out string error)
        {
            error = string.Empty;

            List<Child> childs = new List<Child>();

            if (conn == null)
            {
                error = "conn == null";
                return childs;
            }

            SqlCommand command = new SqlCommand(spChildSelect, conn);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Child child = new Child();
                    FillDataRec(reader, child);
                    childs.Add(child);
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
            return childs;
        }
        //Получить детей по параметрам
        public List<Child> GetChildByParams(int persCard_Id, out string error)
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
            List<Child> childs = new List<Child>();

            SqlCommand command = new SqlCommand(spChildSelect, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;

            command.Parameters.AddWithValue("@inChild_PersCard_Id", persCard_Id);

            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Child child = new Child();
                    FillDataRec(reader, child);
                    childs.Add(child);
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                childs = null;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
            return childs;
        }
        //Добавить детей
        public int AddChild(Child child, out string error)
        {
            error = string.Empty;
            if (child == null)
            {
                error = "child == null";
                return 0;
            }
            if (conn == null)
            {
                error = "conn == null";
                return 0;
            }
            SqlCommand command = new SqlCommand(spChildInsert, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inChild_PersCard_Id",
                child.Child_PersCard_Id == 0 ? Convert.DBNull : child.Child_PersCard_Id);
            command.Parameters.AddWithValue("@inChild_PerBeg",
                child.Child_PerBeg == DateTime.MinValue ? Convert.DBNull : child.Child_PerBeg);
            command.Parameters.AddWithValue("@inChild_PerEnd",
                child.Child_PerEnd == DateTime.MinValue ? Convert.DBNull : child.Child_PerEnd);
            command.Parameters.AddWithValue("@inChild_Count", child.Child_Count);
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
        //Изменить интервал ребенка
        public bool ModifyChild(Child child, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            if (child == null)
            {
                error = "child == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spChildUpdate, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inChild_Id", child.Child_Id);
            command.Parameters.AddWithValue("@inChild_PersCard_Id",
                child.Child_PersCard_Id == 0 ? Convert.DBNull : child.Child_PersCard_Id);
            command.Parameters.AddWithValue("@inChild_PerBeg",
                child.Child_PerBeg == DateTime.MinValue ? Convert.DBNull : child.Child_PerBeg);
            command.Parameters.AddWithValue("@inChild_PerEnd",
                child.Child_PerEnd == DateTime.MinValue ? Convert.DBNull : child.Child_PerEnd);
            command.Parameters.AddWithValue("@inChild_Count", child.Child_Count);
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
        //Удалить интервал ребенка
        public bool DeleteChild(int id, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spChildDelete, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inChild_Id", id);
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
        //Удалить интервал ребенка по параметрам
        public bool DeleteChildByParams(int persCard_Id, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }

            SqlCommand command = new SqlCommand(spChildDelete, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inChild_PersCard_Id", persCard_Id);
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

        //Создать строку вставки интервала детей
        public string CreateStrInsertChild(Child child)
        {
            if (child == null)
                return string.Empty;

            StringBuilder sql = new StringBuilder();
            sql.Append(@"Insert into Child (Child_PersCard_Id");
            if(child.Child_PerBeg != DateTime.MinValue)
            {
                sql.Append(@",Child_PerBeg");
            }
            if (child.Child_PerEnd != DateTime.MinValue)
            {
                sql.Append(@",Child_PerEnd");
            }
            sql.Append(@",Child_Count) values (");
            sql.Append(child.Child_PersCard_Id);
            if (child.Child_PerBeg != DateTime.MinValue)
            {
                sql.AppendFormat(", {{d'{0}'}}", child.Child_PerBeg.ToString("yyyy-MM-dd"));
            }
            if (child.Child_PerEnd != DateTime.MinValue)
            {
                sql.AppendFormat(", {{d'{0}'}}", child.Child_PerEnd.ToString("yyyy-MM-dd"));
            }
            sql.AppendFormat(", {0} );", child.Child_Count);
            return sql.ToString();
        }

        //Создать строку удаления интервала детей
        public string CreateStrDeleteChildByParam(int PersCard_Id)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(
                "Delete from Child where Child_PersCard_Id = {0};", PersCard_Id);
            return sql.ToString();
        }
    }
}
