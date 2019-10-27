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
    public class AccrConsolidate : IReport
    {
        public string NameReport { get; }
        public List<ReportDataSource> DataSources { get; }
        public ReportParameter[] Parameters { get; }
        public SubreportProcessingEventHandler SubreportProc { get; }

        public List<RPR_AccrConsolidate> _accrConsolidate = new List<RPR_AccrConsolidate>();
        private SalaryRepository _repoSalary = new SalaryRepository(SetupProgram.Connection);
        private VocationRepository _repoVocation = new VocationRepository(SetupProgram.Connection);
        private SickListRepository _repoSickList = new SickListRepository(SetupProgram.Connection);
        private AddAccrRepository _repoAddAccr = new AddAccrRepository(SetupProgram.Connection);
        private RefTypeAddAccrRepository _repoTypeAddAccr = new RefTypeAddAccrRepository(SetupProgram.Connection);

        private PersCardRepository _repoCard = new PersCardRepository(SetupProgram.Connection);
        private RefDepRepository _repoDep = new RefDepRepository(SetupProgram.Connection);


        private bool LoadDataForPrint(DateTime dat, out string error)
        {
            error = string.Empty;

            List<Salary> salaries = _repoSalary.GetSalariesByParams(0, 0, dat, dat, out error);
            if (error != string.Empty)
            {
                return false;
            }
            List<Vocation> vocs = _repoVocation.GetVocationsByParams(0, 0, dat, dat, out error);
            if (error != string.Empty)
            {
                return false;
            }
            List<SickList> lists = _repoSickList.GetSickListsByParams(0, 0, dat, dat, out error);
            if (error != string.Empty)
            {
                return false;
            }
            List<RefDep> deps = _repoDep.GetAllDeps(out error);
            if (error != string.Empty)
            {
                return false;
            }
            List<AddAccr> addAccrs = _repoAddAccr.GetAddAccrByParams(0, 0, dat, dat, out error);
            if (error != string.Empty)
            {
                return false;
            }

            List<RefTypeAddAccr> typeAddAccrs = _repoTypeAddAccr.GetAllTypeAddAccr(out error);
            if (error != string.Empty)
            {
                return false;
            }

            _accrConsolidate.AddRange(
                    (from sal in salaries 
                     join dep in deps on sal.Salary_RefDep_Id equals dep.RefDep_Id
                     where sal.Salary_Date == dat
                     select new RPR_AccrConsolidate
                     {
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


            _accrConsolidate.AddRange(
           (from voc in vocs 
            join dep in deps on voc.Vocation_RefDep_Id equals dep.RefDep_Id
            where voc.Vocation_Date == dat
            select new RPR_AccrConsolidate
            {
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

            _accrConsolidate.AddRange(
          (from sick in lists 
           join dep in deps on sick.SickList_RefDep_Id equals dep.RefDep_Id
           where sick.SickList_Date == dat
           select new RPR_AccrConsolidate
           {
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

            _accrConsolidate.AddRange(
            (from addAccr in addAccrs 
             join typeAddAccr in typeAddAccrs on addAccr.AddAccr_RefTypeAddAccr_Id equals typeAddAccr.RefTypeAddAccr_Id
             join dep in deps on addAccr.AddAccr_RefDep_Id equals dep.RefDep_Id
             where addAccr.AddAccr_Date == dat
             select new RPR_AccrConsolidate
             {
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

            _accrConsolidate =
                        (from accrCons in _accrConsolidate
                         group accrCons by new { accrCons.RefDep_Id, accrCons.NameDep} into gr
                         select new RPR_AccrConsolidate
                         {
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
                         }).OrderBy(rec=>rec.NameDep).ToList();
            return true;
        }

        public AccrConsolidate(string name)
        {
            NameReport = name;
            DataSources = new List<ReportDataSource>();
            Parameters = new ReportParameter[1];
        }
        public bool StartReport()
        {
            fmAccrConsolidate fmAccrCons = new fmAccrConsolidate();
            if (fmAccrCons.ShowDialog() != DialogResult.OK)
                return false;
            string error = string.Empty;
            DateTime dat = fmAccrCons.GetDateParam();
            Parameters[0] = new ReportParameter("MonthName", SalaryHelper.GetMonthNameById(dat.Month, EnumCaseWorld.Genetive));

            LoadDataForPrint(dat, out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            ReportDataSource report = new ReportDataSource("dsAccrConsolidate", _accrConsolidate);
            DataSources.Add(report);
            return true;
        }
    }
}
