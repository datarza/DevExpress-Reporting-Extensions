
using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Helpers
{
    public static partial class HelperExtensions
    {
        public static DetailReportHelper AddMasterDetailReport(this XtraReport report,
            string dataMember)
        {
            return new DetailReportHelper(report, dataMember);
        }

        public static DetailReportHelper AddMasterDetailReport(this XtraReport report,
            string dataMember,
            string headerDataMember,
            string formatString = null)
        {
            return new DetailReportHelper(report, dataMember, headerDataMember, formatString);
        }

    }
}