
using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Helpers
{
    public static partial class DecorationExtensions
    {
        public static DefaultMasterReportHelper AddMasterDetailReport(this XtraReport report,
            string dataMember)
        {
            return new DefaultMasterReportHelper(report, dataMember);
        }

        public static DefaultMasterReportHelper AddMasterDetailReport(this XtraReport report,
            string dataMember,
            string headerDataMember,
            string formatString = null)
        {
            return new DefaultMasterReportHelper(report, dataMember, headerDataMember, formatString);
        }

    }
}