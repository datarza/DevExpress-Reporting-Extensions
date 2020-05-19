using System;

using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.DecorationHelpers.BaseClasses
{
    public abstract class BaseReportHelper
    {
        protected XtraReport RootReport { get; private set; }

        protected BaseReportHelper(XtraReport report)
        {
            this.RootReport = report ?? throw new ArgumentNullException(nameof(report));
        }

    }
}
