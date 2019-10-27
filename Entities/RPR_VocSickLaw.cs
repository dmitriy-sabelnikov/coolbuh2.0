using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RPR_VocSickLaw
    {
        public int PersCard_Id { get; set; }
        public string TypeName { get; set; }
        public string RefDep_Name { get; set; }
        public int Days { get; set; }
        public decimal Sm { get; set; }
    }
}
