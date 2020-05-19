using System;
using System.Drawing;
using System.Drawing.Printing;

using DevExpress.DataAccess.ObjectBinding;
using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Extensions
{
    public static partial class ReportExtensions
    {
        public static void InitializeStructure(this XtraReport report, string title = null)
        {
            report.ReportUnit = ReportUnit.HundredthsOfAnInch;

            report.PaperKind = ReportConstants.Page.Paper;

            report.Margins = new Margins(
                ReportConstants.Page.HorizontalMargin, ReportConstants.Page.HorizontalMargin,
                ReportConstants.Page.VerticalMargin, ReportConstants.Page.VerticalMargin);

            report.ReportPrintOptions.DetailCountOnEmptyDataSource = 0;

            if (!string.IsNullOrWhiteSpace(title))
            {
                report.Bookmark = title;
            }
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
            var result = new ObjectDataSource();
            if (!string.IsNullOrWhiteSpace(dataMember))
            {
                result.DataMember = dataMember;
            }
            report.DataSource = result;
            return result;
        }

        public static string JoinWithDataMember(this XtraReportBase report, string dataMember)
        {
            if (string.IsNullOrWhiteSpace(dataMember))
            {
                return report.DataMember;
            }
            else if (string.IsNullOrWhiteSpace(report.DataMember))
            {
                return dataMember;
            }
            else
            {
                return $"{report.DataMember}.{dataMember}";
            }
        }
        
        public static FormattingRule AddZeroNullFormattingRule(this XtraReport report, string dataMember)
        {
            var result = new FormattingRule();
            report.FormattingRuleSheet.Add(result);
            result.Condition = $"[{report.JoinWithDataMember(dataMember)}] == 0";
            result.Formatting.ForeColor = Color.Transparent;
            return result;
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

        public static XtraReportBase GetLastDetailReport(this XtraReportBase report)
        {
            var repBand = report.GetBandByType<DetailReportBand>();
            if (repBand != null)
            {
                return ReportExtensions.GetLastDetailReport(repBand);
            }
            else
            {
                return report;
            }
        }

    }
}