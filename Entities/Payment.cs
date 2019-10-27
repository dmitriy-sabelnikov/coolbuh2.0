using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Payment
    {
        public int Payment_Id { get; set; }
        public int Payment_PersCard_Id { get; set; }
        public DateTime Payment_Date { get; set; }
        public int Payment_Type { get; set; }
        public decimal Payment_Amt { get; set; }
        public decimal Payment_Price { get; set; }
        public decimal Payment_Sm { get; set; }
    }
}
