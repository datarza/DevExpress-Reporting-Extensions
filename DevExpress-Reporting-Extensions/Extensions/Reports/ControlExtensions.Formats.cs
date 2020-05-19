using System;

using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Extensions
{
    public static partial class ControlExtensions
    {
        public static void SetFormat(this XRControl control,
            string formatString)
        {
            if (formatString == null)
            {
                throw new ArgumentNullException(nameof(formatString));
            }

            var binding = control.GetTextBinding();
            if (binding != null)
            {
                binding.FormatString = formatString;

                binding = control.GetBookmarkBinding();
                if (binding != null)
                {
                    binding.FormatString = formatString;
                }
            }
        }

        public static void SetFormat(this XRControl control,
            string formatString,
            BorderSide? border,
            TextAlignment? alignment)
        {
            if (!string.IsNullOrWhiteSpace(formatString))
            {
                control.SetFormat(formatString);
            }

            if (border.HasValue)
            {
                control.SetBorder(border.Value);
            }

            if (alignment.HasValue)
            {
                control.SetAlignment(alignment.Value);
            }
        }

        public static void SetFormatDate(this XRControl control,
            string formatString = null,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            control.SetFormat(
                formatString ?? ReportConstants.FormatStrings.Date,
                border,
                alignment ?? TextAlignment.MiddleCenter);
        }

        public static void SetFormatDateTime(this XRControl control,
            string formatString = null,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            control.SetFormat(
                formatString ?? ReportConstants.FormatStrings.DateTime,
                border,
                alignment ?? TextAlignment.MiddleCenter);
        }

        public static void SetFormatCount(this XRControl control,
            string formatString = null,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            control.SetFormat(
                formatString ?? ReportConstants.FormatStrings.Count,
                border,
                alignment ?? TextAlignment.MiddleLeft);
        }

        public static void SetFormatNumber(this XRControl control,
            string formatString = null,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            control.SetFormat(
                formatString ?? ReportConstants.FormatStrings.Number,
                border,
                alignment ?? TextAlignment.MiddleRight);
        }

        public static void SetFormatMoney(this XRControl control,
            string formatString = null,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            control.SetFormat(
                formatString ?? ReportConstants.FormatStrings.Money,
                border,
                alignment ?? TextAlignment.MiddleRight);
        }

        public static void SetFormatPercent(this XRControl control,
            string formatString = null,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            control.SetFormat(
                formatString ?? ReportConstants.FormatStrings.Percent,
                border,
                alignment ?? TextAlignment.MiddleRight);
        }

    }
}