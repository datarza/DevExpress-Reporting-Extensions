
using DevExpress.XtraReports.UI;

using DevExpressReportingExtensions.Reports;

namespace DevExpressReportingExtensions.Helpers.Bases
{
    public abstract class BasePageHeaderHelper : BaseBandHelper<PageHeaderBand>
    {
        protected BasePageHeaderHelper(XtraReport report)
            : base(report)
        {
        }

        protected override PageHeaderBand CreateContainerBand()
        {
            var result = this.RootReport.GetBandByType<PageHeaderBand>();
            if (result == null)
            {
                result = new PageHeaderBand()
                {
                    PrintOn = PrintOnPages.AllPages,
                    HeightF = 0F,
                };
                this.RootReport.Bands.Add(result);
            }
            return result;
        }

    }
}
