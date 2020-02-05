
using DevExpress.XtraReports.UI;

using DevExpressReportingExtensions.Reports;

namespace DevExpressReportingExtensions.Helpers.BaseClasses
{
    public abstract class BaseReportHeaderHelper : BaseMasterDetailReportHelper
    {
        public ReportHeaderBand ContainerBand { get; protected set; }

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
                    HeightF = 0F,
                };
                this.BaseReport.Bands.Add(result);
            }
            return result;
        }

    }
}
