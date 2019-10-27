using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RPR_AddPaymentStatement
    {
        public string PersCard_Name { get; set; }    //ФИО работника
        public string PersCard_TIN { get; set; }     //ИНН работника
        public int AddPayment_Type { get; set; }        //id выплаты
        public string AddPayment_TypeName { get; set; } //Наименование выплаты
        public decimal AddPayment_Sm { get; set; }      //Общая сумма
    }
}
