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
    public class SalStatement : IReport
    {
        private PersCardRepository _repoCard = new PersCardRepository(SetupProgram.Connection);
        private ACSRepository _repoAcs = new ACSRepository(SetupProgram.Connection);

        public string NameReport { get; }
        public List<ReportDataSource> DataSources { get; }
        public ReportParameter[] Parameters { get; }
        public SubreportProcessingEventHandler SubreportProc { get; }
        public List<RPR_SalStatement> _salStatement = new List<RPR_SalStatement>();

        private bool LoadDataForPrint(DateTime dat, bool isShowNullRec, out string error)
        {
            error = string.Empty;
            List<PersCard> cards = _repoCard.GetAllCards(out error);
            if (error != string.Empty)
            {
                return false;
            }
            List<ACS> acses = _repoAcs.GetAllACSByParam(dat, out error);
            if (error != string.Empty)
            {
                return false;
            }
            _salStatement =
                (from card in cards
                 join acs in acses on card.PersCard_Id equals acs.PersCard_Id into rec
                 from acs in rec.DefaultIfEmpty()
                 orderby card.PersCard_LName, card.PersCard_FName, card.PersCard_MName
                 select new RPR_SalStatement
                 {
                     NameMonth = SalaryHelper.GetMonthNameById(dat.Month, EnumCaseWorld.Nominative),
                     PersCard_FullName = SalaryHelper.GetLastNameWithInit(card.PersCard_LName, card.PersCard_MName, card.PersCard_FName),
                     SalBalance_BegSmByFirm = acs == null ? 0 : (acs.SalBalance_BegMonthSm > 0 ? acs.SalBalance_BegMonthSm : 0),
                     SalBalance_BegSmByCard = acs == null ? 0 : (acs.SalBalance_BegMonthSm < 0 ? -1 * acs.SalBalance_BegMonthSm : 0),
                     Salary_BaseSm = acs == null ? 0 : acs.Salary_BaseSm,
                     Salary_PensSm = acs == null ? 0 : acs.Salary_PensSm,
                     Salary_GradeSm = acs == null ? 0 : acs.Salary_GradeSm,
                     Salary_ExpSm = acs == null ? 0 : acs.Salary_ExpSm,
                     Salary_OthSm = acs == null ? 0 : acs.Salary_OthSm,
                     SickList_ResSm = acs == null ? 0 : acs.SickList_ResSm,
                     Vocation_Sm = acs == null ? 0 : acs.Vocation_Sm,
                     LawContract_Sm = acs == null ? 0 : acs.LawContract_Sm,
                     AddAccr_SmClc = acs == null ? 0 : acs.AddAccr_SmClc,
                     AddAccr_SmNoClc = acs == null ? 0 : acs.AddAccr_SmNoClc,
                     Accr_TotalSm = acs == null ? 0 : (acs.Salary_ResSm + acs.Vocation_Sm + acs.SickList_ResSm + acs.LawContract_Sm + acs.AddAccr_SmClc),
                     Tax_Sm = acs == null ? 0 : acs.Tax_Sm,
                     IncTax_Sm = acs == null ? 0 : acs.IncTax_Sm,
                     Prof_Sm = acs == null ? 0 : acs.Prof_Sm,
                     SalBalance_EndSmByFirm = acs == null ? 0 : (acs.SalBalance_EndMonthSm > 0 ? acs.SalBalance_EndMonthSm : 0),
                     SalBalance_EndSmByCard = acs == null ? 0 : (acs.SalBalance_EndMonthSm < 0 ? -1 * acs.SalBalance_EndMonthSm : 0),
                     CashBox_Sm = acs == null ? 0 : acs.CashBox_Sm,
                     Excerpt_Sm = acs == null ? 0 : acs.Excerpt_Sm,
                     List_Sm = acs == null ? 0 : acs.list_Sm,
                     InKindPay_Sm = acs == null ? 0 : acs.InKindPay_Sm,
                     AddPayment_Sm = acs == null ? 0 : acs.AddPayment_Sm,
                     Payment_TotalSm = acs == null ? 0 : ((acs.CardStatus_Type == (int)EnumCardStatus.Constant ? 0 : acs.Tax_Sm) +
                       acs.CashBox_Sm + acs.Excerpt_Sm + acs.list_Sm + acs.InKindPay_Sm + acs.AddPayment_Sm + acs.Military_Sm + acs.Prof_Sm)
                 }
                 ).ToList();
            if (!isShowNullRec)
                _salStatement = _salStatement.Where(rec => rec.Accr_TotalSm != 0 && rec.Payment_TotalSm != 0 
                || (rec.SalBalance_BegSmByFirm != 0 || rec.SalBalance_BegSmByCard != 0 
                 || rec.SalBalance_EndSmByFirm != 0 || rec.SalBalance_EndSmByCard != 0)).ToList();
            return true;
        }
        public SalStatement(string name)
        {
            NameReport = name;
            DataSources = new List<ReportDataSource>();
        }

        public bool StartReport()
        {
            fmSalStatement fmSalstat = new fmSalStatement();
            if (fmSalstat.ShowDialog() != DialogResult.OK)
                return false;
            string error = string.Empty;
            DateTime dat = fmSalstat.GetDateParam();
            bool isShowNullRec = fmSalstat.GetShowNullRec();
            LoadDataForPrint(dat, isShowNullRec, out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            ReportDataSource report = new ReportDataSource("dsSalStatement", _salStatement);
            DataSources.Add(report);
            return true;
        }
    }
}
