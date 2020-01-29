using System.Drawing.Printing;

using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace myClippit.DevExpress.Report
{
    public static class ReportConstants
    {
        public static class Page
        {
            public static bool IsLandscape = false;
            public static PaperKind Paper = XtraReport.DefaultPaperKind;
            public static int HorizontalMargin = 50;
            public static int VerticalMargin = 50;
        }

        public static class FormatStrings
        {
            public static string Date = "{0:d}";
            public static string DateTime = "{0:g}";
            public static string Count = "Total count: {0:D}";
            public static string Number = "{0:N}";
            public static string Money = "{0:C}";
            public static string Percent = "{0:P}";
        }

        public static class PageNumbers
        {
            public static TextAlignment Alignment = TextAlignment.TopRight;
            public static string FormatString = "Page {0} of {1}";
        }

    }
}
