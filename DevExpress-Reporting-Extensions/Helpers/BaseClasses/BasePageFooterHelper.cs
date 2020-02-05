
using DevExpress.XtraReports.UI;

using DevExpressReportingExtensions.Reports;

namespace DevExpressReportingExtensions.Helpers.BaseClasses
{
    public abstract class BasePageFooterHelper : BaseReportHelper
    {
        public PageFooterBand ContainerBand { get; protected set; }

        protected BasePageFooterHelper(XtraReport report)
            : base(report)
        {
            this.ContainerBand = this.CreateContainerBand();
        }

        protected virtual PageFooterBand CreateContainerBand()
        {
            var result = this.RootReport.GetBandByType<PageFooterBand>();
            if (result == null)
            {
                result = new PageFooterBand()
                {
                    HeightF = 0F,
                };
                this.RootReport.Bands.Add(result);
            }
            return result;
        }

    }
}
