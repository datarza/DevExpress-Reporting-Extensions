using System;

using DevExpress.XtraReports.UI;

namespace myClippit.DevExpress.Report.DecorationHelpers
{
    public sealed class PercentGroupCalculationHelper : BaseGroupCalculationHelper
    {
        private readonly string getNumerator;

        private readonly string getDenominator;

        private decimal numerator;

        private decimal denominator;

        public PercentGroupCalculationHelper(XRLabel label,
            string getNumerator,
            string getDenominator)
            : base(label)
        {
            this.getNumerator = getNumerator ?? throw new ArgumentNullException(nameof(getNumerator));
            this.getDenominator = getDenominator ?? throw new ArgumentNullException(nameof(getDenominator));
        }
 
        protected override void Reset()
        {
            this.numerator = 0;
            this.denominator = 0;
        }

        protected override void AddObject()
        {
            this.numerator += this.RootReport.GetCurrentColumnValue<decimal>(this.getNumerator);
            this.denominator += this.RootReport.GetCurrentColumnValue<decimal>(this.getDenominator);
        }

        protected override object GetResult()
        {
            if (this.denominator != 0)
            {
                return this.numerator / this.denominator;
            }
            else
            {
                return null;
            }
        }
    }
}
