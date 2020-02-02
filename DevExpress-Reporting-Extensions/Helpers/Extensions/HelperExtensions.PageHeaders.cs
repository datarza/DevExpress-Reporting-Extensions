using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Helpers
{
    public static partial class HelperExtensions
    {
        public static DefaultPageHeaderHelper AddPageHeader(this XtraReport report)
        {
            return new DefaultPageHeaderHelper(report);
        }

    }
}