using System;

using DevExpress.XtraReports.UI;

using DevExpressReportingExtensions.Helpers.Bases;

namespace DevExpressReportingExtensions.Helpers
{
    public sealed class PercentGroupCalculationHelper : BaseGroupCalculationHelper
    {
        private readonly string numeratorPropertyName;

        private readonly string denominatorPropertyName;

        private decimal numeratorValues;

        private decimal denominatorValues;

        public PercentGroupCalculationHelper(XRLabel label,
            string numeratorPropertyName,
            string denominatorPropertyName)
            : base(label)
        {
            this.numeratorPropertyName = numeratorPropertyName ?? throw new ArgumentNullException(nameof(numeratorPropertyName));
            this.denominatorPropertyName = denominatorPropertyName ?? throw new ArgumentNullException(nameof(denominatorPropertyName));
        }
 
        protected override void Reset()
        {
            this.numeratorValues = 0;
            this.denominatorValues = 0;
        }

        protected override void AddObject()
        {
            this.numeratorValues += this.RootReport.GetCurrentColumnValue<decimal>(this.numeratorPropertyName);
            this.denominatorValues += this.RootReport.GetCurrentColumnValue<decimal>(this.denominatorPropertyName);
        }

        protected override object GetResult()
        {
            if (this.denominatorValues != 0)
            {
                return this.numeratorValues / this.denominatorValues;
            }
            else
            {
                return null;
            }
        }
    }
}
