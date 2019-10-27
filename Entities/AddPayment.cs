using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class AddPayment
    {
        public int AddPayment_Id { get; set; }
        public int AddPayment_PersCard_Id { get; set; }
        public DateTime AddPayment_Date { get; set; }
        public int AddPayment_TypeAddPayment_Id { get; set; }
        public decimal AddPayment_Sm { get; set; }
    }
}
