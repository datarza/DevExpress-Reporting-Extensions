
using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Helpers.Bases
{
    public abstract class BaseBandHelper<T> : BaseHelper, IBandHelper<T>
        where T : Band
    {
        public T ContainerBand { get; protected set; }

        protected BaseBandHelper(XtraReport report)
            : base(report)
        {
            this.ContainerBand = this.CreateContainerBand();
        }

        protected abstract T CreateContainerBand();
        
    }
}
