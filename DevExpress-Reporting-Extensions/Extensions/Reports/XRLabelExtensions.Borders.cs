using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Reports
{
    public static partial class XRLabelExtensions
    {
        public static XRLabel SetBorder(this XRLabel control, BorderSide border)
        {
            control.Borders = control.GetEffectiveBorders() | border;
            return control;
        }

    }
}