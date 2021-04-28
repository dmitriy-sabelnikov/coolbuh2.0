using System;

namespace Entities
{
    public class UnionReportT1
    {
        // Идентификатор
        public int UnionReportT1_Id { get; set; }
        // Ссылка на каталог
        public int UnionReportT1_CtId { get; set; }
        // Отчетный период
        public DateTime UnionReportT1_Date { get; set; }
        //Номер файла(1, 2, 3). Для экспорта
        public int UnionReportT1_ExportFile { get; set; }
        // Гражданство Украины(1 - да)
        public int UnionReportT1_ISUKR { get; set; }
        // Пол(0-Ж, 1-М)
        public int UnionReportT1_SEX { get; set; }
        // ИНН
        public string UnionReportT1_TIN { get; set; }
        // Фамилия
        public string UnionReportT1_LName { get; set; }
        // Имя
        public string UnionReportT1_FName { get; set; }
        // Отчество
        public string UnionReportT1_MName { get; set; }
        //Код категории застрахованного лица
        public int UnionReportT1_Category_Cd { get; set; }
        //Код типа начислений
        public int UnionReportT1_Accr_Cd { get; set; }
        //Месяц, за который проводится начисление
        public int UnionReportT1_Month { get; set; }
        //Год, за который проводится начисление
        public int UnionReportT1_Year { get; set; }
        //Количество календарных дней временной нетрудоспособности
        public int UnionReportT1_DisabDays { get; set; }
        //Количество календарных дней без сохранения зарплаты
        public int UnionReportT1_NoSalDays { get; set; }
        //Количество дней пребывания в трудовых отношениях
        public int UnionReportT1_EmplDays { get; set; }
        //Количество дней календарных дней отпуска в связи с беремменостью и родами
        public int UnionReportT1_VocDays { get; set; }
        //Общая сумма начиселнной зарплаты/дохода(всего с начала отчетного месяца)
        public decimal UnionReportT1_TotalSm { get; set; }
        //Cумма начиселнной зарплаты/дохода в границах макс.величины, на которую начисляется взнос
        public decimal UnionReportT1_MaxSm { get; set; }
        //Сумма разницы между размером минимальной зарплаты и фактически начисленной зарплатой
        public decimal UnionReportT1_DiffSm { get; set; }
        // Cумма удержанного единого взноса
        public decimal UnionReportT1_WithHeldUSTSm { get; set; }
        // Cумма начисленного единого взноса
        public decimal UnionReportT1_AccrUSTSm { get; set; }
        // Признак наличия трудовой книжки(1 - да, 0 - нет)
        public int UnionReportT1_WB { get; set; }
        // Признак наличия спецстажа(1 - да, 0 - нет)
        public int UnionReportT1_SpecExp { get; set; }
        // Признак неполного рабочего времени(1 - да, 0 - нет)
        public int UnionReportT1_PWT { get; set; }
        // Признак нового рабочего места(1 - да, 0 - нет)
        public int UnionReportT1_NWP { get; set; }                           
    }
}
