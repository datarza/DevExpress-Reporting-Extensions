using System;

using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.DecorationHelpers.BaseClasses
{
    public abstract class BaseGroupHeaderBandHelper
    {
        protected XtraReport RootReport { get; private set; }

        protected XtraReportBase Report { get; private set; }

        public GroupHeaderBand ContainerBand { get; private set; }

        protected BaseGroupHeaderBandHelper(GroupHeaderBand band)
        {
            this.ContainerBand = band ?? throw new ArgumentNullException(nameof(band));
            this.Report = band.Report;
            this.RootReport = band.RootReport;
        }

    }

}
