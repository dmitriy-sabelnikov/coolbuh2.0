using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RPR_AccrStatement
    {
        public string PersCard_Name { get; set; }     //ФИО Работника
        public int Month { get; set; }                //Месяц
        public int RefDep_Id { get; set; }
        public string NameDep { get; set; }           //Наименование подразделения
        public int Salary_Days { get; set; }          //Рабочие дни
        public decimal Salary_Hours { get; set; }     //Рабочие часы
        public decimal Salary_BaseSm { get; set; }    //Основная зп
        public decimal Salary_PensSm { get; set; }    //Доплата пенсионерам
        public decimal Salary_GradeSm { get; set; }   //Доплата за классность 
        public decimal Salary_ExpSm { get; set; }     //Доплата за опыт
        public decimal Salary_OthSm { get; set; }     //Другие доплаты
        public decimal Salary_KTU { get; set; }       //КТУ
        public decimal Salary_KTUSm { get; set; }     //КТУ сумма
        public decimal Salary_ResSm { get; set; }     //Итоговая сумма
        public int Vocation_Days { get; set; }         //Дни отпуска
        public decimal Vocation_Sm { get; set; }       //Сумма отпускных
        public int SickList_DaysTmpDis { get; set; }   //Дни временной нетрудоспособности
        public decimal SickList_ResSm { get; set; }    //Итоговая сумма
        public decimal AddAccr_SmClc { get; set; }     //Сумма доп начислиений (рассчитываются)
        public decimal AddAccr_SmNoClc { get; set; }   //Сумма доп начислиений (не рассчитываются)
        public decimal Accr_TotalSm { get; set; }      //Общая сумма начислений
    }
}
