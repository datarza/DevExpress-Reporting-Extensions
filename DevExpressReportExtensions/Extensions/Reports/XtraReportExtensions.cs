using System;
using System.Drawing.Printing;

using DevExpress.DataAccess.ObjectBinding;
using DevExpress.XtraReports.UI;

namespace myClippit.DevExpress.Report.Extensions
{
    public static partial class XtraReportExtensions
    {
        public static void InitializeStructure(this XtraReport report,
            bool? isLandscape = null,
            PaperKind? paper = null,
            Margins margins = null)
        {
            report.ReportUnit = ReportUnit.HundredthsOfAnInch;

            report.Landscape = isLandscape ?? ReportConstants.Page.IsLandscape;

            report.PaperKind = paper ?? ReportConstants.Page.Paper;

            report.Margins = margins ?? new Margins(
                ReportConstants.Page.HorizontalMargin, ReportConstants.Page.HorizontalMargin,
                ReportConstants.Page.VerticalMargin, ReportConstants.Page.VerticalMargin);

            report.ReportPrintOptions.DetailCountOnEmptyDataSource = 0;
        }
        
        public static void InitializeDataMember(this XtraReportBase report, string dataMember)
        {
            if (string.IsNullOrWhiteSpace(dataMember))
            {
                throw new ArgumentNullException(nameof(dataMember));
            }

            report.DataMember = dataMember;
        }

        public static ObjectDataSource InitializeDataSource(this XtraReportBase report,
            string dataMember = null)
        {
            var reportDataSource = new ObjectDataSource();
            if (!string.IsNullOrWhiteSpace(dataMember))
            {
                reportDataSource.DataMember = dataMember;
            }
            report.DataSource = reportDataSource;
            return reportDataSource;
        }

        public static string JoinWithDataMember(this XtraReportBase report, string dataMember)
        {
            return DataExtensions.JoinDataMembers(report.DataMember, dataMember);
        }

        public static T GetBandByType<T>(this XtraReportBase report) where T : Band
        {
            return report.Bands.GetBandByType(typeof(T)) as T;
        }

        public static int GetBandWidth(this XtraReport report)
        {
            int result = report.PageWidth;
            if (report.Margins != null)
            {
                result = result - report.Margins.Left - report.Margins.Right;
            }
            return result;
        }

    }
}