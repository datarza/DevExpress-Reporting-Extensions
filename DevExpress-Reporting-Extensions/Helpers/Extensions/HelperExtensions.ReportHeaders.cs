
using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Helpers
{
    public static partial class HelperExtensions
    {
        public static ReportHeaderHelper AddReportHeader(this XtraReport report,
            string title1,
            string title2)
        {
            return new ReportHeaderHelper(report, title1, title2);
        }

        public static ReportHeaderHelper AddReportHeader(this XtraReport report,
            string title1,
            string title2,
            string subTitle1)
        {
            return new ReportHeaderHelper(report, title1, title2, subTitle1);
        }

        public static ReportHeaderHelper AddReportHeader(this XtraReport report,
            string title1,
            string title2,
            string subTitle1,
            string subTitle2)
        {
            return new ReportHeaderHelper(report, title1, title2, subTitle1, subTitle2);
        }

    }
}