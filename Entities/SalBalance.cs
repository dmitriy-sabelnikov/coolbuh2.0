using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class SalBalance
    {
        public int SalBalance_Id { get; set; }
        public int SalBalance_PersCard_Id { get; set; } //Ссылка на карточку работника
        public DateTime SalBalance_Date { get; set; }   //Дата
        public decimal SalBalance_BegMonthSm { get; set; }   //Сальдо на начало месяца
        public decimal SalBalance_EndMonthSm { get; set; }   //Сальдо на Конец месяца
        public int SalBalance_Flg { get; set; } //Флаги
    }
}
