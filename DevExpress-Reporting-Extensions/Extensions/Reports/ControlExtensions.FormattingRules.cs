using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Extensions
{
    public static partial class ControlExtensions
    {
        public static void AddZeroNullFormattingRule(this XRControl control,
            string dataMember)
        {
            var rule = control.RootReport.AddZeroNullFormattingRule(dataMember);
            control.FormattingRules.Add(rule);
        }

    }
}