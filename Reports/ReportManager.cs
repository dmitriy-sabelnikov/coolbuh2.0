using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Reports
{
    public class ReportManager
    {
        private string _file;
        private List<int> _id_card;
        public ReportManager(string FileName)
        {
            _file = FileName;
        }
        public void SetCheckedCard(List<int> persCard)
        {
            _id_card = persCard;
        }

        public IReport GetInstanceReport()
        {
            if (_file == "SalaryList.rdlc")
            {
                return new SalaryListReport(_file, _id_card);     
            }
            else
            if (_file == "SalBalance.rdlc")
            {
                return new SalBalanceReport(_file);
            }
            if (_file == "SalStatement.rdlc")
            {
                return new SalStatement(_file);
            }
            if (_file == "AccrStatement.rdlc")
            {
                return new AccrStatement(_file);
            }
            if (_file == "AccrConsolidate.rdlc")
            {
                return new AccrConsolidate(_file);
            }
            if (_file == "PaymentStatement.rdlc")
            {
                return new PaymentStatement(_file);
            }
            if (_file == "Consolidate.rdlc")
            {
                return new ConsolidateReport(_file);
            }
            return null;
        }

    }
}
