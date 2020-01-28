using System;

using DevExpress.XtraReports.UI;

namespace myClippit.DevExpress.Report.DecorationHelpers
{
    public sealed class PercentGroupCalculationHelper<T> : BaseGroupCalculationHelper
    {
        private readonly Func<T, decimal?> getVariation;

        private readonly Func<T, decimal?> getDenominator;

        private decimal variation;

        private decimal denominator;

        public PercentGroupCalculationHelper(XRLabel label,
            Func<T, decimal?> getVariation,
            Func<T, decimal?> getDenominator)
            : base(label)
        {
            this.getVariation = getVariation ?? throw new ArgumentNullException(nameof(getVariation));
            this.getDenominator = getDenominator ?? throw new ArgumentNullException(nameof(getDenominator));
        }

        protected override void Reset()
        {
            this.variation = 0;
            this.denominator = 0;
        }

        protected override void AddObject()
        {
            var row = this.RootReport.GetCurrentRow();
            if (row is T)
            {
                T dataRow = (T)row;
                this.variation += this.getVariation.Invoke(dataRow) ?? 0;
                this.denominator += this.getDenominator.Invoke(dataRow) ?? 0;
            }
        }

        protected override object GetResult()
        {
            if (this.denominator != 0)
            {
                return this.variation / this.denominator;
            }
            else
            {
                return null;
            }
        }
    }
}
