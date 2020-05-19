using DevExpressReportingExtensions.DecorationHelpers;

using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Extensions
{
    public static partial class BandExtensions
    {
        public static SimpleGridHelper AddGrid(this XtraReport report)
        {
            return new SimpleGridHelper(report);
        }

        public static SimpleGridHelper AddGrid(this XtraReport report, Band headersBand)
        {
            return new SimpleGridHelper(report, headersBand);
        }

        public static SimpleGridHelper AddGrid(this DetailReportBand report)
        {
            return new SimpleGridHelper(report.RootReport, report);
        }

        public static SimpleGridHelper AddGrid(this DetailReportBand report, Band headersBand)
        {
            return new SimpleGridHelper(report.RootReport, report, headersBand);
        }

    }
}