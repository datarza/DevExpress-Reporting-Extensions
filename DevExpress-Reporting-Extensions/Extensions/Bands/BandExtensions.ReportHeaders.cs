using DevExpressReportingExtensions.DecorationHelpers;

using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Extensions
{
    public static partial class BandExtensions
    {
        public static SimpleReportHeaderHelper AddReportHeader(this XtraReportBase report)
        {
            return new SimpleReportHeaderHelper(report.AddReportHeaderBand());
        }

        public static SimpleReportHeaderHelper AddReportHeader(this XtraReportBase report,
            string mainTitle)
        {
            return new SimpleReportHeaderHelper(report.AddReportHeaderBand(), mainTitle);
        }

        public static SimpleReportHeaderHelper AddReportHeader(this XtraReportBase report,
            string mainTitle,
            string secondTitle)
        {
            return new SimpleReportHeaderHelper(report.AddReportHeaderBand(), mainTitle, secondTitle);
        }
               
        public static SimpleReportHeaderHelper AddReportHeader(this Band band)
        {
            return new SimpleReportHeaderHelper(band);
        }

        public static SimpleReportHeaderHelper AddReportHeader(this Band band,
            string mainTitle)
        {
            return new SimpleReportHeaderHelper(band, mainTitle);
        }

        public static SimpleReportHeaderHelper AddReportHeader(this Band band,
            string mainTitle,
            string secondTitle)
        {
            return new SimpleReportHeaderHelper(band, mainTitle, secondTitle);
        }
        
    }
}