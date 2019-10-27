using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ExportUST6
    {
        public int PERIOD_M { get; set; }
        public int PERIOD_Y { get; set; }
        public int ROWNUM { get; set; }
        public int UKR_GROMAD { get; set; }
        public int ST { get; set; }
        public string NUMIDENT { get; set; }
        public string LN { get; set; }
        public string NM { get; set; }
        public string FTN { get; set; }
        public int ZO { get; set; }
        public int PAY_TP { get; set; }
        public int PAY_MNTH { get; set; }
        public int PAY_YEAR { get; set; }
        public int KD_NP { get; set; }
        public int KD_NZP { get; set; }
        public int KD_PTV { get; set; }
        public int KD_VP { get; set; }
        public decimal SUM_TOTAL { get; set; }
        public decimal SUM_MAX { get; set; }
        public decimal SUM_DIFF { get; set; }
        public decimal SUM_INS { get; set; }
        public decimal SUM_NARAH { get; set; }
        public int OTK { get; set; }
        public int EXP { get; set; }
        public int NRC { get; set; }
        public int NRM { get; set; }
    }
}
