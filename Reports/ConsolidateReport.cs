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
    public class ConsolidateReport : IReport
    {
        public string NameReport { get; }
        public List<ReportDataSource> DataSources { get; }
        public ReportParameter[] Parameters { get; }
        public SubreportProcessingEventHandler SubreportProc { get; }

        private ACSRepository _repoACS = new ACSRepository(SetupProgram.Connection);


        public ConsolidateReport(string name)
        {
            NameReport = name;
            //DataSources = new List<ReportDataSource>();
            Parameters = new ReportParameter[34];
            //NameReport = name;
            //DataSources = new List<ReportDataSource>();
            ////List<RPR_Cnsldt_SickList> cons = new List<RPR_Cnsldt_SickList>();
            ////
            ////ReportDataSource report = new ReportDataSource("DataSet1", cons);
            //
            ////DataSources.Add(report);
            //parameters = new ReportParameter[34];

            //parameters[13] = new ReportParameter("LivWageBeforeFromSm", "0.00");
            //parameters[14] = new ReportParameter("LivWageBeforeCntWrk", "10");
            //parameters[15] = new ReportParameter("LivWageBeforeSm", "0.00");
            //parameters[16] = new ReportParameter("LivWageAfterFromSm", "0.00");
            //parameters[17] = new ReportParameter("LivWageAfterCntWrk", "10");
            //parameters[18] = new ReportParameter("LivWageAfterSm", "0l00");
            //parameters[19] = new ReportParameter("LivWageSm", "0");
            //parameters[20] = new ReportParameter("LivWageCntDis", "10");
            //parameters[21] = new ReportParameter("TaxConstFromSm", "0.00");
            //parameters[22] = new ReportParameter("TaxConstCntWrk", "10");
            //parameters[23] = new ReportParameter("TaxConstSm", "0.00");
            //parameters[24] = new ReportParameter("TaxAssFromSm", "0.00");
            //parameters[25] = new ReportParameter("TaxAssCntWrk", "10");
            //parameters[26] = new ReportParameter("TaxAssSm", "0.00");
            //parameters[27] = new ReportParameter("TaxTmpFromSm", "0.00");
            //parameters[28] = new ReportParameter("TaxTmpCntWrk", "10");
            //parameters[29] = new ReportParameter("TaxTmpSm", "0.00");
            //parameters[30] = new ReportParameter("SickListEntprsDays", "10");
            //parameters[31] = new ReportParameter("SickListEntprsSm", "0.00");
            //parameters[32] = new ReportParameter("SickListSocInsDays", "10");
            //parameters[33] = new ReportParameter("SickListSocInsSm", "0.00");
        }

        private bool LoadDataForPrint(DateTime dat, out string error)
        {
            error = string.Empty;
            List<ACS> acses = _repoACS.GetAllACSByParam(dat, out error);
            if (error != string.Empty)
                return false;

            decimal LawConstFromSm = 0;
            int LawConstCntWrk = 0;
            decimal LawTmpFromSm = 0;
            int LawTmpCntWrk = 0;
            decimal LawAssFromSm = 0;
            int LawAssCntWrk = 0;
            decimal LivWageSm = 0;
            int LivWageCntDis = 0;

            decimal TaxConstFromSm = 0;
            int TaxConstCntWrk = 0;
            decimal TaxConstSm = 0;
            decimal TaxAssFromSm = 0;
            int TaxAssCntWrk = 0;
            decimal TaxAssSm = 0;
            decimal TaxTmpFromSm = 0;
            int TaxTmpCntWrk = 0;
            decimal TaxTmpSm = 0;
            int SickListEntprsDays = 0;
            decimal SickListEntprsSm = 0;
            int SickListSocInsDays = 0;
            decimal SickListSocInsSm = 0;

            foreach (ACS acs in acses)
            {
                decimal LawFromSmCurCard = 0;

                LawFromSmCurCard += acs.Salary_BaseSm;  //Основная зарплата
                LawFromSmCurCard += acs.Salary_PensSm;  //Доплата пенсионеру
                LawFromSmCurCard += acs.Salary_GradeSm; //Надбавка за классность
                LawFromSmCurCard += acs.Salary_OthSm;   //Другие надбавки
                LawFromSmCurCard += acs.Salary_KTUSm;   //Согласно с КТУ
                LawFromSmCurCard += acs.LawContract_Sm; //Договорая ГПХ
                LawFromSmCurCard += acs.AddAccr_SmClc;  //Дополнительные начисления рассчитываемые
                LawFromSmCurCard += acs.Vocation_Sm;    //Начислено отпускных
                LawFromSmCurCard += acs.SickList_ResSm;  //Больничные
                if (acs.CardStatus_Type == (int)EnumCardStatus.Constant)
                {
                    if (LawFromSmCurCard > 0)
                    {
                        LawConstCntWrk++;
                        LawConstFromSm += LawFromSmCurCard - acs.SickList_ResSm;
                    }
                    TaxConstFromSm += LawFromSmCurCard;
                    if(acs.Tax_Sm != 0)
                    {
                        TaxConstCntWrk++;
                        TaxConstSm += acs.Tax_Sm;
                    }
                }
                if (acs.CardStatus_Type == (int)EnumCardStatus.Temporary)
                {
                    if (LawFromSmCurCard > 0)
                    {
                        LawTmpCntWrk++;
                        LawTmpFromSm += LawFromSmCurCard - acs.SickList_ResSm;
                    }
                    TaxTmpFromSm += LawFromSmCurCard;
                    if (acs.Tax_Sm != 0)
                    {
                        TaxTmpCntWrk++;
                        TaxTmpSm += acs.Tax_Sm;
                    }
                }
                if (acs.CardStatus_Type == (int)EnumCardStatus.Associative)
                {
                    if (LawFromSmCurCard > 0)
                    {
                        LawAssCntWrk++;
                        LawAssFromSm += LawFromSmCurCard - acs.SickList_ResSm;
                    }
                    TaxAssFromSm += LawFromSmCurCard;
                    if (acs.Tax_Sm != 0)
                    {
                        TaxAssCntWrk++;
                        TaxAssSm += acs.Tax_Sm;
                    }
                }
                if (acs.Disability_Attr == 2)
                {
                    LivWageSm += LawFromSmCurCard;
                    LivWageCntDis++;
                }
                SickListEntprsDays += acs.SickList_DaysEntprs;
                SickListEntprsSm += acs.SickList_SmEntprs;
                SickListSocInsDays += acs.SickList_DaysSocInsrnc;
                SickListSocInsSm += acs.SickList_SmSocInsrnc;
            }

            Parameters[0] = new ReportParameter("MonthName", SalaryHelper.GetMonthNameById(dat.Month, EnumCaseWorld.Nominative));
            //Отчет по ЕСВ. Больничные. Всегда 0
            Parameters[1] = new ReportParameter("SickListFromSm", "0.00");
            Parameters[2] = new ReportParameter("SickListCntWrk", "0");
            Parameters[3] = new ReportParameter("SickListSm", "0.00");
            //Отчет по ЕСВ. Договора ГПХ. Всегда 0
            Parameters[4] = new ReportParameter("LawConstFromSm", LawConstFromSm.ToString("0.00"));
            Parameters[5] = new ReportParameter("LawConstCntWrk", LawConstCntWrk.ToString());
            Parameters[6] = new ReportParameter("LawConstSm", "0.00"); //всегда 0
            Parameters[7] = new ReportParameter("LawAssFromSm", LawAssFromSm.ToString("0.00"));
            Parameters[8] = new ReportParameter("LawAssCntWrk", LawAssCntWrk.ToString());
            Parameters[9] = new ReportParameter("LawAssSm", "0.00");  //всегда 0
            Parameters[10] = new ReportParameter("LawTmpFromSm", LawTmpFromSm.ToString("0.00"));
            Parameters[11] = new ReportParameter("LawTmpCntWrk", LawTmpCntWrk.ToString());
            Parameters[12] = new ReportParameter("LawTmpSm", "0.00");  //всегда 0
            //Отчет по ЕСВ. Зарплата без больничных. 
            Parameters[13] = new ReportParameter("LivWageBeforeFromSm", "0.00"); //Всегда 0
            Parameters[14] = new ReportParameter("LivWageBeforeCntWrk", "0");    //Всегда 0
            Parameters[15] = new ReportParameter("LivWageBeforeSm", "0.00");     //Всегда 0
            Parameters[16] = new ReportParameter("LivWageAfterFromSm", "0.00");  //Всегда 0
            Parameters[17] = new ReportParameter("LivWageAfterCntWrk", "0");     //Всегда 0
            Parameters[18] = new ReportParameter("LivWageAfterSm", "0.00");      //Всегда 0  
            Parameters[19] = new ReportParameter("LivWageSm", LivWageSm.ToString("0.00"));
            Parameters[20] = new ReportParameter("LivWageCntDis", LivWageCntDis.ToString());
            //Отчет про подоходный налог
            Parameters[21] = new ReportParameter("TaxConstFromSm", TaxConstFromSm.ToString("0.00"));
            Parameters[22] = new ReportParameter("TaxConstCntWrk", TaxConstCntWrk.ToString());
            Parameters[23] = new ReportParameter("TaxConstSm", TaxConstSm.ToString("0.00"));
            Parameters[24] = new ReportParameter("TaxAssFromSm", TaxAssFromSm.ToString("0.00"));
            Parameters[25] = new ReportParameter("TaxAssCntWrk", TaxAssCntWrk.ToString());
            Parameters[26] = new ReportParameter("TaxAssSm", TaxAssSm.ToString("0.00"));
            Parameters[27] = new ReportParameter("TaxTmpFromSm", TaxTmpFromSm.ToString("0.00"));
            Parameters[28] = new ReportParameter("TaxTmpCntWrk", TaxTmpCntWrk.ToString());
            Parameters[29] = new ReportParameter("TaxTmpSm", TaxTmpSm.ToString("0.00"));
            //Отчет о начислениях по больничным листам
            Parameters[30] = new ReportParameter("SickListEntprsDays", SickListEntprsDays.ToString());
            Parameters[31] = new ReportParameter("SickListEntprsSm", SickListEntprsSm.ToString("0.00"));
            Parameters[32] = new ReportParameter("SickListSocInsDays", SickListSocInsDays.ToString());
            Parameters[33] = new ReportParameter("SickListSocInsSm", SickListSocInsSm.ToString("0.00"));
            return true;
        }

        public bool StartReport()
        {
            fmConsolidateReport fmConsReport = new fmConsolidateReport();
            if (fmConsReport.ShowDialog() != DialogResult.OK)
                return false;
            string error = string.Empty;
            DateTime dat = fmConsReport.GetDateParam();

            LoadDataForPrint(dat, out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            return true;
        }
    }
}
