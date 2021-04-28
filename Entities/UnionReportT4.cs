using System;

namespace Entities
{
    public class UnionReportT4
    {
        public int UnionReportT4_Id { get; set; }
        // Ссылка на каталог
        public int UnionReportT4_CtId { get; set; }
        // Отчетный месяц
        public DateTime UnionReportT4_Date { get; set; }
        //Номер файла(1, 2, 3). Для экспорта
        public int UnionReportT4_ExportFile { get; set; }
        // Гражданство Украины(1 - да)
        public int UnionReportT4_ISUKR { get; set; }
        // ИНН
        public string UnionReportT4_TIN { get; set; }
        // Фамилия   
        public string UnionReportT4_LName { get; set; }
        // Имя             
        public string UnionReportT4_FName { get; set; }
        // Отчество        
        public string UnionReportT4_MName { get; set; }
        // Код основния для учета спецстажа        
        public string UnionReportT4_C_Pid { get; set; }
        // Период начало
        public int UnionReportT4_Start_Days { get; set; }
        // Период конец
        public int UnionReportT4_Stop_Days { get; set; }
        // Дни
        public int UnionReportT4_Days { get; set; }
        // Часы
        public int UnionReportT4_Hours { get; set; }
        // Минуты
        public int UnionReportT4_Minutes { get; set; }
        // Норма длительности работы для ее зачисления за полный месяц спецстажа, дни,
        public int UnionReportT4_DaysNorm { get; set; }
        // Норма длительности работы для ее зачисления за полный месяц спецстажа, часы
        public int UnionReportT4_HoursNorm { get; set; }
        // Норма длительности работы для ее зачисления за полный месяц спецстажа, минуты
        public int UnionReportT4_MinutesNorm { get; set; }
        // Номер приказа о проведении аттестации рабочего места
        public string UnionReportT4_Ord_Num { get; set; }
        // Дата приказа о проведении аттестации рабочего места
        public int UnionReportT4_Ord_Dat { get; set; }
        // Признак сезонности
        public int UnionReportT4_SSN { get; set; } 
    }
}
