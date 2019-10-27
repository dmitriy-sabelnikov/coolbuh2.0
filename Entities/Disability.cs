using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Disability
    {
        public int Disability_Id { get; set; }
        public int Disability_PersCard_Id { get; set; }
        public DateTime Disability_PerBeg { get; set; }
        public DateTime Disability_PerEnd { get; set; }
        public int Disability_Attr { get; set; }
    }
}
