using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RPR_PaymentStatement
    {
        public string PersCard_Name { get; set; }    //ФИО работника
        public string PersCard_TIN { get; set; }     //ИНН работника
        public int Payment_Type { get; set; }        //id выплаты
        public string Payment_TypeName { get; set; } //Наименование выплаты
        public decimal Payment_Amt { get; set; }     //Количество
        public decimal Payment_Price { get; set; }   //Цена
        public decimal Payment_Sm { get; set; }      //Общая сумма
    }
}
