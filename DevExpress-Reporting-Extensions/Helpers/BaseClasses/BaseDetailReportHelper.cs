using System;

using DevExpress.XtraReports.UI;

using DevExpressReportingExtensions.Reports;

namespace DevExpressReportingExtensions.Helpers.Bases
{
    public abstract class BaseDetailReportHelper : BaseMasterDetailBandHelper<DetailReportBand>
    {
        public string DataMember { get; protected set; }

        protected BaseDetailReportHelper(XtraReport report, string dataMember)
            : base(report)
        {
            this.DataMember = dataMember ?? throw new ArgumentNullException(nameof(dataMember));
            this.InitializeDataSource();
            this.CreateIfNotExistDetailBandInRootReport();
        }

        private void CreateIfNotExistDetailBandInRootReport()
        {
            var result = this.RootReport.GetBandByType<DetailBand>();
            if (result == null)
            {
                result = new DetailBand()
                {
                    HeightF = 0F,
                };
                this.RootReport.Bands.Add(result);
            }
        }

        protected override DetailReportBand CreateContainerBand()
        {
            var result = new DetailReportBand
            {
                HeightF = 0F
            };

            if (this.BaseReport is DetailReportBand)
            {
                result.Level = ((DetailReportBand)this.BaseReport).Level + 1;
            }

            this.BaseReport.Bands.Add(result);
            return result;
        }

        protected virtual void InitializeDataSource()
        {
            this.ContainerBand.DataSource = this.BaseReport.DataSource;
            this.ContainerBand.InitializeDataMember(this.BaseReport.JoinWithDataMember(this.DataMember));
        }

        protected virtual DetailBand CreateDetailContainer(XRControl control)
        {
            var result = this.ContainerBand.GetBandByType<DetailBand>();
            if (result == null)
            {
                result = new DetailBand()
                {
                    HeightF = 0F
                };
                this.ContainerBand.Bands.Add(result);
            }
            else
            {
                result.Controls.Clear();
                result.HeightF = 0F;
            }
            result.Controls.Add(control);
            return result;
        }

    }
}
