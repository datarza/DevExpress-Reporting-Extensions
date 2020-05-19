using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Extensions
{
    public static partial class ControlExtensions
    {
        public static void SetBorder(this XRControl control, BorderSide border)
        {
            control.Borders = control.GetEffectiveBorders() | border;
        }

    }
}