using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CardStatus
    {
        public int CardStatus_Id { get; set; }
        public int CardStatus_PersCard_Id { get; set; }
        public DateTime CardStatus_PerBeg { get; set; }
        public DateTime CardStatus_PerEnd { get; set; }
        public int CardStatus_Type { get; set; }
    }
}
