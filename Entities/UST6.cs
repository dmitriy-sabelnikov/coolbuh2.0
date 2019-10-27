using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UST6
    {
        public int UST6_Id { get; set; }  
        public int UST6_USTCt_Id { get; set; }     //Ссылка на каталог ЕСВ
        public int UST6_ISUKR { get; set; }        //Гражданство Украины(1 - да)
        public int UST6_SEX { get; set; }          //Пол(0-Ж, 1-М)
        public string UST6_TIN { get; set; }       //ИНН
        public string UST6_LName { get; set; }     //Фамилия
        public string UST6_FName { get; set; }     //Имя
        public string UST6_MName { get; set; }     //Отчество
        public int UST6_Category_Cd { get; set; }  //Код категории застрахованного лица
        public int UST6_Accr_Cd { get; set; }      //Код типа начислений
        public int UST6_Month { get; set; }        //Месяц, за который проводится начисление
        public int UST6_Year { get; set; }         //Год, за который проводится начисление
        public int UST6_DisabDays { get; set; }    //Количество календарных дней временной нетрудоспособности
        public int UST6_NoSalDays { get; set; }   //Количество календарных дней без сохранения зарплаты
        public int UST6_EmplDays { get; set; }    //Количество дней пребывания в трудовых отношениях
        public int UST6_VocDays { get; set; }    //Количество дней календарных дней отпуска в связи с беремменостью и родами
        public decimal UST6_TotalSm { get; set; } //Общая сумма начиселнной зарплаты/дохода(всего с начала отчетного месяца)
        public decimal UST6_MaxSm { get; set; }   //Cумма начиселнной зарплаты/дохода в границах макс.величины, на которую начисляется взнос
        public decimal UST6_DiffSm { get; set; }   //Сумма разницы между размером минимальной зарплаты и фактически начисленной зарплатой
        public decimal UST6_WithHeldUSTSm { get; set; }   //Cумма удержанного единого взноса
        public decimal UST6_AccrUSTSm { get; set; }  //Cумма начисленного единого взноса
        public int UST6_WB { get; set; }          //Признак наличия трудовой книжки(1 - да, 0 - нет)
        public int UST6_SpecExp { get; set; }     //Признак наличия спецстажа(1 - да, 0 - нет)
        public int UST6_PWT { get; set; }        //Признак неполного рабочего времени(1 - да, 0 - нет)
        public int UST6_NWP { get; set; }        //Признак нового рабочего места(1 - да, 0 - нет)
    }
}
