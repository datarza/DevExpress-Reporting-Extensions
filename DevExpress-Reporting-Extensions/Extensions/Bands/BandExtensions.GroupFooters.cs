
using DevExpressReportingExtensions.DecorationHelpers;

using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Extensions
{
    public static partial class BandExtensions
    {
        public static GroupFooterHelper AddGroupFooterFranchise(this XtraReport report)
        {
            var detailReport = report.GetLastDetailReport();
            return new GroupFooterHelper(detailReport.AddGroupFooterBand());
        }

        public static GroupFooterHelper AddGroupFooterFranchise(this DetailReportBand report)
        {
            return new GroupFooterHelper(report.AddGroupFooterBand());
        }

        public static GroupFooterHelper AddGroupFooter(this XtraReportBase report)
        {
            return new GroupFooterHelper(report.AddGroupFooterBand());
        }

        public static GroupFooterHelper AddGroupFooter(this GroupFooterBand band)
        {
            return new GroupFooterHelper(band);
        }

        public static GroupFooterHelper AddGroupFooter(this ReportFooterBand band)
        {
            return new GroupFooterHelper(band);
        }

        public static GroupFooterHelper AddGroupFooter(this PageFooterBand band)
        {
            return new GroupFooterHelper(band);
        }

    }
}
