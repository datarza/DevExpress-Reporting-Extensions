
using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Helpers.Base
{
    public abstract class BaseBandHelper<T> : BaseHelper 
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
