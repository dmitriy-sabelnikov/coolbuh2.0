using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Child
    {
        public int Child_Id { get; set; }
        public int Child_PersCard_Id { get; set; }
        public DateTime Child_PerBeg { get; set; }
        public DateTime Child_PerEnd { get; set; }
        public int Child_Count { get; set; }
    }
}
