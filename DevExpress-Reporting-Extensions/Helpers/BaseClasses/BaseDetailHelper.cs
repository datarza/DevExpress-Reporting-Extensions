
using DevExpress.XtraReports.UI;

using DevExpressReportingExtensions.Reports;

namespace DevExpressReportingExtensions.Helpers.Bases
{
    public abstract class BaseDetailHelper : BaseMasterDetailBandHelper<DetailBand>
    {
        protected BaseDetailHelper(XtraReport report, XtraReportBase detailReport = null)
            : base(report, detailReport)
        {
        }

        protected override DetailBand CreateContainerBand()
        {
            var result = this.BaseReport.GetBandByType<DetailBand>();
            if (result == null)
            {
                result = new DetailBand()
                {
                    HeightF = 0F,
                };
                this.BaseReport.Bands.Add(result);
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
