using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class LawContract
    {
        public int LawContract_Id { get; set; }
        public int LawContract_PersCard_Id { get; set; }  //Ссылка на карточку работника
        public int LawContract_RefDep_Id { get; set; }  //Ссылка на справочник подразделений
        public DateTime LawContract_Date { get; set; }  //Дата
        public int LawContract_Days { get; set; }       //Дни
        public decimal LawContract_Sm { get; set; }     //Сумма
        public DateTime LawContract_PayDate { get; set; } //Дата, за которую проводится начисления
    }
}
