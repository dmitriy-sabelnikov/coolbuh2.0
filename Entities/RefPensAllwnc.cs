using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RefPensAllwnc
    {
        public int RefPensAllwnc_Id { get; set; }
        public string RefPensAllwnc_Cd { get; set; }   //Код
        public string RefPensAllwnc_Nm { get; set; }   //Наименование
        public decimal RefPensAllwnc_Pct { get; set; } //процент
        public int RefPensAllwnc_Flg { get; set; }     //Флаги
    }
}
