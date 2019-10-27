using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RefOthAllwnc
    {
        public int RefOthAllwnc_Id { get; set; }
        public string RefOthAllwnc_Cd { get; set; }   //Код
        public string RefOthAllwnc_Nm { get; set; }   //Наименование
        public decimal RefOthAllwnc_Pct { get; set; } //процент
        public int RefOthAllwnc_Flg { get; set; }     //Флаги
    }
}
