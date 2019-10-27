using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ExportUST7
    {
        public int PERIOD_M { get; set; }
        public int PERIOD_Y { get; set; }
        public int ROWNUM { get; set; }
        public int UKR_GROMAD { get; set; }
        public string NUMIDENT { get; set; }
        public string LN { get; set; }
        public string NM { get; set; }
        public string FTN { get; set; }
        public string C_PID { get; set; }
        public int START_DT { get; set; }
        public int STOP_DT { get; set; }
        public int DAYS { get; set; }
        public int HH { get; set; }
        public int MM { get; set; }
        public int NORMA { get; set; }
        public string NUM_NAK { get; set; }
        public int DT_NAK { get; set; }
        public int SEAZON { get; set; }
    }
}
