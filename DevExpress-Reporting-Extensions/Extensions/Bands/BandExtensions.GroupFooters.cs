
using DevExpressReportingExtensions.DecorationHelpers;

using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Extensions
{
    public static partial class BandExtensions
    {
        public static SimpleGroupFooterHelper AddGroupFooterFranchise(this XtraReport report)
        {
            var detailReport = report.GetLastDetailReport();
            return new SimpleGroupFooterHelper(detailReport.AddGroupFooterBand());
        }

        public static SimpleGroupFooterHelper AddGroupFooterFranchise(this DetailReportBand report)
        {
            return new SimpleGroupFooterHelper(report.AddGroupFooterBand());
        }

        public static SimpleGroupFooterHelper AddGroupFooter(this XtraReportBase report)
        {
            return new SimpleGroupFooterHelper(report.AddGroupFooterBand());
        }

        public static SimpleGroupFooterHelper AddGroupFooter(this GroupFooterBand band)
        {
            return new SimpleGroupFooterHelper(band);
        }

        public static SimpleGroupFooterHelper AddGroupFooter(this ReportFooterBand band)
        {
            return new SimpleGroupFooterHelper(band);
        }

        public static SimpleGroupFooterHelper AddGroupFooter(this PageFooterBand band)
        {
            return new SimpleGroupFooterHelper(band);
        }

    }
}
