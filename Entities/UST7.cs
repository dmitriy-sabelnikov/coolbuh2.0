using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UST7
    {
        public int UST7_Id { get; set; }
        public int UST7_USTCt_Id { get; set; } //Ссылка на каталог ЕСВ
        public int UST7_ISUKR { get; set; } //Гражданство Украины(1 - да)
        public string UST7_TIN { get; set; } //ИНН
        public string UST7_LName { get; set; } //Фамилия
        public string UST7_FName { get; set; } //Имя
        public string UST7_MName { get; set; } //Отчество
        public string UST7_C_Pid { get; set; } //Код основния для учета спецстажа
        public int UST7_Start_Days { get; set; } //Период начало
        public int UST7_Stop_Days { get; set; } //Период конец
        public int UST7_Days { get; set; } // Дни
        public int UST7_Hours { get; set; } // Часы
        public int UST7_Minutes { get; set; } //Минуты
        public int UST7_Norm { get; set; } // Норма длительности работы для ее зачисления за полный месяц спецстажа
        public string UST7_Ord_Num { get; set; } //Номер приказа о проведении аттестации рабочего места
        public int UST7_Ord_Dat { get; set; } //Дата приказа о проведении аттестации рабочего места
        public int UST7_SSN { get; set; } //Признак сезонности
    }
}
