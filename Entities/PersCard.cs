using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    //Личная карточка
    public class PersCard
    {
        public int PersCard_Id { get; set; }
        public string PersCard_LName { get; set; } //Фамилия
        public string PersCard_FName { get; set; } //Имя
        public string PersCard_MName { get; set; } //Отчество
        public string PersCard_TIN { get; set; }   //ИНН
        public int PersCard_Exp { get; set; }      //Стаж(excperience)
        public int PersCard_Grade { get; set; }    //Классность
        public DateTime PersCard_DOB { get; set; } //Дата рождения(date of birth)
        public DateTime PersCard_DOR { get; set; } //Дата поступления(date of receipt)
        public DateTime PersCard_DOD { get; set; } //Дата увольнения(date of dismissal)
        public DateTime PersCard_DOP { get; set; } //Дата выхода на пенсию (date of pens)
        public int PersCard_Sex { get; set; }      //Пол(0-Ж, 1-М)
    }
}
