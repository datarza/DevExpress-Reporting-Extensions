using System;

using DevExpress.XtraReports.UI;

namespace myClippit.DevExpress.Report.DecorationHelpers
{
    public abstract class BaseReportHelper
    {
        protected readonly XtraReport RootReport;

        protected BaseReportHelper(XtraReport report)
        {
            this.RootReport = report ?? throw new ArgumentNullException(nameof(report));
        }
    }
}
