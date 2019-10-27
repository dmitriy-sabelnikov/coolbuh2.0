using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TaxRelief
    {
        public int TaxRelief_Id { get; set; }
        public int TaxRelief_PersCard_Id { get; set; }
        public DateTime TaxRelief_PerBeg { get; set; }
        public DateTime TaxRelief_PerEnd { get; set; }
        public decimal TaxRelief_Koef { get; set; }
    }
}
