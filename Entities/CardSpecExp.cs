using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CardSpecExp
    {
        public int CardSpecExp_Id { get; set; }
        public int CardSpecExp_PersCard_Id { get; set; } //Ссылка на карточку работника
        public DateTime CardSpecExp_PerBeg{ get; set; }  //Период начало
        public DateTime CardSpecExp_PerEnd { get; set; }  //Период конец
        public int CardSpecExp_RefSpecExp_Id { get; set; } //Тип спецстажа
    }
}
