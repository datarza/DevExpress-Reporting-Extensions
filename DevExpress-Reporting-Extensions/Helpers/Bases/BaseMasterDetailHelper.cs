
using DevExpress.XtraReports.UI;

using DevExpressReportingExtensions.Reports;

namespace DevExpressReportingExtensions.Helpers.Base
{
    public abstract class BaseMasterDetailHelper : BaseHelper
    {
        protected XtraReportBase BaseReport { get; private set; }

        protected BaseMasterDetailHelper(XtraReport report,
            XtraReportBase detailReport = null)
            : base(report)
        {
            this.BaseReport = detailReport ?? this.GetDetailReport(report);
        }

        private XtraReportBase GetDetailReport(XtraReportBase report)
        {
            var repBand = report.GetBandByType<DetailReportBand>();
            if (repBand != null)
            {
                return this.GetDetailReport(repBand);
            }
            else
            {
                return report;
            }
        }

    }
}
