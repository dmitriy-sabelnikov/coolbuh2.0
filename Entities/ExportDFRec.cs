using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ExportDFRec
    {
        public int NP { get; set; }
        public int PERIOD { get; set; }
        public int RIK { get; set; }
        public string KOD { get; set; }
        public int TYP { get; set; }
        public string TIN { get; set; }
        public decimal S_NAR { get; set; }
        public decimal S_DOX { get; set; }
        public decimal S_TAXN { get; set; }
        public decimal S_TAXP { get; set; }
        public int OZN_DOX { get; set; }
        public DateTime D_PRIYN { get; set; }
        public DateTime D_ZVILN { get; set; }
        public int OZN_PILG { get; set; }
        public int OZNAKA { get; set; }
    }
}
