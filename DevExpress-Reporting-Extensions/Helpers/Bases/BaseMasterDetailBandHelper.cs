
using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Helpers.Base
{
    public abstract class BaseMasterDetailBandHelper<T> : BaseMasterDetailHelper
        where T : Band
    {
        public T ContainerBand { get; protected set; }

        protected BaseMasterDetailBandHelper(XtraReport report,
            XtraReportBase detailReport = null)
            : base(report, detailReport)
        {
            this.ContainerBand = this.CreateContainerBand();
        }

        protected abstract T CreateContainerBand();

    }
}
