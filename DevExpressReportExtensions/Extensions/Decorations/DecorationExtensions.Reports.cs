using myClippit.DevExpress.Report.DecorationHelpers;

using DevExpress.XtraReports.UI;

namespace myClippit.DevExpress.Report.Extensions
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