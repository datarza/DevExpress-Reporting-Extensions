using DevExpressReportingExtensions.DecorationHelpers;

using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Extensions
{
    public static partial class DecorationExtensions
    {
        public static DetailReportHelper AddMasterDetailReport(this XtraReport report,
            string dataMember)
        {
            return new DetailReportHelper(report, dataMember);
        }

    }
}