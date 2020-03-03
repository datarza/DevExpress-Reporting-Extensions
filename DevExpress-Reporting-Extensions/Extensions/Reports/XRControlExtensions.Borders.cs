using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Reports
{
    public static partial class XRControlExtensions
    {
        public static void SetBorder(this XRControl control, BorderSide border)
        {
            control.Borders = control.GetEffectiveBorders() | border;
        }

    }
}