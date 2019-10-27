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
    public class AccrStatement : IReport
    {
        public string NameReport { get; }
        public List<ReportDataSource> DataSources { get; }
        public ReportParameter[] Parameters { get; }
        public SubreportProcessingEventHandler SubreportProc { get; }

        public List<RPR_AccrStatement> _accrStatement = new List<RPR_AccrStatement>();

        private SalaryRepository _repoSalary = new SalaryRepository(SetupProgram.Connection);
        private VocationRepository _repoVocation = new VocationRepository(SetupProgram.Connection);
        private SickListRepository _repoSickList = new SickListRepository(SetupProgram.Connection);
        private AddAccrRepository _repoAddAccr = new AddAccrRepository(SetupProgram.Connection);
        private RefTypeAddAccrRepository _repoTypeAddAccr = new RefTypeAddAccrRepository(SetupProgram.Connection);

        private PersCardRepository _repoCard = new PersCardRepository(SetupProgram.Connection);
        private RefDepRepository _repoDep = new RefDepRepository(SetupProgram.Connection);

        private bool LoadDataForPrint(DateTime datBeg, DateTime datEnd, EnumSalaryList typeForm, List<int> id_dep, out string error)
        {
            error = string.Empty;
            List<PersCard> cards = _repoCard.GetAllCards(out error);
            if (error != string.Empty)
            {
                return false;
            }
            List<Salary> salaries = _repoSalary.GetSalariesByParams(0, 0, datBeg, datEnd, out error);
            if (error != string.Empty)
            {
                return false;
            }
            List<Vocation> vocs = _repoVocation.GetVocationsByParams(0, 0, datBeg, datEnd, out error);
            if (error != string.Empty)
            {
                return false;
            }
            List<SickList> lists = _repoSickList.GetSickListsByParams(0, 0, datBeg, datEnd, out error);
            if (error != string.Empty)
            {
                return false;
            }
            List<RefDep> deps = _repoDep.GetAllDeps(out error);
            if (error != string.Empty)
            {
                return false;
            }
            List<AddAccr> addAccrs = _repoAddAccr.GetAddAccrByParams(0, 0, datBeg, datEnd, out error);
            if (error != string.Empty)
            {
                return false;
            }

            List<RefTypeAddAccr> typeAddAccrs = _repoTypeAddAccr.GetAllTypeAddAccr(out error);
            if (error != string.Empty)
            {
                return false;
            }

            for (DateTime dat = datBeg; dat <= datEnd; dat = dat.AddMonths(1))
            {
                if (typeForm == EnumSalaryList.ByFirma)
                {
                    _accrStatement.AddRange(
                    (from card in cards
                     join sal in salaries on card.PersCard_Id equals sal.Salary_PersCard_Id
                     join dep in deps on sal.Salary_RefDep_Id equals dep.RefDep_Id
                     where sal.Salary_Date == dat
                     orderby card.PersCard_LName, card.PersCard_FName, card.PersCard_MName
                     select new RPR_AccrStatement
                     {
                         PersCard_Name = SalaryHelper.GetLastNameWithInit(card.PersCard_LName, card.PersCard_MName, card.PersCard_FName),
                         Month = dat.Month,
                         RefDep_Id = dep == null ? 0 : dep.RefDep_Id,
                         NameDep = dep == null ? string.Empty : dep.RefDep_Nm,
                         Salary_Days = sal.Salary_Days,
                         Salary_Hours = sal.Salary_Hours,
                         Salary_BaseSm = sal.Salary_BaseSm,
                         Salary_PensSm = sal.Salary_PensSm,
                         Salary_GradeSm = sal.Salary_GradeSm,
                         Salary_ExpSm = sal.Salary_ExpSm,
                         Salary_OthSm = sal.Salary_OthSm,
                         Salary_KTU = sal.Salary_KTU,
                         Salary_KTUSm = sal.Salary_KTUSm,
                         Salary_ResSm = sal.Salary_ResSm,
                         Vocation_Days = 0,
                         Vocation_Sm = 0,
                         SickList_DaysTmpDis = 0,
                         SickList_ResSm = 0,
                         AddAccr_SmClc = 0,
                         AddAccr_SmNoClc = 0,
                         Accr_TotalSm = sal.Salary_ResSm
                     }).ToList()
                     );

                    _accrStatement.AddRange(
                  (from card in cards
                   join voc in vocs on card.PersCard_Id equals voc.Vocation_PersCard_Id
                   join dep in deps on voc.Vocation_RefDep_Id equals dep.RefDep_Id
                   where voc.Vocation_Date == dat
                   orderby card.PersCard_LName, card.PersCard_FName, card.PersCard_MName
                   select new RPR_AccrStatement
                   {
                       PersCard_Name = SalaryHelper.GetLastNameWithInit(card.PersCard_LName, card.PersCard_MName, card.PersCard_FName),
                       Month = dat.Month,
                       RefDep_Id = dep == null ? 0 : dep.RefDep_Id,
                       NameDep = dep == null ? string.Empty : dep.RefDep_Nm,
                       Salary_Days = 0,
                       Salary_Hours = 0,
                       Salary_BaseSm = 0,
                       Salary_PensSm = 0,
                       Salary_GradeSm = 0,
                       Salary_ExpSm = 0,
                       Salary_OthSm = 0,
                       Salary_KTU = 0,
                       Salary_KTUSm = 0,
                       Salary_ResSm = 0,
                       Vocation_Days = voc.Vocation_Days,
                       Vocation_Sm = voc.Vocation_Sm,
                       SickList_DaysTmpDis = 0,
                       SickList_ResSm = 0,
                       AddAccr_SmClc = 0,
                       AddAccr_SmNoClc = 0,
                       Accr_TotalSm = voc.Vocation_Sm
                   }).ToList()
                   );

                    _accrStatement.AddRange(
                  (from card in cards
                   join sick in lists on card.PersCard_Id equals sick.SickList_PersCard_Id
                   join dep in deps on sick.SickList_RefDep_Id equals dep.RefDep_Id
                   where sick.SickList_Date == dat
                   orderby card.PersCard_LName, card.PersCard_FName, card.PersCard_MName
                   select new RPR_AccrStatement
                   {
                       PersCard_Name = SalaryHelper.GetLastNameWithInit(card.PersCard_LName, card.PersCard_MName, card.PersCard_FName),
                       Month = dat.Month,
                       RefDep_Id = dep == null ? 0 : dep.RefDep_Id,
                       NameDep = dep == null ? string.Empty : dep.RefDep_Nm,
                       Salary_Days = 0,
                       Salary_Hours = 0,
                       Salary_BaseSm = 0,
                       Salary_PensSm = 0,
                       Salary_GradeSm = 0,
                       Salary_ExpSm = 0,
                       Salary_OthSm = 0,
                       Salary_KTU = 0,
                       Salary_KTUSm = 0,
                       Salary_ResSm = 0,
                       Vocation_Days = 0,
                       Vocation_Sm = 0,
                       SickList_DaysTmpDis = sick.SickList_DaysTmpDis,
                       SickList_ResSm = sick.SickList_ResSm,
                       AddAccr_SmClc = 0,
                       AddAccr_SmNoClc = 0,
                       Accr_TotalSm = sick.SickList_ResSm
                   }).ToList()
                   );

                    _accrStatement.AddRange(
                    (from card in cards
                     join addAccr in addAccrs on card.PersCard_Id equals addAccr.AddAccr_PersCard_Id
                     join typeAddAccr in typeAddAccrs on addAccr.AddAccr_RefTypeAddAccr_Id equals typeAddAccr.RefTypeAddAccr_Id
                     join dep in deps on addAccr.AddAccr_RefDep_Id equals dep.RefDep_Id
                     where addAccr.AddAccr_Date == dat
                     orderby card.PersCard_LName, card.PersCard_FName, card.PersCard_MName
                     select new RPR_AccrStatement
                     {
                         PersCard_Name = SalaryHelper.GetLastNameWithInit(card.PersCard_LName, card.PersCard_MName, card.PersCard_FName),
                         Month = dat.Month,
                         RefDep_Id = dep == null ? 0 : dep.RefDep_Id,
                         NameDep = dep == null ? string.Empty : dep.RefDep_Nm,
                         Salary_Days = 0,
                         Salary_Hours = 0,
                         Salary_BaseSm = 0,
                         Salary_PensSm = 0,
                         Salary_GradeSm = 0,
                         Salary_ExpSm = 0,
                         Salary_OthSm = 0,
                         Salary_KTU = 0,
                         Salary_KTUSm = 0,
                         Salary_ResSm = 0,
                         Vocation_Days = 0,
                         Vocation_Sm = 0,
                         SickList_DaysTmpDis = 0,
                         SickList_ResSm = 0,
                         AddAccr_SmClc = ((typeAddAccr.RefTypeAddAccr_Flg & (int)EnumTypeAddAccr_Flg.TypeAddAccr_Clc) > 0) ? addAccr.AddAccr_Sm : 0,
                         AddAccr_SmNoClc = ((typeAddAccr.RefTypeAddAccr_Flg & (int)EnumTypeAddAccr_Flg.TypeAddAccr_Clc) > 0) ? 0 : addAccr.AddAccr_Sm,
                         Accr_TotalSm = ((typeAddAccr.RefTypeAddAccr_Flg & (int)EnumTypeAddAccr_Flg.TypeAddAccr_Clc) > 0) ? addAccr.AddAccr_Sm : 0,
                     }).ToList()
                     );
                }
                else if (typeForm == EnumSalaryList.ByDep)
                {
                    _accrStatement.AddRange(
                    (from card in cards
                     join sal in salaries on card.PersCard_Id equals sal.Salary_PersCard_Id
                     join dep in deps on sal.Salary_RefDep_Id equals dep.RefDep_Id
                     where sal.Salary_Date == dat  
                       && id_dep.Contains(sal.Salary_RefDep_Id)
                     orderby card.PersCard_LName, card.PersCard_FName, card.PersCard_MName
                     select new RPR_AccrStatement
                     {
                         PersCard_Name = SalaryHelper.GetLastNameWithInit(card.PersCard_LName, card.PersCard_MName, card.PersCard_FName),
                         Month = dat.Month,
                         RefDep_Id = dep == null ? 0 : dep.RefDep_Id,
                         NameDep = dep == null ? string.Empty : dep.RefDep_Nm,
                         Salary_Days = sal.Salary_Days,
                         Salary_Hours = sal.Salary_Hours,
                         Salary_BaseSm = sal.Salary_BaseSm,
                         Salary_PensSm = sal.Salary_PensSm,
                         Salary_GradeSm = sal.Salary_GradeSm,
                         Salary_ExpSm = sal.Salary_ExpSm,
                         Salary_OthSm = sal.Salary_OthSm,
                         Salary_KTU = sal.Salary_KTU,
                         Salary_KTUSm = sal.Salary_KTUSm,
                         Salary_ResSm = sal.Salary_ResSm,
                         Vocation_Days = 0,
                         Vocation_Sm = 0,
                         SickList_DaysTmpDis = 0,
                         SickList_ResSm = 0,
                         AddAccr_SmClc = 0,
                         AddAccr_SmNoClc = 0,
                         Accr_TotalSm = sal.Salary_ResSm
                     }).ToList()
                     );
                    _accrStatement.AddRange(
                  (from card in cards
                   join vocation in vocs on card.PersCard_Id equals vocation.Vocation_PersCard_Id
                   join dep in deps on vocation.Vocation_RefDep_Id equals dep.RefDep_Id
                   where vocation.Vocation_Date == dat
                       && id_dep.Contains(vocation.Vocation_RefDep_Id)
                   orderby card.PersCard_LName, card.PersCard_FName, card.PersCard_MName
                   select new RPR_AccrStatement
                   {
                       PersCard_Name = SalaryHelper.GetLastNameWithInit(card.PersCard_LName, card.PersCard_MName, card.PersCard_FName),
                       Month = dat.Month,
                       RefDep_Id = dep == null ? 0 : dep.RefDep_Id,
                       NameDep = dep == null ? string.Empty : dep.RefDep_Nm,
                       Salary_Days = 0,
                       Salary_Hours = 0,
                       Salary_BaseSm = 0,
                       Salary_PensSm = 0,
                       Salary_GradeSm = 0,
                       Salary_ExpSm = 0,
                       Salary_OthSm = 0,
                       Salary_KTU = 0,
                       Salary_KTUSm = 0,
                       Salary_ResSm = 0,
                       Vocation_Days = vocation.Vocation_Days,
                       Vocation_Sm = vocation.Vocation_Sm,
                       SickList_DaysTmpDis = 0,
                       SickList_ResSm = 0,
                       AddAccr_SmClc = 0,
                       AddAccr_SmNoClc = 0,
                       Accr_TotalSm = vocation.Vocation_Sm
                   }).ToList()
                   );

                    _accrStatement.AddRange(
                  (from card in cards
                   join sick in lists on card.PersCard_Id equals sick.SickList_PersCard_Id
                   join dep in deps on sick.SickList_RefDep_Id equals dep.RefDep_Id
                   where sick.SickList_Date == dat
                       && id_dep.Contains(sick.SickList_RefDep_Id)
                   orderby card.PersCard_LName, card.PersCard_FName, card.PersCard_MName
                   select new RPR_AccrStatement
                   {
                       PersCard_Name = SalaryHelper.GetLastNameWithInit(card.PersCard_LName, card.PersCard_MName, card.PersCard_FName),
                       Month = dat.Month,
                       RefDep_Id = dep == null ? 0 : dep.RefDep_Id,
                       NameDep = dep == null ? string.Empty : dep.RefDep_Nm,
                       Salary_Days = 0,
                       Salary_Hours = 0,
                       Salary_BaseSm = 0,
                       Salary_PensSm = 0,
                       Salary_GradeSm = 0,
                       Salary_ExpSm = 0,
                       Salary_OthSm = 0,
                       Salary_KTU = 0,
                       Salary_KTUSm = 0,
                       Salary_ResSm = 0,
                       Vocation_Days = 0,
                       Vocation_Sm = 0,
                       SickList_DaysTmpDis = sick.SickList_DaysTmpDis,
                       SickList_ResSm = sick.SickList_ResSm,
                       AddAccr_SmClc = 0,
                       AddAccr_SmNoClc = 0,
                       Accr_TotalSm = sick.SickList_ResSm
                   }).ToList()
                   );

                    _accrStatement.AddRange(
                    (from card in cards
                     join addAccr in addAccrs on card.PersCard_Id equals addAccr.AddAccr_PersCard_Id
                     join typeAddAccr in typeAddAccrs on addAccr.AddAccr_RefTypeAddAccr_Id equals typeAddAccr.RefTypeAddAccr_Id
                     join dep in deps on addAccr.AddAccr_RefDep_Id equals dep.RefDep_Id
                     where addAccr.AddAccr_Date == dat
                       && id_dep.Contains(addAccr.AddAccr_RefDep_Id)
                     orderby card.PersCard_LName, card.PersCard_FName, card.PersCard_MName
                     select new RPR_AccrStatement
                     {
                         PersCard_Name = SalaryHelper.GetLastNameWithInit(card.PersCard_LName, card.PersCard_MName, card.PersCard_FName),
                         Month = dat.Month,
                         RefDep_Id = dep == null ? 0 : dep.RefDep_Id,
                         NameDep = dep == null ? string.Empty : dep.RefDep_Nm,
                         Salary_Days = 0,
                         Salary_Hours = 0,
                         Salary_BaseSm = 0,
                         Salary_PensSm = 0,
                         Salary_GradeSm = 0,
                         Salary_ExpSm = 0,
                         Salary_OthSm = 0,
                         Salary_KTU = 0,
                         Salary_KTUSm = 0,
                         Salary_ResSm = 0,
                         Vocation_Days = 0,
                         Vocation_Sm = 0,
                         SickList_DaysTmpDis = 0,
                         SickList_ResSm = 0,
                         AddAccr_SmClc = ((typeAddAccr.RefTypeAddAccr_Flg & (int)EnumTypeAddAccr_Flg.TypeAddAccr_Clc) > 0) ? addAccr.AddAccr_Sm : 0,
                         AddAccr_SmNoClc = ((typeAddAccr.RefTypeAddAccr_Flg & (int)EnumTypeAddAccr_Flg.TypeAddAccr_Clc) > 0) ? 0 : addAccr.AddAccr_Sm,
                         Accr_TotalSm = ((typeAddAccr.RefTypeAddAccr_Flg & (int)EnumTypeAddAccr_Flg.TypeAddAccr_Clc) > 0) ? addAccr.AddAccr_Sm : 0,
                     }).ToList()
                     );
                }
            }
            _accrStatement =
            (from accrStat in _accrStatement
             group accrStat by new { accrStat.Month, accrStat.PersCard_Name, accrStat.RefDep_Id, accrStat.NameDep } into gr
             select new RPR_AccrStatement
             {
                 PersCard_Name = gr.Key.PersCard_Name,
                 Month = gr.Key.Month,
                 RefDep_Id = gr.Key.RefDep_Id,
                 NameDep = gr.Key.NameDep,
                 Salary_Days = gr.Sum(rec => rec.Salary_Days),
                 Salary_Hours = gr.Sum(rec => rec.Salary_Hours),
                 Salary_BaseSm = gr.Sum(rec => rec.Salary_BaseSm),
                 Salary_PensSm = gr.Sum(rec => rec.Salary_PensSm),
                 Salary_GradeSm = gr.Sum(rec => rec.Salary_GradeSm),
                 Salary_ExpSm = gr.Sum(rec => rec.Salary_ExpSm),
                 Salary_OthSm = gr.Sum(rec => rec.Salary_OthSm),
                 Salary_KTU = gr.Sum(rec => rec.Salary_KTU),
                 Salary_KTUSm = gr.Sum(rec => rec.Salary_KTUSm),
                 Salary_ResSm = gr.Sum(rec => rec.Salary_ResSm),
                 Vocation_Days = gr.Sum(rec => rec.Vocation_Days),
                 Vocation_Sm = gr.Sum(rec => rec.Vocation_Sm),
                 SickList_DaysTmpDis = gr.Sum(rec => rec.SickList_DaysTmpDis),
                 SickList_ResSm = gr.Sum(rec => rec.SickList_ResSm),
                 AddAccr_SmClc = gr.Sum(rec => rec.AddAccr_SmClc),
                 AddAccr_SmNoClc = gr.Sum(rec => rec.AddAccr_SmNoClc),
                 Accr_TotalSm = gr.Sum(rec => rec.Accr_TotalSm)
             }).ToList();
            return true;
        }
        public AccrStatement(string name)
        {
            NameReport = name;
            DataSources = new List<ReportDataSource>();
            Parameters = new ReportParameter[2];
        }

        public bool StartReport()
        {
            fmAccrStatement fmAccrStat = new fmAccrStatement();
            if (fmAccrStat.ShowDialog() != DialogResult.OK)
                return false;
            string error = string.Empty;
            DateTime datBeg = fmAccrStat.GetDateBegParam();
            DateTime datEnd = fmAccrStat.GetDateEndParam();
            EnumSalaryList typeForm = fmAccrStat.GetFormParam();
            List<int> id_dep = fmAccrStat.GetIdCheckedDep();
            Parameters[0] = new ReportParameter("MonthNameBeg", SalaryHelper.GetMonthNameById(datBeg.Month, EnumCaseWorld.Genetive));
            Parameters[1] = new ReportParameter("MonthNameEnd", SalaryHelper.GetMonthNameById(datEnd.Month, EnumCaseWorld.Nominative));
      
            LoadDataForPrint(datBeg, datEnd, typeForm, id_dep, out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            ReportDataSource report = new ReportDataSource("dsAccrStatement", _accrStatement);
            DataSources.Add(report);
            return true;
        }
    }
}
