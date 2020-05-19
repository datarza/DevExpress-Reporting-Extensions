
using DevExpressReportingExtensions.Extensions;

using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.DecorationHelpers.BaseClasses
{
    public abstract class BaseMasterDetailReportHelper : BaseReportHelper
    {
        protected XtraReportBase Report { get; private set; }
        
        protected BaseMasterDetailReportHelper(XtraReport report, XtraReportBase detailReport = null)
            : base(report)
        {
            this.Report = detailReport ?? report.GetLastDetailReport();
        }

    }
}
