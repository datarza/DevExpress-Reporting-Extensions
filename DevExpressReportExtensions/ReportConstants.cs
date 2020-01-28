using DevExpress.XtraPrinting;

using System.Drawing.Printing;

namespace myClippit.DevExpress.Report
{
    internal static class ReportConstants
    {
        internal static class Page
        {
            public const bool IsLandscape = true;
            public const PaperKind Paper = PaperKind.Letter;
            public const int HorizontalMargin = 50;
            public const int VerticalMargin = 50;
        }

        internal static class FormatStrings
        {
            public const string Date = "{0:d}";
            public const string DateTime = "{0:g}";
            public const string Count = "Total count: {0:D}";
            public const string Number = "{0:N}";
            public const string Money = "{0:C}";
            public const string Percent = "{0:P}";
        }

        internal static class PageNumbers
        {
            public const TextAlignment Alignment = TextAlignment.TopRight;
            public const string FormatString = "Page {0} of {1}";
        }

    }
}
