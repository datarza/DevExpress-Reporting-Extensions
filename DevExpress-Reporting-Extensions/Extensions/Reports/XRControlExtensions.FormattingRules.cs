using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Reports
{
    public static partial class XRControlExtensions
    {
        internal static void AddZeroNullFormattingRule(this XRControl control,
            string dataMember)
        {
            var rule = control.RootReport.AddZeroNullFormattingRule(dataMember);
            control.FormattingRules.Add(rule);
        }

    }
}
