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
    public class PaymentStatement : IReport
    {
        public string NameReport { get; }
        public List<ReportDataSource> DataSources { get; }
        public ReportParameter[] Parameters { get; }
        public SubreportProcessingEventHandler SubreportProc { get; }

        private List<RPR_PaymentStatement> _paymentStatement = new List<RPR_PaymentStatement>();
        private List<RPR_AddPaymentStatement> _addPaymentStatement = new List<RPR_AddPaymentStatement>();

        private PersCardRepository _repoCard = new PersCardRepository(SetupProgram.Connection);
        private PaymentRepository _repoPayment = new PaymentRepository(SetupProgram.Connection);

        private RefTypeAddPaymentRepository _repoRefTypeAddPayment = new RefTypeAddPaymentRepository(SetupProgram.Connection);
        private AddPaymentRepository _repoAddPayment = new AddPaymentRepository(SetupProgram.Connection);

        public PaymentStatement(string name)
        {
            NameReport = name;
            Parameters = new ReportParameter[2];
            DataSources = new List<ReportDataSource>();
        }

        private bool LoadDataForPrint(DateTime dat, EnumPaymentStatement payStat, List<int> id_payment, List<int> id_addPayment, out string error)
        {
            error = string.Empty;
            List<PersCard> cards = _repoCard.GetAllCards(out error);
            if (error != string.Empty)
            {
                return false;
            }
            DateTime datBeg = new DateTime(dat.Year, dat.Month, 1);
            DateTime datEnd = new DateTime(dat.Year, dat.Month, DateTime.DaysInMonth(dat.Year, dat.Month));

            List<v_TypePayment> vTypePayment = TypePaymentHelper.GetTypePayment();
            List<Payment> payments = _repoPayment.GetPaymentByParams(0, 0, datBeg, datEnd, out error);
            if (error != string.Empty)
            {
                return false;
            }
            List<RefTypeAddPayment> typeAddPayments = _repoRefTypeAddPayment.GetAllTypeAddPayments(out error);
            if (error != string.Empty)
            {
                return false;
            }
            List<AddPayment> addPayments = _repoAddPayment.GetAddPaymentsByParams(0, 0, datBeg, datEnd, out error);
            if (error != string.Empty)
            {
                return false;
            }

            if (payStat == EnumPaymentStatement.AllPayment)
            {
                _paymentStatement =
                    (from card in cards
                     join payment in payments on card.PersCard_Id equals payment.Payment_PersCard_Id
                     join typePayment in vTypePayment on payment.Payment_Type equals typePayment.Id
                     where payment.Payment_Date.Year == dat.Year 
                        && payment.Payment_Date.Month == dat.Month
                     select new RPR_PaymentStatement
                     {
                         PersCard_Name = SalaryHelper.GetLastNameWithInit(card.PersCard_LName, card.PersCard_MName, card.PersCard_FName),
                         PersCard_TIN = card.PersCard_TIN,
                         Payment_Type = typePayment.Id,
                         Payment_TypeName = typePayment.Name,
                         Payment_Amt = payment.Payment_Amt,
                         Payment_Price = payment.Payment_Price,
                         Payment_Sm = payment.Payment_Sm
                     }).ToList();

                _addPaymentStatement =
                    (from card in cards
                     join addPayment in addPayments on card.PersCard_Id equals addPayment.AddPayment_PersCard_Id
                     join typeAddPayment in typeAddPayments on addPayment.AddPayment_TypeAddPayment_Id equals typeAddPayment.RefTypeAddPayment_Id
                     where addPayment.AddPayment_Date.Year == dat.Year
                        && addPayment.AddPayment_Date.Month == dat.Month
                     select new RPR_AddPaymentStatement
                     {
                         PersCard_Name = SalaryHelper.GetLastNameWithInit(card.PersCard_LName, card.PersCard_MName, card.PersCard_FName),
                         PersCard_TIN = card.PersCard_TIN,
                         AddPayment_Type = typeAddPayment.RefTypeAddPayment_Id,
                         AddPayment_TypeName = typeAddPayment.RefTypeAddPayment_Nm,
                         AddPayment_Sm = addPayment.AddPayment_Sm
                     }).ToList();
            }
            else
            {
                _paymentStatement =
                    (from card in cards
                     join payment in payments on card.PersCard_Id equals payment.Payment_PersCard_Id
                     join typePayment in vTypePayment on payment.Payment_Type equals typePayment.Id
                     where payment.Payment_Date.Year == dat.Year
                        && payment.Payment_Date.Month == dat.Month
                        && id_payment.Contains(typePayment.Id) 
                     select new RPR_PaymentStatement
                     {
                         PersCard_Name = SalaryHelper.GetLastNameWithInit(card.PersCard_LName, card.PersCard_MName, card.PersCard_FName),
                         PersCard_TIN = card.PersCard_TIN,
                         Payment_Type = typePayment.Id,
                         Payment_TypeName = typePayment.Name,
                         Payment_Amt = payment.Payment_Amt,
                         Payment_Price = payment.Payment_Price,
                         Payment_Sm = payment.Payment_Sm
                     }).ToList();

                _addPaymentStatement =
                    (from card in cards
                     join addPayment in addPayments on card.PersCard_Id equals addPayment.AddPayment_PersCard_Id
                     join typeAddPayment in typeAddPayments on addPayment.AddPayment_TypeAddPayment_Id equals typeAddPayment.RefTypeAddPayment_Id
                     where addPayment.AddPayment_Date.Year == dat.Year
                        && addPayment.AddPayment_Date.Month == dat.Month
                        && id_addPayment.Contains(typeAddPayment.RefTypeAddPayment_Id)
                     select new RPR_AddPaymentStatement
                     {
                         PersCard_Name = SalaryHelper.GetLastNameWithInit(card.PersCard_LName, card.PersCard_MName, card.PersCard_FName),
                         PersCard_TIN = card.PersCard_TIN,
                         AddPayment_Type = typeAddPayment.RefTypeAddPayment_Id,
                         AddPayment_TypeName = typeAddPayment.RefTypeAddPayment_Nm,
                         AddPayment_Sm = addPayment.AddPayment_Sm
                     }).ToList();
            }
            return true;
        }

        public bool StartReport()
        {
            fmPaymentStatement fmPayStat = new fmPaymentStatement();
            if (fmPayStat.ShowDialog() != DialogResult.OK)
                return false;
            string error = string.Empty;
            DateTime dat = fmPayStat.GetDateParam();
            EnumPaymentStatement enumPayStat = fmPayStat.GetFormParam();
            List<int> id_typePayment = fmPayStat.GetIdCheckedTypePayment();
            List<int> id_typeAddPayment = fmPayStat.GetIdCheckedTypeAddPayment();

            LoadDataForPrint(dat, enumPayStat, id_typePayment, id_typeAddPayment, out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }

            Parameters[0] = new ReportParameter("MonthName", SalaryHelper.GetMonthNameById(dat.Month, EnumCaseWorld.Nominative));
            Parameters[1] = new ReportParameter("SumTotalRep",
                (_paymentStatement.Sum(rec => rec.Payment_Sm) + _addPaymentStatement.Sum(rec => rec.AddPayment_Sm)).ToString("0.00"));

            ReportDataSource report = new ReportDataSource("dsPaymentStatement", _paymentStatement);
            ReportDataSource report2 = new ReportDataSource("dsAddPaymentStatement", _addPaymentStatement);
            DataSources.Add(report);
            DataSources.Add(report2);
            return true;
        }
    }
}
