
using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Helpers
{
    public static partial class HelperExtensions
    {
        public static GridHelper AddGrid(this XtraReport report)
        {
            return new GridHelper(report);
        }

        public static GridHelper AddGrid(this XtraReport report, XtraReportBase detailReport)
        {
            return new GridHelper(report, detailReport);
        }

        public static CombinedGridHelper AddCombinedGrid(this XtraReport report)
        {
            return new CombinedGridHelper(report);
        }

        public static CombinedGridHelper AddCombinedGrid(this XtraReport report, XtraReportBase detailReport)
        {
            return new CombinedGridHelper(report, detailReport);
        }

    }
}