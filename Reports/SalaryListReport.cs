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
    public class SalaryListReport : IReport
    {
        private PersCardRepository _repoCard = new PersCardRepository(SetupProgram.Connection);
        private SalaryRepository _repoSalary = new SalaryRepository(SetupProgram.Connection);
        //private SalBalanceRepository _repoSalBalance = new SalBalanceRepository(SetupProgram.Connection);
        private RefDepRepository _repoDep = new RefDepRepository(SetupProgram.Connection);
        private VocationRepository _repoVocation = new VocationRepository(SetupProgram.Connection);
        private SickListRepository _repoSickList = new SickListRepository(SetupProgram.Connection);
        private LawContractRepository _repoLaw = new LawContractRepository(SetupProgram.Connection);
        private PaymentRepository _repoPayment = new PaymentRepository(SetupProgram.Connection);
        private AddAccrRepository _repoAddAccr = new AddAccrRepository(SetupProgram.Connection);
        private RefTypeAddAccrRepository _repoTypeAddAccr = new RefTypeAddAccrRepository(SetupProgram.Connection);
        private AddPaymentRepository _repoAddPayment = new AddPaymentRepository(SetupProgram.Connection);
        private RefTypeAddPaymentRepository _repoTypeAddPayment = new RefTypeAddPaymentRepository(SetupProgram.Connection);
        private ACSRepository _repoAcs = new ACSRepository(SetupProgram.Connection);

        private List<RPR_VocSickLaw> _vocSickLaw = null;
        private List<RPR_PaymentAccr> _paymentAccr = null;
        private List<RPR_SalaryList> _salaryList = null;
        private List<ACS> _acses = null;

        private List<int> _checkedId = null;

        public string NameReport { get; }
        public List<ReportDataSource> DataSources { get; }
        public ReportParameter[] Parameters { get; }
        public SubreportProcessingEventHandler SubreportProc { get; }

        private bool LoadDataForPrint(DateTime dat, EnumSalaryList typeForm, List<int> id_dep, out string error)
        {
            error = string.Empty;
            List<PersCard> cards = _repoCard.GetAllCards(out error);
            if (error != string.Empty)
            {
                return false;
            }
            List<Salary> salaries = _repoSalary.GetSalariesByParams(0, 0, dat, dat, out error);
            if (error != string.Empty)
            {
                return false;
            }
            List<RefDep> deps = _repoDep.GetAllDeps(out error);
            if (error != string.Empty)
            {
                return false;
            }
            List<Vocation> vocations = _repoVocation.GetVocationsByParams(0, 0, dat, dat, out error);
            if (error != string.Empty)
            {
                return false;
            }
            List<SickList> sickLists = _repoSickList.GetSickListsByParams(0, 0, dat, dat, out error);
            if (error != string.Empty)
            {
                return false;
            }
            List<LawContract> lawContracts = _repoLaw.GetLawContractsByParams(0, 0, dat, dat, out error);
            if (error != string.Empty)
            {
                return false;
            }
            List<Payment> payments = _repoPayment.GetPaymentByParams(0, 0, dat, dat, out error);
            if (error != string.Empty)
            {
                return false;
            }
            List<v_TypePayment> typePayment = TypePaymentHelper.GetTypePayment();
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
            List<AddPayment> addPayment = _repoAddPayment.GetAddPaymentsByParams(0, 0, dat, dat, out error);
            if (error != string.Empty)
            {
                return false;
            }
            List<RefTypeAddPayment> typeAddPayment = _repoTypeAddPayment.GetAllTypeAddPayments(out error);
            if (error != string.Empty)
            {
                return false;
            }
            _acses = _repoAcs.GetAllACSByParam(dat, out error);
            if (error != string.Empty)
            {
                return false;
            }
            if (typeForm == EnumSalaryList.ByFirma)
            {
                _paymentAccr =
                    (from pay in payments
                     join type in typePayment on pay.Payment_Type equals type.Id into typ
                     from type in typ.DefaultIfEmpty()
                     select new RPR_PaymentAccr
                     {
                         PersCard_Id = pay.Payment_PersCard_Id,
                         TypeName = "Виплати",
                         Name = type.Name,
                         Sm = pay.Payment_Sm
                     }
                     ).ToList();
                _paymentAccr.AddRange(
                    (from accr in addAccrs
                     join type in typeAddAccrs on accr.AddAccr_RefTypeAddAccr_Id equals type.RefTypeAddAccr_Id into typ
                     from type in typ.DefaultIfEmpty()
                     select new RPR_PaymentAccr
                     {
                         PersCard_Id = accr.AddAccr_PersCard_Id,
                         TypeName = "Додаткові нарахування",
                         Name = type.RefTypeAddAccr_Nm + " (" + (
                            ((type.RefTypeAddAccr_Flg & (int)EnumTypeAddAccr_Flg.TypeAddAccr_Clc) > 0) ?
                           "Розрах." : "Не розрах.") + ")",
                         Sm = accr.AddAccr_Sm
                     }
                     )
                    );
                _paymentAccr.AddRange(
                    (from addPay in addPayment
                     join type in typeAddPayment on addPay.AddPayment_TypeAddPayment_Id equals type.RefTypeAddPayment_Id into typ
                     from type in typ.DefaultIfEmpty()
                     select new RPR_PaymentAccr
                     {
                         PersCard_Id = addPay.AddPayment_PersCard_Id,
                         TypeName = "Додаткові виплати",
                         Name = type.RefTypeAddPayment_Nm,
                         Sm = addPay.AddPayment_Sm
                     }
                     )
                     );
                _vocSickLaw =
                    (from voc in vocations
                     join dep in deps on voc.Vocation_RefDep_Id equals dep.RefDep_Id into dep
                     from department in dep.DefaultIfEmpty()
                     select new RPR_VocSickLaw
                     {
                         PersCard_Id = voc.Vocation_PersCard_Id,
                         TypeName = "Відпускні",
                         RefDep_Name = department.RefDep_Nm,
                         Days = voc.Vocation_Days,
                         Sm = voc.Vocation_Sm
                     }
                     ).ToList();
                _vocSickLaw.AddRange(
                    (from list in sickLists
                     join dep in deps on list.SickList_RefDep_Id equals dep.RefDep_Id into dep
                     from department in dep.DefaultIfEmpty()
                     select new RPR_VocSickLaw
                     {
                         PersCard_Id = list.SickList_PersCard_Id,
                         TypeName = "Лікарняні",
                         RefDep_Name = department.RefDep_Nm,
                         Days = list.SickList_DaysTmpDis,
                         Sm = list.SickList_ResSm
                     }
                    ).ToList()
                    );
                _vocSickLaw.AddRange(
                    (from contract in lawContracts
                     join dep in deps on contract.LawContract_RefDep_Id equals dep.RefDep_Id into dep
                     from department in dep.DefaultIfEmpty()
                     select new RPR_VocSickLaw
                     {
                         PersCard_Id = contract.LawContract_PersCard_Id,
                         TypeName = "Договора ЦПХ",
                         RefDep_Name = department.RefDep_Nm,
                         Days = contract.LawContract_Days,
                         Sm = contract.LawContract_Sm
                     }
                    ).ToList()
                    );
                _salaryList =
                    (from card in cards
                     join salary in salaries on card.PersCard_Id equals salary.Salary_PersCard_Id into sal
                     from salary in sal.DefaultIfEmpty()
                     join acs in _acses on card.PersCard_Id equals acs.PersCard_Id into rec
                     from acs in rec.DefaultIfEmpty()
                     join dep in deps on (salary == null ? 0 : salary.Salary_RefDep_Id) equals dep.RefDep_Id into dep
                     from department in dep.DefaultIfEmpty()
                     select new RPR_SalaryList
                     {
                         PersCard_Id = card.PersCard_Id,
                         PersCard_LName = card.PersCard_LName,
                         PersCard_FName = card.PersCard_FName,
                         PersCard_MName = card.PersCard_MName,
                         PersCard_TIN = card.PersCard_TIN,
                         Salary_DepName = department == null ? string.Empty : department.RefDep_Nm,
                         SalBalance_BegMonthSm = acs == null ? 0 : acs.SalBalance_BegMonthSm,
                         SalBalance_EndMonthSm = acs == null ? 0 : acs.SalBalance_EndMonthSm,
                         Salary_Days = salary == null ? 0 : salary.Salary_Days,
                         Salary_Hours = salary == null ? 0 : salary.Salary_Hours,
                         Salary_BaseSm = salary == null ? 0 : salary.Salary_BaseSm,
                         Salary_PensSm = salary == null ? 0 : salary.Salary_PensSm,
                         Salary_GradeSm = salary == null ? 0 : salary.Salary_GradeSm,
                         Salary_ExpSm = salary == null ? 0 : salary.Salary_ExpSm,
                         Salary_OthSm = salary == null ? 0 : salary.Salary_OthSm,
                         Salary_KTU = salary == null ? 0 : salary.Salary_KTU,
                         Salary_KTUSm = salary == null ? 0 : salary.Salary_KTUSm,
                         Salary_ResSm = salary == null ? 0 : salary.Salary_ResSm,
                         Tax_Sm = acs == null ? 0 : acs.Tax_Sm,
                         Prof_Sm = acs == null ? 0 : acs.Prof_Sm,
                         Military_Sm = acs == null ? 0 : acs.Military_Sm,
                         TotalDeduct_Sm = acs == null ? 0 : (acs.Tax_Sm + acs.Prof_Sm + acs.Military_Sm),
                         NameMonth = SalaryHelper.GetMonthNameById(dat.Month, EnumCaseWorld.Nominative)
                     }).ToList();
            }
            else if (typeForm == EnumSalaryList.ByDep)
            {
                //Выплаты
                _paymentAccr =
                   (from pay in payments
                    join salary in salaries on pay.Payment_PersCard_Id equals salary.Salary_PersCard_Id
                    join department in deps on salary.Salary_RefDep_Id equals department.RefDep_Id
                    join type in typePayment on pay.Payment_Type equals type.Id into typ
                    from type in typ.DefaultIfEmpty()
                    where id_dep.Contains(department.RefDep_Id)
                    select new RPR_PaymentAccr
                    {
                        PersCard_Id = pay.Payment_PersCard_Id,
                        TypeName = "Виплати",
                        Name = type.Name,
                        Sm = pay.Payment_Sm
                    }
                    ).ToList();
                _paymentAccr.AddRange(
                    (from accr in addAccrs
                     join salary in salaries on accr.AddAccr_PersCard_Id equals salary.Salary_PersCard_Id
                     join department in deps on salary.Salary_RefDep_Id equals department.RefDep_Id
                     join type in typeAddAccrs on (accr == null ? 0 : accr.AddAccr_RefTypeAddAccr_Id) equals type.RefTypeAddAccr_Id into typ
                     from type in typ.DefaultIfEmpty()
                     where id_dep.Contains(department.RefDep_Id)
                     select new RPR_PaymentAccr
                     {
                         PersCard_Id = accr.AddAccr_PersCard_Id,
                         TypeName = "Додаткові нарахування",
                         Name = type.RefTypeAddAccr_Nm + " (" + (
                           ((type.RefTypeAddAccr_Flg & (int)EnumTypeAddAccr_Flg.TypeAddAccr_Clc) > 0) ?
                           "Розрах." : "Не розрах.") + ")",
                         Sm = accr.AddAccr_Sm
                     }
                     )
                    );
                _paymentAccr.AddRange(
                    (from addPay in addPayment
                     join salary in salaries on addPay.AddPayment_PersCard_Id equals salary.Salary_PersCard_Id
                     join department in deps on salary.Salary_RefDep_Id equals department.RefDep_Id
                     join type in typeAddPayment on (addPay == null ? 0 : addPay.AddPayment_TypeAddPayment_Id) equals type.RefTypeAddPayment_Id into typ
                     from type in typ.DefaultIfEmpty()
                     where id_dep.Contains(department.RefDep_Id)
                     select new RPR_PaymentAccr
                     {
                         PersCard_Id = addPay.AddPayment_PersCard_Id,
                         TypeName = "Додаткові виплати",
                         Name = type.RefTypeAddPayment_Nm,
                         Sm = addPay.AddPayment_Sm
                     }
                     )
                     );
                _vocSickLaw =
                    (from voc in vocations
                     join salary in salaries on voc.Vocation_PersCard_Id equals salary.Salary_PersCard_Id
                     join department in deps on salary.Salary_RefDep_Id equals department.RefDep_Id
                     where id_dep.Contains(department.RefDep_Id)
                     select new RPR_VocSickLaw
                     {
                         PersCard_Id = voc.Vocation_PersCard_Id,
                         TypeName = "Відпускні",
                         RefDep_Name = department.RefDep_Nm,
                         Days = voc.Vocation_Days,
                         Sm = voc.Vocation_Sm
                     }
                     ).ToList();
                _vocSickLaw.AddRange(
                    (from list in sickLists
                     join salary in salaries on list.SickList_PersCard_Id equals salary.Salary_PersCard_Id
                     join department in deps on salary.Salary_RefDep_Id equals department.RefDep_Id
                     where id_dep.Contains(department.RefDep_Id)
                     select new RPR_VocSickLaw
                     {
                         PersCard_Id = list.SickList_PersCard_Id,
                         TypeName = "Лікарняні",
                         RefDep_Name = department.RefDep_Nm,
                         Days = list.SickList_DaysTmpDis,
                         Sm = list.SickList_ResSm
                     }
                    ).ToList()
                    );
                _vocSickLaw.AddRange(
                    (from contract in lawContracts
                     join salary in salaries on contract.LawContract_PersCard_Id equals salary.Salary_PersCard_Id
                     join department in deps on salary.Salary_RefDep_Id equals department.RefDep_Id
                     where id_dep.Contains(department.RefDep_Id)
                     select new RPR_VocSickLaw
                     {
                         PersCard_Id = contract.LawContract_PersCard_Id,
                         TypeName = "Договора ЦПХ",
                         RefDep_Name = department.RefDep_Nm,
                         Days = contract.LawContract_Days,
                         Sm = contract.LawContract_Sm
                     }
                    ).ToList()
                    );

                _salaryList =
                    (from card in cards
                     join salary in salaries on card.PersCard_Id equals salary.Salary_PersCard_Id 
                     join department in deps on salary.Salary_RefDep_Id equals department.RefDep_Id 
                     join acs in _acses on card.PersCard_Id equals acs.PersCard_Id into rec
                     from acs in rec.DefaultIfEmpty()
                     where id_dep.Contains(salary.Salary_RefDep_Id)
                     select new RPR_SalaryList
                     {
                         PersCard_Id = card.PersCard_Id,
                         PersCard_LName = card.PersCard_LName,
                         PersCard_FName = card.PersCard_FName,
                         PersCard_MName = card.PersCard_MName,
                         PersCard_TIN = card.PersCard_TIN,
                         Salary_DepName = department == null ? string.Empty : department.RefDep_Nm,
                         SalBalance_BegMonthSm = acs == null ? 0 : acs.SalBalance_BegMonthSm,
                         SalBalance_EndMonthSm = acs == null ? 0 : acs.SalBalance_EndMonthSm,
                         Salary_Days = salary == null ? 0 : salary.Salary_Days,
                         Salary_Hours = salary == null ? 0 : salary.Salary_Hours,
                         Salary_BaseSm = salary == null ? 0 : salary.Salary_BaseSm,
                         Salary_PensSm = salary == null ? 0 : salary.Salary_PensSm,
                         Salary_GradeSm = salary == null ? 0 : salary.Salary_GradeSm,
                         Salary_ExpSm = salary == null ? 0 : salary.Salary_ExpSm,
                         Salary_OthSm = salary == null ? 0 : salary.Salary_OthSm,
                         Salary_KTU = salary == null ? 0 : salary.Salary_KTU,
                         Salary_KTUSm = salary == null ? 0 : salary.Salary_KTUSm,
                         Salary_ResSm = salary == null ? 0 : salary.Salary_ResSm,
                         Tax_Sm = acs == null ? 0 : acs.Tax_Sm,
                         Prof_Sm = acs == null ? 0 : acs.Prof_Sm,
                         Military_Sm = acs == null ? 0 : acs.Military_Sm,
                         TotalDeduct_Sm = acs == null ? 0 : (acs.Tax_Sm + acs.Prof_Sm + acs.Military_Sm),
                         NameMonth = SalaryHelper.GetMonthNameById(dat.Month, EnumCaseWorld.Nominative)
                     }).ToList();
            }
            else if (typeForm == EnumSalaryList.ByPersCard)
            {
                _paymentAccr =
                    (from pay in payments
                     join type in typePayment on pay.Payment_Type equals type.Id into typ
                     from type in typ.DefaultIfEmpty()
                     where _checkedId.Contains(pay.Payment_PersCard_Id)
                     select new RPR_PaymentAccr
                     {
                         PersCard_Id = pay.Payment_PersCard_Id,
                         TypeName = "Виплати",
                         Name = type.Name,
                         Sm = pay.Payment_Sm
                     }
                     ).ToList();
                _paymentAccr.AddRange(
                    (from accr in addAccrs
                     join type in typeAddAccrs on accr.AddAccr_RefTypeAddAccr_Id equals type.RefTypeAddAccr_Id into typ
                     from type in typ.DefaultIfEmpty()
                     where _checkedId.Contains(accr.AddAccr_PersCard_Id)
                     select new RPR_PaymentAccr
                     {
                         PersCard_Id = accr.AddAccr_PersCard_Id,
                         TypeName = "Додаткові нарахування",
                         Name = type.RefTypeAddAccr_Nm + " (" + (
                           ((type.RefTypeAddAccr_Flg & (int)EnumTypeAddAccr_Flg.TypeAddAccr_Clc) > 0) ?
                           "Розрах." : "Не розрах.") + ")",
                         Sm = accr.AddAccr_Sm
                     }
                     )
                    );
                _paymentAccr.AddRange(
                    (from addPay in addPayment
                     join type in typeAddPayment on addPay.AddPayment_TypeAddPayment_Id equals type.RefTypeAddPayment_Id into typ
                     from type in typ.DefaultIfEmpty()
                     where _checkedId.Contains(addPay.AddPayment_PersCard_Id)
                     select new RPR_PaymentAccr
                     {
                         PersCard_Id = addPay.AddPayment_PersCard_Id,
                         TypeName = "Додаткові виплати",
                         Name = type.RefTypeAddPayment_Nm,
                         Sm = addPay.AddPayment_Sm
                     }
                     )
                     );
                _vocSickLaw =
                    (from voc in vocations
                     join dep in deps on voc.Vocation_RefDep_Id equals dep.RefDep_Id into dep
                     from department in dep.DefaultIfEmpty()
                     where _checkedId.Contains(voc.Vocation_PersCard_Id)
                     select new RPR_VocSickLaw
                     {
                         PersCard_Id = voc.Vocation_PersCard_Id,
                         TypeName = "Відпускні",
                         RefDep_Name = department.RefDep_Nm,
                         Days = voc.Vocation_Days,
                         Sm = voc.Vocation_Sm
                     }
                     ).ToList();
                _vocSickLaw.AddRange(
                    (from list in sickLists
                     join dep in deps on list.SickList_RefDep_Id equals dep.RefDep_Id into dep
                     from department in dep.DefaultIfEmpty()
                     where _checkedId.Contains(list.SickList_PersCard_Id)
                     select new RPR_VocSickLaw
                     {
                         PersCard_Id = list.SickList_PersCard_Id,
                         TypeName = "Лікарняні",
                         RefDep_Name = department.RefDep_Nm,
                         Days = list.SickList_DaysTmpDis,
                         Sm = list.SickList_ResSm
                     }
                    ).ToList()
                    );
                _vocSickLaw.AddRange(
                    (from contract in lawContracts
                     join dep in deps on contract.LawContract_RefDep_Id equals dep.RefDep_Id into dep
                     from department in dep.DefaultIfEmpty()
                     where _checkedId.Contains(contract.LawContract_PersCard_Id)
                     select new RPR_VocSickLaw
                     {
                         PersCard_Id = contract.LawContract_PersCard_Id,
                         TypeName = "Договора ЦПХ",
                         RefDep_Name = department.RefDep_Nm,
                         Days = contract.LawContract_Days,
                         Sm = contract.LawContract_Sm
                     }
                    ).ToList()
                    );

                _salaryList =
                    (from card in cards
                     join salary in salaries on card.PersCard_Id equals salary.Salary_PersCard_Id into sal
                     from salary in sal.DefaultIfEmpty()
                     join acs in _acses on card.PersCard_Id equals acs.PersCard_Id into rec
                     from acs in rec.DefaultIfEmpty()
                     join dep in deps on (salary == null ? 0 : salary.Salary_RefDep_Id) equals dep.RefDep_Id into dep
                     from department in dep.DefaultIfEmpty()
                     where _checkedId.Contains(card.PersCard_Id)
                     select new RPR_SalaryList
                     {
                         PersCard_Id = card.PersCard_Id,
                         PersCard_LName = card.PersCard_LName,
                         PersCard_FName = card.PersCard_FName,
                         PersCard_MName = card.PersCard_MName,
                         PersCard_TIN = card.PersCard_TIN,
                         Salary_DepName = department == null ? string.Empty : department.RefDep_Nm,
                         SalBalance_BegMonthSm = acs == null ? 0 : acs.SalBalance_BegMonthSm,
                         SalBalance_EndMonthSm = acs == null ? 0 : acs.SalBalance_EndMonthSm,
                         Salary_Days = salary == null ? 0 : salary.Salary_Days,
                         Salary_Hours = salary == null ? 0 : salary.Salary_Hours,
                         Salary_BaseSm = salary == null ? 0 : salary.Salary_BaseSm,
                         Salary_PensSm = salary == null ? 0 : salary.Salary_PensSm,
                         Salary_GradeSm = salary == null ? 0 : salary.Salary_GradeSm,
                         Salary_ExpSm = salary == null ? 0 : salary.Salary_ExpSm,
                         Salary_OthSm = salary == null ? 0 : salary.Salary_OthSm,
                         Salary_KTU = salary == null ? 0 : salary.Salary_KTU,
                         Salary_KTUSm = salary == null ? 0 : salary.Salary_KTUSm,
                         Salary_ResSm = salary == null ? 0 : salary.Salary_ResSm,
                         Tax_Sm = acs == null ? 0 : acs.Tax_Sm,
                         Prof_Sm = acs == null ? 0 : acs.Prof_Sm,
                         Military_Sm = acs == null ? 0 : acs.Military_Sm,
                         TotalDeduct_Sm = acs == null ? 0 : (acs.Tax_Sm + acs.Prof_Sm + acs.Military_Sm),
                         NameMonth = SalaryHelper.GetMonthNameById(dat.Month, EnumCaseWorld.Nominative)
                     }).ToList();
            }
            return true;
        }

        public SalaryListReport(string name, List<int> id)
        {
            NameReport = name;
            _checkedId = id;
            DataSources = new List<ReportDataSource>();
            SubreportProc += SubreportVocSickLaw;
            SubreportProc += SubreportPaymentAccr;
            SubreportProc += SubreportTaxes;
        }

        public bool StartReport()
        {
            fmSalaryList fmList = new fmSalaryList(_checkedId == null ? false : true);
            if (fmList.ShowDialog() != DialogResult.OK)
                return false;

            string error = string.Empty;
            DateTime dat = fmList.GetDateParam();
            EnumSalaryList typeForm = fmList.GetFormParam();
            List<int> id_dep = fmList.GetIdCheckedDep();
            LoadDataForPrint(dat, typeForm, id_dep, out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            ReportDataSource report = new ReportDataSource("dsSalaryList", _salaryList);
            DataSources.Add(report);
            return true;
        }

        private void SubreportVocSickLaw(object sender, SubreportProcessingEventArgs e)
        {
            if (_vocSickLaw != null)
            {                
                int PersCard_Id = int.Parse(e.Parameters["PersCard_Id"].Values[0].ToString());
                List<RPR_VocSickLaw> recorcds = _vocSickLaw.Where(rec => rec.PersCard_Id == PersCard_Id).ToList();
                ReportDataSource report = new ReportDataSource("dsVocSickLaw", recorcds);
                e.DataSources.Add(report);
            }
        }
        private void SubreportPaymentAccr(object sender, SubreportProcessingEventArgs e)
        {
            if (_paymentAccr != null)
            {
                int PersCard_Id = int.Parse(e.Parameters["PersCard_Id"].Values[0].ToString());
                List<RPR_PaymentAccr> recorcds = _paymentAccr.Where(rec => rec.PersCard_Id == PersCard_Id).ToList();
                ReportDataSource report = new ReportDataSource("dsPaymentAccr", recorcds);
                e.DataSources.Add(report);
            }
        }
        private void SubreportTaxes(object sender, SubreportProcessingEventArgs e)
        {
            if (_paymentAccr != null)
            {
                int PersCard_Id = int.Parse(e.Parameters["PersCard_Id"].Values[0].ToString());
                List<RPR_SalaryList> recorcds = 
                    (from acs in _acses
                    where acs.PersCard_Id == PersCard_Id
                    select new RPR_SalaryList
                    {
                        PersCard_Id = acs.PersCard_Id,
                        PersCard_LName = acs.PersCard_LName,
                        PersCard_FName = acs.PersCard_FName,
                        PersCard_MName = acs.PersCard_MName,
                        PersCard_TIN = acs.PersCard_TIN,
                        Tax_Sm = acs.Tax_Sm,
                        Prof_Sm = acs.Prof_Sm,
                        Military_Sm = acs.Military_Sm,
                        TotalDeduct_Sm = (acs.Tax_Sm + acs.Prof_Sm + acs.Military_Sm),
                    }).ToList();
                ReportDataSource report = new ReportDataSource("dsTaxes", recorcds);
                e.DataSources.Add(report);
            }
        }

    }
}
