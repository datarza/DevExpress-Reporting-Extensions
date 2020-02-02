using System;

using DevExpressReportingExtensions.Reports;

using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Helpers
{
    public abstract class BaseReportFooterHelper : BaseDetailReportHelper
    {
        public readonly ReportFooterBand ContainerBand;

        protected BaseReportFooterHelper(XtraReport report, XtraReportBase detailReport = null)
            : base(report, detailReport)
        {
            this.ContainerBand = this.CreateContainerBand();
        }

        protected virtual ReportFooterBand CreateContainerBand()
        {
            var result = this.BaseReport.GetBandByType<ReportFooterBand>();
            if (result == null)
            {
                result = new ReportFooterBand()
                {
                    KeepTogether = true,
                    HeightF = 0F,
                    PageBreak = PageBreak.AfterBandExceptLastEntry
                };
                this.BaseReport.Bands.Add(result);
            }
            return result;
        }

    }
}
