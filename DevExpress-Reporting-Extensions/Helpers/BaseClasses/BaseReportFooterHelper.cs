
using DevExpress.XtraReports.UI;

using DevExpressReportingExtensions.Reports;

namespace DevExpressReportingExtensions.Helpers.BaseClasses
{
    public abstract class BaseReportFooterHelper : BaseMasterDetailReportHelper
    {
        public ReportFooterBand ContainerBand { get; protected set; }

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
                    HeightF = 0F,
                };
                this.BaseReport.Bands.Add(result);
            }
            return result;
        }

    }
}
