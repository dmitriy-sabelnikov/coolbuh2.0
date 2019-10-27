using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using EnumType;

namespace BLL
{
    public class TypePaymentHelper
    {
        public static List<v_TypePayment> GetTypePayment()
        {
            List<v_TypePayment> typePayment = new List<v_TypePayment>();
            typePayment.Add(new v_TypePayment { Id = (int)EnumTypePayment.CashBox, Name = "Каса" });
            typePayment.Add(new v_TypePayment { Id = (int)EnumTypePayment.Excerpt, Name = "Виписка" });
            typePayment.Add(new v_TypePayment { Id = (int)EnumTypePayment.List, Name = "Список" });
            typePayment.Add(new v_TypePayment { Id = (int)EnumTypePayment.InKindPay, Name = "Натуроплата" });
            return typePayment;
        }
    }
}
