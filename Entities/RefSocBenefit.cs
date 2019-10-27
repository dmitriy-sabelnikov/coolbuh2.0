using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RefSocBenefit
    {
        public int RefSocBenefit_Id { get; set; }
        public DateTime RefSocBenefit_PerBeg { get; set; }
        public DateTime RefSocBenefit_PerEnd { get; set; }
        public decimal RefSocBenefit_Sm { get; set; }
        public decimal RefSocBenefit_LimSm { get; set; }
    }
}
