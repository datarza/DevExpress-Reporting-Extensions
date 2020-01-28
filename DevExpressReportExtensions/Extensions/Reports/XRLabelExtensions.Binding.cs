using System;

using DevExpress.XtraReports.UI;

namespace myClippit.DevExpress.Report.Extensions
{
    public static partial class XRLabelExtensions
    {
        public static XRBinding AddTextBinding(this XRLabel control,
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

        public static XRBinding GetTextBinding(this XRLabel control)
        {
            return control.DataBindings[nameof(control.Text)];
        }
               
    }
}