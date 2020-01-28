using myClippit.DevExpress.Report.DecorationHelpers;

using DevExpress.XtraReports.UI;

namespace myClippit.DevExpress.Report.Extensions
{
    public static partial class DecorationExtensions
    {
        public static DefaultGroupHeaderHelper AddGroupHeader(this XtraReport report,
            string dataMember)
        {
            return new DefaultGroupHeaderHelper(report, dataMember);
        }

        public static DefaultGroupHeaderHelper AddGroupHeader(this XtraReport report,
            string dataMember,
            XRColumnSortOrder sortOrder)
        {
            return new DefaultGroupHeaderHelper(report, dataMember, sortOrder);
        }

        public static DefaultGroupHeaderHelper AddGroupHeader(this XtraReport report,
            string dataMember,
            string formatString)
        {
            return new DefaultGroupHeaderHelper(report, dataMember, null, formatString);
        }

        public static DefaultGroupHeaderHelper AddGroupHeader(this XtraReport report,
            string dataMember,
            XRColumnSortOrder sortOrder,
            string formatString)
        {
            return new DefaultGroupHeaderHelper(report, dataMember, sortOrder, formatString);
        }

        public static DefaultGroupFooterHelper AddGroupFooter(this XtraReport report)
        {
            return new DefaultGroupFooterHelper(report);
        }

        public static DefaultGroupFooterHelper AddGroupFooter(this XtraReport report, XtraReportBase detailReport)
        {
            return new DefaultGroupFooterHelper(report, detailReport);
        }

    }
}