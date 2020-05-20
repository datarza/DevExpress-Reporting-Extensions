using DevExpressReportingExtensions.DecorationHelpers;

using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Extensions
{
    public static partial class BandExtensions
    {
        public static PageNumberHelper AddPageNumbers(this XtraReport report)
        {
            return new PageNumberHelper(report.AddBottomMarginBand());
        }

        public static PageNumberHelper AddPageNumbers(this XtraReport report, Band runningBand)
        {
            return new PageNumberHelper(report.AddBottomMarginBand(), runningBand);
        }
        
        public static PageNumberHelper AddPageNumbers(this Band band)
        {
            return new PageNumberHelper(band);
        }

        public static PageNumberHelper AddPageNumbers(this Band band, Band runningBand)
        {
            return new PageNumberHelper(band, runningBand);
        }

    }
}