using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Extensions
{
    public static partial class ControlExtensions
    {
        public static float GetMinPossibleTopPosition(this XRControl control)
        {
            float result = 0F;
            foreach (XRControl item in control.Controls)
            {
                float positionHeight = item.TopF + item.HeightF;
                if (positionHeight > result)
                {
                    result = positionHeight;
                }
            }
            return result;
        }

    }
}