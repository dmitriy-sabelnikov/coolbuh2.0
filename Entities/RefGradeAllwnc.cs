using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RefGradeAllwnc
    {
        public int RefGradeAllwnc_Id { get; set; }
        public string RefGradeAllwnc_Cd { get; set; } //Код
        public string RefGradeAllwnc_Nm { get; set; } //Наименование
        public decimal RefGradeAllwnc_Pct { get; set; } //процент
        public int RefGradeAllwnc_Grade { get; set; } //Условие применения. Классность
        public int RefGradeAllwnc_RefDep_Id { get; set; } //Условие применения. Подразделение
        public int RefGradeAllwnc_Flg { get; set; } //Флаги
    }
}
