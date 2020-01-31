using myClippit.DevExpress.Report.DecorationHelpers;

using DevExpress.XtraReports.UI;

namespace myClippit.DevExpress.Report.Extensions
{
    public static partial class DecorationExtensions
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