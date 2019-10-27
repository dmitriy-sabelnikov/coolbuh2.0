using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class v_AddPayment : AddPayment
    {
        public string PersCard_TIN { get; set; }
        public string PersCard_FullName { get; set; }
        public string TypeAddPayment_Nm { get; set; }
    }
}
