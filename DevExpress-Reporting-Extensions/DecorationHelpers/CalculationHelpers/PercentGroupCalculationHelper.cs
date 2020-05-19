using System;

using DevExpressReportingExtensions.DecorationHelpers.BaseClasses;

using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.DecorationHelpers
{
    internal sealed class PercentGroupCalculationHelper : BaseGroupCalculationHelper
    {
        private readonly string numeratorColumnName;

        private readonly string denominatorColumnName;

        private decimal numeratorSumValues;

        private decimal denominatorSumValues;

        public PercentGroupCalculationHelper(XRLabel label,
            string numeratorColumnName,
            string denominatorColumnName)
            : base(label)
        {
            this.numeratorColumnName = numeratorColumnName ?? throw new ArgumentNullException(nameof(numeratorColumnName));
            this.denominatorColumnName = denominatorColumnName ?? throw new ArgumentNullException(nameof(denominatorColumnName));
        }
 
        protected override void Reset()
        {
            this.numeratorSumValues = 0;
            this.denominatorSumValues = 0;
        }

        protected override void AddObject()
        {
            this.numeratorSumValues += this.RootReport.GetCurrentColumnValue<decimal>(this.numeratorColumnName);
            this.denominatorSumValues += this.RootReport.GetCurrentColumnValue<decimal>(this.denominatorColumnName);
        }

        protected override object GetResult()
        {
            if (this.denominatorSumValues != 0)
            {
                return this.numeratorSumValues / this.denominatorSumValues;
            }
            else
            {
                return null;
            }
        }
    }
}
