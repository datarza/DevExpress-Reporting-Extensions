
using DevExpress.XtraReports.UI;

using DevExpressReportingExtensions.Reports;

namespace DevExpressReportingExtensions.Helpers.Bases
{
    public abstract class BaseReportFooterHelper : BaseMasterDetailBandHelper<ReportFooterBand>
    {
        protected BaseReportFooterHelper(XtraReport report, XtraReportBase detailReport = null)
            : base(report, detailReport)
        {
        }

        protected override ReportFooterBand CreateContainerBand()
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
