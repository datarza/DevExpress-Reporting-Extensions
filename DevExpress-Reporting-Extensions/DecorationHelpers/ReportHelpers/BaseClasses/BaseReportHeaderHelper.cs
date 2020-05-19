
using DevExpressReportingExtensions.Extensions;

using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.DecorationHelpers.BaseClasses
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
            var result = this.Report.GetBandByType<ReportHeaderBand>();
            if (result == null)
            {
                result = new ReportHeaderBand()
                {
                    HeightF = 0F,
                };
                this.Report.Bands.Add(result);
            }
            return result;
        }

    }
}
