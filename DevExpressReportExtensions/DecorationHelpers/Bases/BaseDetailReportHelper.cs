using System;

using myClippit.DevExpress.Report.Extensions;

using DevExpress.XtraReports.UI;

namespace myClippit.DevExpress.Report.DecorationHelpers
{
    public abstract class BaseDetailReportHelper : BaseReportHelper
    {
        protected readonly XtraReportBase BaseReport;

        protected BaseDetailReportHelper(XtraReport report, XtraReportBase detailReport = null)
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
