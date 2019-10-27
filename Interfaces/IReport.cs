using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Reporting.WinForms;

namespace Interfaces
{
    public interface IReport
    {
        string NameReport { get; }
        List<ReportDataSource> DataSources { get; }
        SubreportProcessingEventHandler SubreportProc { get; }
        ReportParameter[] Parameters { get; }

        bool StartReport();
    }
}
