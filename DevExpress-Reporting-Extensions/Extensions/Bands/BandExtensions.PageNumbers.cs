using DevExpressReportingExtensions.DecorationHelpers;

using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Extensions
{
    public static partial class BandExtensions
    {
        public static SimplePageNumberHelper AddPageNumbers(this XtraReport report)
        {
            return new SimplePageNumberHelper(report.AddBottomMarginBand());
        }

        public static SimplePageNumberHelper AddPageNumbers(this XtraReport report, Band runningBand)
        {
            return new SimplePageNumberHelper(report.AddBottomMarginBand(), runningBand);
        }
        
        public static SimplePageNumberHelper AddPageNumbers(this Band band)
        {
            return new SimplePageNumberHelper(band);
        }

        public static SimplePageNumberHelper AddPageNumbers(this Band band, Band runningBand)
        {
            return new SimplePageNumberHelper(band, runningBand);
        }

    }
}