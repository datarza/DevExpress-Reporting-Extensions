
using DevExpress.XtraReports.UI;

using DevExpressReportingExtensions.Reports;

namespace DevExpressReportingExtensions.Helpers.Base
{
    public abstract class BaseReportHeaderHelper : BaseMasterDetailBandHelper<ReportHeaderBand>
    {
        protected BaseReportHeaderHelper(XtraReport report, 
            XtraReportBase detailReport = null)
            : base(report, detailReport)
        {
        }
        protected override ReportHeaderBand CreateContainerBand()
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
