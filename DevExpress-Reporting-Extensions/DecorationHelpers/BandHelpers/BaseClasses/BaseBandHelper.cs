using System;

using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.DecorationHelpers.BaseClasses
{
    public abstract class BaseBandHelper
    {
        protected XtraReport RootReport { get; private set; }

        protected XtraReportBase Report { get; private set; }

        public Band ContainerBand { get; private set; }

        protected BaseBandHelper(Band band)
        {
            this.ContainerBand = band ?? throw new ArgumentNullException(nameof(band));
            this.Report = band.Report;
            this.RootReport = band.RootReport;
        }

    }

}
