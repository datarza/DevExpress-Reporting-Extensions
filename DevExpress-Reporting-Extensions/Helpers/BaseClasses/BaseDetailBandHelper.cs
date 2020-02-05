
using DevExpress.XtraReports.UI;

using DevExpressReportingExtensions.Reports;

namespace DevExpressReportingExtensions.Helpers.BaseClasses
{
    public abstract class BaseDetailBandHelper : BaseMasterDetailReportHelper
    {
        public DetailBand ContainerBand { get; protected set; }

        protected BaseDetailBandHelper(XtraReport report, XtraReportBase detailReport = null)
            : base(report, detailReport)
        {
            this.ContainerBand = this.CreateContainerBand();
        }

        protected virtual DetailBand CreateContainerBand()
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
            return result;
        }

    }
}
