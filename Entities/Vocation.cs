using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Vocation
    {
        public int Vocation_Id { get; set; }           //Id 
        public int Vocation_PersCard_Id { get; set; }  //Ссылка на карточку работника
        public int Vocation_RefDep_Id { get; set; }    //Ссылка на справочник подразделений
        public DateTime Vocation_Date { get; set; }    //Дата
        public int Vocation_Days { get; set; }         //Дни отпуска
        public decimal Vocation_Sm { get; set; }       //Сумма отпускных
        public DateTime Vocation_PayDate { get; set; } //Дата, за которую проводится начисления
    }
}
