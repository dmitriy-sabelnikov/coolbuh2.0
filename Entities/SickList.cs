using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class SickList
    {
        public int SickList_Id { get; set; }              //Id
        public int SickList_PersCard_Id { get; set; }     //Ссылка на карточку работника
        public int SickList_RefDep_Id { get; set; }       //Ссылка на справочник подразделений
        public DateTime SickList_Date { get; set; }       //Дата
        public int SickList_DaysEntprs { get; set; }      //Дни, оплачиваемые предприятием
        public decimal SickList_SmEntprs { get; set; }    //Сумма, оплачиваемая предприятием
        public int SickList_DaysSocInsrnc { get; set; }   //Дни, оплачиваемые соцстахом
        public decimal SickList_SmSocInsrnc { get; set; }    //Сумма, оплачиваемая соцстахом
        public DateTime SickList_PayDate { get; set; }    //Дата, за которую проводится начисления
        public int SickList_DaysTmpDis { get; set; }   //Дни временной нетрудоспособности
        public decimal SickList_ResSm { get; set; }    //Итоговая сумма
    }
}
