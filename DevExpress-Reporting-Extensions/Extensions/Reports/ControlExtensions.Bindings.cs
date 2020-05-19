using System;

using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Extensions
{
    public static partial class ControlExtensions
    {
        public static XRBinding AddTextBinding(this XRControl control,
            string dataMember,
            string formatString = null)
        {
            if (dataMember == null)
            {
                throw new ArgumentNullException(nameof(dataMember));
            }

            var binding = control.DataBindings[nameof(control.Text)];

            if (binding != null)
            {
                control.DataBindings.Remove(binding);
            }

            binding = new XRBinding(nameof(control.Text), null, dataMember);

            if (!string.IsNullOrWhiteSpace(formatString))
            {
                binding.FormatString = formatString;
            }

            control.DataBindings.Add(binding);

            return binding;
        }

        public static XRBinding AddBookmarkBinding(this XRControl control,
            string dataMember,
            string formatString = null)
        {
            if (dataMember == null)
            {
                throw new ArgumentNullException(nameof(dataMember));
            }

            var binding = control.DataBindings[nameof(control.Bookmark)];

            if (binding != null)
            {
                control.DataBindings.Remove(binding);
            }

            binding = new XRBinding(nameof(control.Bookmark), null, dataMember);

            if (!string.IsNullOrWhiteSpace(formatString))
            {
                binding.FormatString = formatString;
            }

            control.DataBindings.Add(binding);

            return binding;
        }

        public static XRBinding GetTextBinding(this XRControl control)
        {
            return control.DataBindings[nameof(control.Text)];
        }

        public static XRBinding GetBookmarkBinding(this XRControl control)
        {
            return control.DataBindings[nameof(control.Bookmark)];
        }

    }
}