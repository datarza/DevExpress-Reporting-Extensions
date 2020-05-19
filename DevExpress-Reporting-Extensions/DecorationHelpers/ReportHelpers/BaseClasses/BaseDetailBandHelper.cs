using DevExpressReportingExtensions.Extensions;

using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.DecorationHelpers.BaseClasses
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
            var result = this.Report.GetBandByType<DetailBand>();
            if (result == null)
            {
                result = new DetailBand()
                {
                    HeightF = 0F,
                };
                this.Report.Bands.Add(result);
            }
            return result;
        }

    }
}
