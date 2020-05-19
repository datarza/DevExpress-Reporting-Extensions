
using DevExpressReportingExtensions.Extensions;

using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.DecorationHelpers.BaseClasses
{
    public abstract class BasePageHeaderHelper : BaseReportHelper
    {
        public PageHeaderBand ContainerBand { get; protected set; }

        protected BasePageHeaderHelper(XtraReport report)
            : base(report)
        {
            this.ContainerBand = this.CreateContainerBand();
        }

        protected virtual PageHeaderBand CreateContainerBand()
        {
            var result = this.RootReport.GetBandByType<PageHeaderBand>();
            if (result == null)
            {
                result = new PageHeaderBand()
                {
                    HeightF = 0F,
                };
                this.RootReport.Bands.Add(result);
            }
            return result;
        }

    }
}
