using myClippit.DevExpress.Report.DecorationHelpers;

using DevExpress.XtraReports.UI;

namespace myClippit.DevExpress.Report.Extensions
{
    public static partial class DecorationExtensions
    {
        public static DefaultReportHeaderHelper AddReportHeader(this XtraReport report)
        {
            return new DefaultReportHeaderHelper(report);
        }

        public static DefaultReportHeaderHelper AddReportHeader(this XtraReport report, 
            XtraReportBase detailReport)
        {
            return new DefaultReportHeaderHelper(report, detailReport);
        }

    }
}