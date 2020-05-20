using DevExpressReportingExtensions.DecorationHelpers;

using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Extensions
{
    public static partial class BandExtensions
    {
        public static GridHelper AddGrid(this XtraReport report)
        {
            return new GridHelper(report);
        }

        public static GridHelper AddGrid(this XtraReport report, Band headersBand)
        {
            return new GridHelper(report, headersBand);
        }

        public static GridHelper AddGrid(this DetailReportBand report)
        {
            return new GridHelper(report.RootReport, report);
        }

        public static GridHelper AddGrid(this DetailReportBand report, Band headersBand)
        {
            return new GridHelper(report.RootReport, report, headersBand);
        }

    }
}