
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Helpers
{
    public static partial class HelperExtensions
    {
        public static PageNumberHelper AddPageNumber(this XtraReport report)
        {
            return new PageNumberHelper(report);
        }

        public static PageNumberHelper AddPageNumber(this XtraReport report,
            TextAlignment alignment)
        {
            return new PageNumberHelper(report, alignment);
        }

        public static PageNumberHelper AddPageNumber(this XtraReport report,
            string formatString)
        {
            return new PageNumberHelper(report, null, formatString);
        }

        public static PageNumberHelper AddPageNumber(this XtraReport report,
            TextAlignment alignment,
            string formatString)
        {
            return new PageNumberHelper(report, alignment, formatString);
        }

    }
}