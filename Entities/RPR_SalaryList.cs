using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RPR_SalaryList
    {
        public int PersCard_Id { get; set; }
        public string PersCard_LName { get; set; } //Фамилия
        public string PersCard_FName { get; set; } //Имя
        public string PersCard_MName { get; set; } //Отчество
        public string PersCard_TIN { get; set; }   //ИНН
        public string Salary_DepName { get; set; }
        public int Salary_Days { get; set; }
        public decimal Salary_Hours { get; set; }
        public decimal SalBalance_BegMonthSm { get; set; }
        public decimal SalBalance_EndMonthSm { get; set; }
        public decimal Salary_BaseSm { get; set; }
        public decimal Salary_PensSm { get; set; }
        public decimal Salary_GradeSm { get; set; }
        public decimal Salary_ExpSm { get; set; }
        public decimal Salary_OthSm { get; set; }
        public decimal Salary_KTU { get; set; }
        public decimal Salary_KTUSm { get; set; }
        public decimal Salary_ResSm { get; set; }
        public decimal Tax_Sm { get; set; }
        public decimal Prof_Sm { get; set; }
        public decimal Military_Sm { get; set; }
        public decimal TotalDeduct_Sm { get; set; }
        public string NameMonth { get; set; }
    }
}
