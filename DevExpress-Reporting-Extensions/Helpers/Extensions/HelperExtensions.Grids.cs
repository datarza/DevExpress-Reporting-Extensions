
using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Helpers
{
    public static partial class HelperExtensions
    {
        public static GridCaptionsHelper AddGridCaptions(this XtraReport report)
        {
            return new GridCaptionsHelper(report);
        }

        public static GridCaptionsHelper AddGridCaptions(this XtraReport report, SubBand captionsBand)
        {
            return new GridCaptionsHelper(report, captionsBand);
        }

        public static GridColumnsHelper AddGridColumns(this XtraReport report)
        {
            return new GridColumnsHelper(report);
        }

        public static GridColumnsHelper AddGridColumns(this XtraReport report, XtraReportBase detailReport)
        {
            return new GridColumnsHelper(report, detailReport);
        }

        public static CombinedGridHelper AddCombinedGrid(this XtraReport report)
        {
            return new CombinedGridHelper(report);
        }

        public static CombinedGridHelper AddCombinedGrid(this XtraReport report, SubBand captionsBand)
        {
            return new CombinedGridHelper(report, captionsBand);
        }

        public static CombinedGridHelper AddCombinedGrid(this XtraReport report, XtraReportBase detailReport)
        {
            return new CombinedGridHelper(report, detailReport);
        }

        public static CombinedGridHelper AddCombinedGrid(this XtraReport report, SubBand captionsBand, XtraReportBase detailReport)
        {
            return new CombinedGridHelper(report, captionsBand, detailReport);
        }

    }
}