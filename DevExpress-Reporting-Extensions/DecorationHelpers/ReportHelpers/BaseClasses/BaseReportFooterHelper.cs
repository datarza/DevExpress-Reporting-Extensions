
using DevExpressReportingExtensions.Extensions;

using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.DecorationHelpers.BaseClasses
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
            var result = this.Report.GetBandByType<ReportFooterBand>();
            if (result == null)
            {
                result = new ReportFooterBand()
                {
                    HeightF = 0F,
                };
                this.Report.Bands.Add(result);
            }
            return result;
        }

    }
}
