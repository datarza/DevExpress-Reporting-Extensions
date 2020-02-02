using System;

using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Reports
{
    public static partial class XRLabelExtensions
    {
        internal static XRLabel SetFormat(this XRLabel control,
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
            return control;
        }

        internal static XRLabel SetFormat(this XRLabel control,
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

            return control;
        }

        internal static XRLabel SetFormatDate(this XRLabel control,
            string formatString = null,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            control.SetFormat(
                formatString ?? ReportConstants.FormatStrings.Date,
                border,
                alignment ?? TextAlignment.MiddleCenter);
            return control;
        }

        internal static XRLabel SetFormatDateTime(this XRLabel control,
            string formatString = null,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            control.SetFormat(
                formatString ?? ReportConstants.FormatStrings.DateTime,
                border,
                alignment ?? TextAlignment.MiddleCenter);
            return control;
        }

        internal static XRLabel SetFormatCount(this XRLabel control,
            string formatString = null,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            control.SetFormat(
                formatString ?? ReportConstants.FormatStrings.Count,
                border,
                alignment ?? TextAlignment.MiddleLeft);
            return control;
        }

        internal static XRLabel SetFormatNumber(this XRLabel control,
            string formatString = null,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            control.SetFormat(
                formatString ?? ReportConstants.FormatStrings.Number,
                border,
                alignment ?? TextAlignment.MiddleRight);
            return control;
        }

        internal static XRLabel SetFormatMoney(this XRLabel control,
            string formatString = null,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            control.SetFormat(
                formatString ?? ReportConstants.FormatStrings.Money,
                border,
                alignment ?? TextAlignment.MiddleRight);
            return control;
        }

        internal static XRLabel SetFormatPercent(this XRLabel control,
            string formatString = null,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            control.SetFormat(
                formatString ?? ReportConstants.FormatStrings.Percent,
                border,
                alignment ?? TextAlignment.MiddleRight);
            return control;
        }

    }
}