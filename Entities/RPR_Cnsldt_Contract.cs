using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RPR_Cnsldt_Contract
    {
        public double ConstFromSm { get; set; }
        public double ConstUstSm { get; set; }
        public int ConstCuntWrk { get; set; }
        public double TmpFromSm { get; set; }
        public double TmpUstSm { get; set; }
        public int TmpCountWrk { get; set; }
        public double AssFromSm { get; set; }
        public double AssUstSm { get; set; }
        public int AssCountWrk { get; set; }
    }
}
