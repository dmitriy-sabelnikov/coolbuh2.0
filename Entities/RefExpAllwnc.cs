using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    //Справочник надбавок за стаж
    public class RefExpAllwnc
    {
        public int RefExpAllwnc_Id { get; set; }
        public string RefExpAllwnc_Cd { get; set; }    //Код
        public string RefExpAllwnc_Nm { get; set; }    //Наименование
        public int RefExpAllwnc_Year { get; set; }     //Год
        public decimal RefExpAllwnc_Mech { get; set; } //надбавка механикам
        public int RefExpAllwncMech_RefDep_Id { get; set; } //Условие применения для надбавки механикам. Подразделение
        public decimal RefExpAllwnc_Oth { get; set; }  //надбавка другим
        public int RefExpAllwnc_Flg { get; set; } //Флаг
    }
}
