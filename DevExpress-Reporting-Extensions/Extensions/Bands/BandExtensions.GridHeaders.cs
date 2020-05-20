using DevExpressReportingExtensions.DecorationHelpers;

using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Extensions
{
    public static partial class BandExtensions
    {
        public static GridHeaderHelper AddGridHeaders(this XtraReport report)
        {
            return new GridHeaderHelper(report.AddPageHeaderBand());
        }

        public static GridHeaderHelper AddGridHeaders(this Band band)
        {
            return new GridHeaderHelper(band);
        }

    }
}