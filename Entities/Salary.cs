using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Salary
    {
        public int Salary_Id { get; set; }
        public int Salary_PersCard_Id { get; set; }
        public int Salary_RefDep_Id { get; set; }
        public DateTime Salary_Date { get; set; }
        public int Salary_Days { get; set; }
        public decimal Salary_Hours { get; set; }
        public decimal Salary_BaseSm { get; set; }
        public int Salary_PensId { get; set; }
        public decimal Salary_PensPct { get; set; }
        public decimal Salary_PensSm { get; set; }
        public int Salary_ExpId { get; set; }
        public decimal Salary_ExpPct { get; set; }
        public decimal Salary_ExpSm { get; set; }
        public int Salary_GradeId { get; set; }
        public decimal Salary_GradePct { get; set; }
        public decimal Salary_GradeSm { get; set; }
        public int Salary_OthId { get; set; }
        public decimal Salary_OthPct { get; set; }
        public decimal Salary_OthSm { get; set; }
        public decimal Salary_KTU { get; set; }
        public decimal Salary_KTUSm { get; set; }
        public decimal Salary_ResSm { get; set; }
    }
}
