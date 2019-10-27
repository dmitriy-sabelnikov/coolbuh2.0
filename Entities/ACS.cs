using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ACS : PersCard
    {
        public int Disability_Attr { get; set; }
        public int CardStatus_Type { get; set; }
        public int Child_Count { get; set; }
        public int Salary_Days { get; set; }
        public decimal Salary_Hours { get; set; }
        public decimal Salary_BaseSm { get; set; }
        public decimal Salary_PensSm { get; set; }
        public decimal Salary_GradeSm { get; set; }
        public decimal Salary_ExpSm { get; set; }
        public decimal Salary_OthSm { get; set; }
        public decimal Salary_KTU { get; set; }
        public decimal Salary_KTUSm { get; set; }
        public decimal Salary_ResSm { get; set; }
        public int SickList_DaysEntprs { get; set; }
        public decimal SickList_SmEntprs { get; set; }
        public int SickList_DaysSocInsrnc { get; set; }
        public decimal SickList_SmSocInsrnc { get; set; }
        public int SickList_DaysTmpDis { get; set; }
        public decimal SickList_ResSm { get; set; }
        public int Vocation_Days { get; set; }
        public decimal Vocation_Sm { get; set; }
        public int LawContract_Days { get; set; }
        public decimal LawContract_Sm { get; set; }
        public decimal AddAccr_SmClc { get; set; }
        public decimal AddAccr_SmNoClc { get; set; }
        public decimal Tax_Sm { get; set; }
        public decimal SalBalance_BegMonthSm { get; set; }
        public decimal SalBalance_EndMonthSm { get; set; }
        public decimal Prof_Sm { get; set; }
        public decimal Military_Sm { get; set; }
        public decimal IncTax_Sm { get; set; }
        public decimal CashBox_Sm { get; set; }
        public decimal Excerpt_Sm { get; set; }
        public decimal list_Sm { get; set; }
        public decimal InKindPay_Sm { get; set; }
        public decimal AddPayment_Sm { get; set; } 
    }
}
