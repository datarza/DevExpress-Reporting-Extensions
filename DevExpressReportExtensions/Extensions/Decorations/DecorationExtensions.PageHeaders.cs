using myClippit.DevExpress.Report.DecorationHelpers;

using DevExpress.XtraReports.UI;

namespace myClippit.DevExpress.Report.Extensions
{
    public static partial class DecorationExtensions
    {
        public static DefaultPageHeaderHelper AddPageHeader(this XtraReport report)
        {
            return new DefaultPageHeaderHelper(report);
        }

    }
}