
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Helpers
{
    public static partial class DecorationExtensions
    {
        public static DefaultPageNumberHelper AddPageNumber(this XtraReport report)
        {
            return new DefaultPageNumberHelper(report);
        }

        public static DefaultPageNumberHelper AddPageNumber(this XtraReport report,
            TextAlignment alignment)
        {
            return new DefaultPageNumberHelper(report, alignment);
        }

        public static DefaultPageNumberHelper AddPageNumber(this XtraReport report,
            string formatString)
        {
            return new DefaultPageNumberHelper(report, null, formatString);
        }

        public static DefaultPageNumberHelper AddPageNumber(this XtraReport report,
            TextAlignment alignment,
            string formatString)
        {
            return new DefaultPageNumberHelper(report, alignment, formatString);
        }
        
    }
}