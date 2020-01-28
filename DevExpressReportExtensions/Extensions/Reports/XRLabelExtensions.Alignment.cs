using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace myClippit.DevExpress.Report.Extensions
{
    public static partial class XRLabelExtensions
    {
        public static XRLabel SetAlignment(this XRLabel control,
            TextAlignment alignment)
        {
            int h = 0;
            if (alignment == TextAlignment.BottomLeft
                || alignment == TextAlignment.MiddleLeft
                || alignment == TextAlignment.TopLeft)
            {
                h = -1;
            }
            else if (alignment == TextAlignment.BottomRight
                || alignment == TextAlignment.MiddleRight
                || alignment == TextAlignment.TopRight)
            {
                h = 1;
            }

            int v = 0;
            var baseAlignment = control.GetEffectiveTextAlignment();
            if (baseAlignment == TextAlignment.BottomLeft
                || baseAlignment == TextAlignment.BottomCenter
                || baseAlignment == TextAlignment.BottomJustify
                || baseAlignment == TextAlignment.BottomRight)
            {
                v = -1;
            }
            else if (baseAlignment == TextAlignment.TopLeft
                || baseAlignment == TextAlignment.TopCenter
                || baseAlignment == TextAlignment.TopJustify
                || baseAlignment == TextAlignment.TopRight)
            {
                v = 1;
            }

            control.TextAlignment = CalculateTextAlignment(h, v);

            return control;
        }

        private static TextAlignment CalculateTextAlignment(int h, int v)
        {
            if (h > 0 && v > 0)
            {
                return TextAlignment.TopRight;
            }
            else if (h < 0 && v > 0)
            {
                return TextAlignment.TopLeft;
            }
            else if (h < 0 && v < 0)
            {
                return TextAlignment.BottomLeft;
            }
            else if (h > 0 && v < 0)
            {
                return TextAlignment.BottomRight;
            }
            else if (h > 0 && v == 0)
            {
                return TextAlignment.MiddleRight;
            }
            else if (h < 0 && v == 0)
            {
                return TextAlignment.MiddleLeft;
            }
            else if (h == 0 && v > 0)
            {
                return TextAlignment.TopCenter;
            }
            else if (h == 0 && v < 0)
            {
                return TextAlignment.BottomCenter;
            }
            else
            {
                return TextAlignment.MiddleCenter;
            }
        }

    }
}