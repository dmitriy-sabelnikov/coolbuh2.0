using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Microsoft.Reporting.WinForms;
using Entities;
using DAL;
using BLL;
using EnumType;
using System.Windows.Forms;
using Reports.StartFormReport;

namespace Reports
{
    public class SalBalanceReport : IReport
    {
        private SalBalanceRepository _repoSalBalance = new SalBalanceRepository(SetupProgram.Connection);
        private PersCardRepository _repoCards = new PersCardRepository(SetupProgram.Connection);

        public string NameReport { get; }
        public List<ReportDataSource> DataSources { get; }
        public ReportParameter[] Parameters { get; }
        public SubreportProcessingEventHandler SubreportProc { get; }
        public List<RPR_SalBalance> _salaryBalance = new List<RPR_SalBalance>();


        private bool LoadDataForPrint(DateTime dat, out string error)
        {
            error = string.Empty;
            List<SalBalance> balances = _repoSalBalance.GetSalBalanceByParams(0, dat, dat, out error);
            if (error != string.Empty)
            {
                return false;
            }
            List<PersCard> cards = _repoCards.GetAllCards(out error);
            if (error != string.Empty)
            {
                return false;
            }

            _salaryBalance =
                (from bal in balances
                 join card in cards on bal.SalBalance_PersCard_Id equals card.PersCard_Id
                 select new RPR_SalBalance
                 {
                     NameMonth = SalaryHelper.GetMonthNameById(dat.Month, EnumCaseWorld.Nominative),
                     PersCard_TIN = card.PersCard_TIN,
                     PersCard_LName = card.PersCard_LName,
                     PersCard_FName = card.PersCard_FName,
                     PersCard_MName = card.PersCard_MName,
                     SalBalance_SmByFirm = bal.SalBalance_BegMonthSm > 0 ? bal.SalBalance_BegMonthSm : 0,
                     SalBalance_SmByCard = bal.SalBalance_BegMonthSm < 0 ? bal.SalBalance_BegMonthSm : 0
                 }
                 ).ToList();
            return true;
        }
        public SalBalanceReport(string name)
        {
            NameReport = name;
            DataSources = new List<ReportDataSource>();
        }

        public bool StartReport()
        {
            fmSalBalance fmSalBalance = new fmSalBalance();
            if (fmSalBalance.ShowDialog() != DialogResult.OK)
                return false;
            string error = string.Empty;
            DateTime dat = fmSalBalance.GetDateParam();
            LoadDataForPrint(dat, out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            ReportDataSource report = new ReportDataSource("dsSalBalance", _salaryBalance);
            DataSources.Add(report);
            return true;
        }

    }
}
