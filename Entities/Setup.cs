using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Entities
{
    public class SetupApp
    {
        public int SetupApp_Type { get; set; }
        public int SetupApp_ValueDigit { get; set; }
        public string SetupApp_ValueString { get; set; }
    }
}
