using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entities;

namespace DAL
{
    public class ReportRepository
    {
        private SqlConnection conn;
        private string spReportSelect = "spReportSelect";
        public ReportRepository(SqlConnection connection)
        {
            conn = connection;
        }

        private void FillDataRec(SqlDataReader reader, Report report)
        {
            int resInt = 0;

            if (int.TryParse(reader["Report_Id"].ToString(), out resInt))
            {
                report.Report_Id = resInt;
            }
            report.Report_Name = reader["Report_Name"].ToString();
            report.Report_File = reader["Report_File"].ToString();
        }

        //Получить список доп начислений
        public List<Report> GetAllReports(out string error)
        {
            error = string.Empty;

            List<Report> reports = new List<Report>();

            if (conn == null)
            {
                error = "conn == null";
                return reports;
            }

            SqlCommand command = new SqlCommand(spReportSelect, conn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Report report = new Report();
                    FillDataRec(reader, report);
                    reports.Add(report);
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
            return reports;
        }
    }
}
