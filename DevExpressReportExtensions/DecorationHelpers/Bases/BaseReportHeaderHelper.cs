using System;

using myClippit.DevExpress.Report.Extensions;

using DevExpress.XtraReports.UI;

namespace myClippit.DevExpress.Report.DecorationHelpers
{
    public abstract class BaseReportHeaderHelper : BaseDetailReportHelper
    {
        public readonly ReportHeaderBand ContainerBand;

        protected BaseReportHeaderHelper(XtraReport report, XtraReportBase detailReport = null)
            : base(report, detailReport)
        {
            this.ContainerBand = this.CreateContainerBand();
        }

        protected virtual ReportHeaderBand CreateContainerBand()
        {
            var result = this.BaseReport.GetBandByType<ReportHeaderBand>();
            if (result == null)
            {
                result = new ReportHeaderBand()
                {
                    KeepTogether = true,
                    HeightF = 0F,
                    PageBreak = PageBreak.BeforeBandExceptFirstEntry
                };
                this.BaseReport.Bands.Add(result);
            }
            return result;
        }

    }
}
