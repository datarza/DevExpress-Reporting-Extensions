
using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Helpers
{
    public static partial class HelperExtensions
    {
        public static DefaultReportHeaderHelper AddReportHeader(this XtraReport report, string headerText)
        {
            return new DefaultReportHeaderHelper(report, headerText);
        }

        public static DefaultReportHeaderHelper AddReportHeader(this XtraReport report, 
            XtraReportBase detailReport, 
            string headerText)
        {
            return new DefaultReportHeaderHelper(report, detailReport, headerText);
        }

    }
}