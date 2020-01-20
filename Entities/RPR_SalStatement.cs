using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RPR_SalStatement
    {
        public string NameMonth { get; set; }   //Дата
        public string PersCard_FullName { get; set; }        //Фамилия и инициалы
        public decimal SalBalance_BegSmByFirm { get; set; }   //Сальдо на начало месяца по предприятию
        public decimal SalBalance_BegSmByCard { get; set; }   //Сальдо на начало месяца по работнику
        public decimal Salary_BaseSm { get; set; }            //Основная зп
        public decimal Salary_PensSm { get; set; }            //Доплата пенсионерам
        public decimal Salary_GradeSm { get; set; }           //Доплата за классность 
        public decimal Salary_ExpSm { get; set; }             //Доплата за опыт
        public decimal Salary_OthSm { get; set; }             //Другие доплаты
        public decimal SickList_ResSm { get; set; }           //Сумма больничных
        public decimal Vocation_Sm { get; set; }              //Сумма отпускных
        public decimal LawContract_Sm { get; set; }           //Договора ГПХ
        public decimal AddAccr_SmClc { get; set; }            //Сумма доп начислиений (рассчитываются)
        public decimal AddAccr_SmNoClc { get; set; }          //Сумма доп начислиений (не рассчитываются)
        public decimal Accr_TotalSm { get; set; }             //Общая сумма начислений
        public decimal Tax_Sm { get; set; }                   //Подоходный налог
        public decimal IncTax_Sm { get; set; }                //Корректировка подоходного
        public decimal Prof_Sm { get; set; }                  //Проф взносы
        public decimal SalBalance_EndSmByFirm { get; set; }   //Сальдо на конец месяца по предприятию
        public decimal SalBalance_EndSmByCard { get; set; }   //Сальдо на конец месяца по работнику
        public decimal CashBox_Sm { get; set; }               //Касса 
        //public decimal Excerpt_Sm { get; set; }               //Виписка 
        //public decimal List_Sm { get; set; }                  //Список 
        //public decimal InKindPay_Sm { get; set; }             //Натуроплата 
        public decimal AddPayment_Sm { get; set; }            //Додаткові виплати 
        public decimal Military_Sm { get; set; }              //Военный сбор
        public decimal Payment_TotalSm { get; set; }          //Общая сумма выплат
    }
}
