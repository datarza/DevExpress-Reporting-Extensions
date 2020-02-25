using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Reports
{
    public static partial class XRLabelExtensions
    {
        internal static XRLabel AddZeroNullFormattingRule(this XRLabel control,
            string dataMember)
        {
            var rule = control.RootReport.AddZeroNullFormattingRule(dataMember);
            control.FormattingRules.Add(rule);
            return control;
        }

    }
}
