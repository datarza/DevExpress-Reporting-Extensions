using System;

using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.DecorationHelpers.BaseClasses
{
    public abstract class BaseGroupCalculationHelper : BaseReportHelper
    {
        protected BaseGroupCalculationHelper(XRLabel label)
            : base(label.RootReport)
        {
            label.SummaryReset += this.SummaryReset;
            label.SummaryRowChanged += this.SummaryRowChanged;
            label.SummaryGetResult += this.SummaryGetResult;
        }

        protected abstract void Reset();

        protected abstract void AddObject();

        protected abstract object GetResult();

        private void SummaryReset(object sender, EventArgs e)
        {
            this.Reset();
        }

        private void SummaryRowChanged(object sender, EventArgs e)
        {
            this.AddObject();
        }

        private void SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = this.GetResult();
            e.Handled = true;
        }

    }
}
