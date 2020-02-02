
using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Helpers
{
    public static partial class DecorationExtensions
    {
        public static DefaultGridHelper AddGrid(this XtraReport report)
        {
            return new DefaultGridHelper(report);
        }

        public static DefaultGridHelper AddGrid(this XtraReport report, XtraReportBase detailReport)
        {
            return new DefaultGridHelper(report, detailReport);
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