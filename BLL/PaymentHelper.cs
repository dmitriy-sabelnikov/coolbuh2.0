using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PaymentHelper
    {
        public static decimal GetSmPaymentCash(decimal price, decimal amt)
        {
            return price * amt;
        }
    }
}
