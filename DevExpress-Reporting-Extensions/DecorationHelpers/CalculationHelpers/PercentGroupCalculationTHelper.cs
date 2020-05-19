using System;

using DevExpressReportingExtensions.DecorationHelpers.BaseClasses;

using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.DecorationHelpers
{
    internal sealed class PercentGroupCalculationHelper<T> : BaseGroupCalculationHelper
    {
        private readonly Func<T, decimal?> numeratorGetValue;

        private readonly Func<T, decimal?> denominatorGetValue;

        private decimal numeratorSumValues;

        private decimal denominatorSumValues;

        public PercentGroupCalculationHelper(XRLabel label,
            Func<T, decimal?> numeratorGetValue,
            Func<T, decimal?> denominatorGetValue)
            : base(label)
        {
            this.numeratorGetValue = numeratorGetValue ?? throw new ArgumentNullException(nameof(numeratorGetValue));
            this.denominatorGetValue = denominatorGetValue ?? throw new ArgumentNullException(nameof(denominatorGetValue));
        }

        protected override void Reset()
        {
            this.numeratorSumValues = 0;
            this.denominatorSumValues = 0;
        }

        protected override void AddObject()
        {
            var row = this.RootReport.GetCurrentRow();
            if (row is T)
            {
                T dataRow = (T)row;
                this.numeratorSumValues += this.numeratorGetValue.Invoke(dataRow) ?? 0;
                this.denominatorSumValues += this.denominatorGetValue.Invoke(dataRow) ?? 0;
            }
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
