using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RPR_SalBalance
    {
        public string NameMonth { get; set; }   //Дата
        public string PersCard_TIN { get; set; }   //ИНН
        public string PersCard_LName { get; set; } //Фамилия
        public string PersCard_FName { get; set; } //Имя
        public string PersCard_MName { get; set; } //Отчество
        public decimal SalBalance_SmByFirm { get; set; }   //Сальдо на начало месяца по предприятию
        public decimal SalBalance_SmByCard { get; set; }   //Сальдо на начало месяца по работнику
    }
}
