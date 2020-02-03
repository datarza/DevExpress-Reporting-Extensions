
using DevExpress.XtraReports.UI;

using DevExpressReportingExtensions.Reports;

namespace DevExpressReportingExtensions.Helpers.Bases
{
    public abstract class BasePageFooterHelper : BaseBandHelper<PageFooterBand>
    {
        protected BasePageFooterHelper(XtraReport report)
            : base(report)
        {
        }

        protected override PageFooterBand CreateContainerBand()
        {
            var result = this.RootReport.GetBandByType<PageFooterBand>();
            if (result == null)
            {
                result = new PageFooterBand()
                {
                    PrintOn = PrintOnPages.AllPages,
                    HeightF = 0F,
                };
                this.RootReport.Bands.Add(result);
            }
            else
            {
                result.Controls.Clear();
                result.HeightF = 0F;
            }
            return result;
        }

    }
}
