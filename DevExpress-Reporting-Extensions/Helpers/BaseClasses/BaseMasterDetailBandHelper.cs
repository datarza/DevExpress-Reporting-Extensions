
using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Helpers.Bases
{
    public abstract class BaseMasterDetailBandHelper<T> : BaseMasterDetailHelper, IBandHelper<T>
        where T : Band
    {
        public T ContainerBand { get; protected set; }

        protected BaseMasterDetailBandHelper(XtraReport report, XtraReportBase detailReport = null)
            : base(report, detailReport)
        {
            this.ContainerBand = this.CreateContainerBand();
        }

        protected abstract T CreateContainerBand();

    }
}
