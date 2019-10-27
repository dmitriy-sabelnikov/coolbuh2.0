using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class v_AddAccr : AddAccr
    {
        public string PersCard_TIN { get; set; }
        public string PersCard_FullName { get; set; }
        public string RefDep_Name { get; set; }
        public string AddAccr_RefTypeAddAccr_Nm { get; set; }
    }
}
