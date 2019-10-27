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
    public class CompanyRepository
    {
        private SqlConnection conn;
        private string spCompanySelect = "spCompanySelect";
        private string spCompanyInsert = "spCompanyInsert";
        private string spCompanyUpdate = "spCompanyUpdate";
        private string spCompanyDelete = "spCompanyDelete";
        public CompanyRepository(SqlConnection connection)
        {
            conn = connection;
        }
        private void FillDataRec(SqlDataReader reader, Company Company)
        {
            Company.Company_USREOU = reader["Company_USREOU"].ToString();
            Company.Company_Nm = reader["Company_Nm"].ToString();
        }

        //Получить инфо о предприятии
        public Company GetCompany(out string error)
        {
            error = string.Empty;

            Company company = new Company();

            if (conn == null)
            {
                error = "conn == null";
                return company;
            }

            SqlCommand command = new SqlCommand(spCompanySelect, conn);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    FillDataRec(reader, company);
                    break;
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
            return company;
        }
        //Добавить инфо о предприятии
        public bool AddCompany(Company company, out string error)
        {
            error = string.Empty;
            if (company == null)
            {
                error = "company == null";
                return false;
            }
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }

            SqlCommand command = new SqlCommand(spCompanyInsert, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inCompany_USREOU", company.Company_USREOU);
            command.Parameters.AddWithValue("@inCompany_Nm", company.Company_Nm);
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
        //Изменить инфо о предприятии
        public bool ModifyCompany(Company company, out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            if (company == null)
            {
                error = "company == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spCompanyUpdate, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = conn;
            command.Parameters.AddWithValue("@inCompany_USREOU", company.Company_USREOU);
            command.Parameters.AddWithValue("@inCompany_Nm", company.Company_Nm);
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
        //Удалить инфо о предприятии
        public bool DeleteCompany(out string error)
        {
            error = string.Empty;
            if (conn == null)
            {
                error = "conn == null";
                return false;
            }
            SqlCommand command = new SqlCommand(spCompanyDelete, conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
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
