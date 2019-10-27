using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class IncTax
    {
        public int IncTax_Id { get; set; }
        public int IncTax_PersCard_Id { get; set; }
        public DateTime IncTax_Date { get; set; }
        public decimal IncTax_Sm { get; set; }
    }
}
