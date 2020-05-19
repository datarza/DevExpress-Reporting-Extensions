using DevExpressReportingExtensions.DecorationHelpers;

using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Extensions
{
    public static partial class BandExtensions
    {
        public static SimpleGridHeaderHelper AddGridHeaders(this XtraReport report)
        {
            return new SimpleGridHeaderHelper(report.AddPageHeaderBand());
        }

        public static SimpleGridHeaderHelper AddGridHeaders(this Band band)
        {
            return new SimpleGridHeaderHelper(band);
        }

    }
}