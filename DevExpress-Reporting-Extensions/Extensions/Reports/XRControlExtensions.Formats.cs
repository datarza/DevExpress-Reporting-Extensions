using System;

using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Reports
{
    public static partial class XRControlExtensions
    {
        internal static void SetFormat(this XRControl control,
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
            }
        }

        internal static void SetFormat(this XRControl control,
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

        internal static void SetFormatDate(this XRControl control,
            string formatString = null,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            control.SetFormat(
                formatString ?? ReportConstants.FormatStrings.Date,
                border,
                alignment ?? TextAlignment.MiddleCenter);
        }

        internal static void SetFormatDateTime(this XRControl control,
            string formatString = null,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            control.SetFormat(
                formatString ?? ReportConstants.FormatStrings.DateTime,
                border,
                alignment ?? TextAlignment.MiddleCenter);
        }

        internal static void SetFormatCount(this XRControl control,
            string formatString = null,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            control.SetFormat(
                formatString ?? ReportConstants.FormatStrings.Count,
                border,
                alignment ?? TextAlignment.MiddleLeft);
        }

        internal static void SetFormatNumber(this XRControl control,
            string formatString = null,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            control.SetFormat(
                formatString ?? ReportConstants.FormatStrings.Number,
                border,
                alignment ?? TextAlignment.MiddleRight);
        }

        internal static void SetFormatMoney(this XRControl control,
            string formatString = null,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            control.SetFormat(
                formatString ?? ReportConstants.FormatStrings.Money,
                border,
                alignment ?? TextAlignment.MiddleRight);
        }

        internal static void SetFormatPercent(this XRControl control,
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