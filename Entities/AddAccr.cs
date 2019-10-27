using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class AddAccr
    {
        public int AddAccr_Id { get; set; }
        public int AddAccr_PersCard_Id { get; set; }
        public int AddAccr_RefDep_Id { get; set; }
        public int AddAccr_RefTypeAddAccr_Id { get; set; }
        public DateTime AddAccr_Date { get; set; }
        public decimal AddAccr_Sm { get; set; }
    }
}
