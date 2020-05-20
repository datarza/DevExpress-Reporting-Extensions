using DevExpressReportingExtensions.DecorationHelpers;

using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Extensions
{
    public static partial class BandExtensions
    {
        public static ReportHeaderHelper AddReportHeader(this XtraReportBase report)
        {
            return new ReportHeaderHelper(report.AddReportHeaderBand());
        }

        public static ReportHeaderHelper AddReportHeader(this XtraReportBase report,
            string mainTitle)
        {
            return new ReportHeaderHelper(report.AddReportHeaderBand(), mainTitle);
        }

        public static ReportHeaderHelper AddReportHeader(this XtraReportBase report,
            string mainTitle,
            string secondTitle)
        {
            return new ReportHeaderHelper(report.AddReportHeaderBand(), mainTitle, secondTitle);
        }
               
        public static ReportHeaderHelper AddReportHeader(this Band band)
        {
            return new ReportHeaderHelper(band);
        }

        public static ReportHeaderHelper AddReportHeader(this Band band,
            string mainTitle)
        {
            return new ReportHeaderHelper(band, mainTitle);
        }

        public static ReportHeaderHelper AddReportHeader(this Band band,
            string mainTitle,
            string secondTitle)
        {
            return new ReportHeaderHelper(band, mainTitle, secondTitle);
        }
        
    }
}