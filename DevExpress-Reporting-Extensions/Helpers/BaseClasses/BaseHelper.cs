using System;

using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Helpers.Bases
{
    public abstract class BaseHelper
    {
        protected XtraReport RootReport { get; private set; }

        protected BaseHelper(XtraReport report)
        {
            this.RootReport = report ?? throw new ArgumentNullException(nameof(report));
        }
    }
}
