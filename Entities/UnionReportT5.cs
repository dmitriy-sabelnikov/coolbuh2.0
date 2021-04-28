using System;

namespace Entities
{
    public class UnionReportT5
    {
        public int UnionReportT5_Id { get; set; }
        //Ссылка на каталог
        public int UnionReportT5_CtId { get; set; }
        //Отчетный период
        public DateTime UnionReportT5_Date { get; set; }
        //Номер файла(1, 2, 3). Для экспорта
        public int UnionReportT5_ExportFile { get; set; }
        //Гражданство Украины(1 - да)
        public int UnionReportT5_ISUKR { get; set; }
        //ИНН
        public string UnionReportT5_TIN { get; set; }
        //Фамилия
        public string UnionReportT5_LName { get; set; }
        //Имя
        public string UnionReportT5_FName { get; set; }  
        // Отчество
        public string UnionReportT5_MName { get; set; }
        //Код категории застрахованного лица
        public int UnionReportT5_Category_Cd { get; set; }
        //Дата старта получения матпомощи
        public int UnionReportT5_MaterialAidStart { get; set; }
        //Дата окночания получения матпомощи
        public int UnionReportT5_MaterialAidEnd { get; set; }
        //Код типа начислений
        public int UnionReportT5_Accr_Cd { get; set; }
        //Месяц, за который проводится начисление
        public int UnionReportT5_Month { get; set; }
        // Год, за который проводится начисление
        public int UnionReportT5_Year { get; set; }
        //Общая сумма начиселнной матпомощи/компенсации/минимальной зп, установленной законодательством(всего с начала отчетного месяца)
        public decimal UnionReportT5_TotalSm { get; set; }
        // Cумма начиселенной матпомощи/компенсации/минимальной зп в границах макс.величины, на которую начисляется ЕСВ
        public decimal UnionReportT5_MaxSm { get; set; }
        //Cумма начисленного единого взноса
        public decimal UnionReportT1_AccrUSTSm { get; set; }
    }
}
