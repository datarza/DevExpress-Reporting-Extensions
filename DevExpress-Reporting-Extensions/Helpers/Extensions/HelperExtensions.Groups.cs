using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Helpers
{
    public static partial class HelperExtensions
    {
        public static GroupHeaderHelper AddGroupHeader(this XtraReport report,
            string dataMember)
        {
            return new GroupHeaderHelper(report, dataMember);
        }

        public static GroupHeaderHelper AddGroupHeader(this XtraReport report,
            string dataMember,
            XRColumnSortOrder sortOrder)
        {
            return new GroupHeaderHelper(report, dataMember, sortOrder);
        }

        public static GroupHeaderHelper AddGroupHeader(this XtraReport report,
            string dataMember,
            string formatString)
        {
            return new GroupHeaderHelper(report, dataMember, XRColumnSortOrder.Ascending, formatString);
        }

        public static GroupHeaderHelper AddGroupHeader(this XtraReport report,
            string dataMember,
            XRColumnSortOrder sortOrder,
            string formatString)
        {
            return new GroupHeaderHelper(report, dataMember, sortOrder, formatString);
        }

        public static GroupFooterHelper AddGroupFooter(this XtraReport report)
        {
            return new GroupFooterHelper(report);
        }

    }
}