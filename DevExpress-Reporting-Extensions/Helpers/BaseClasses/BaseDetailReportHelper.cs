
using DevExpress.XtraReports.UI;

using DevExpressReportingExtensions.Reports;

namespace DevExpressReportingExtensions.Helpers.BaseClasses
{
    public abstract class BaseDetailReportHelper : BaseMasterDetailReportHelper
    {
        public DetailReportBand ContainerBand { get; protected set; }

        protected BaseDetailReportHelper(XtraReport report, string dataMember = null)
            : base(report)
        {
            this.CreateDetailBandInRootReportIfNotExist();
            this.ContainerBand = this.CreateContainerBand(dataMember);
        }

        private void CreateDetailBandInRootReportIfNotExist()
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

        protected virtual DetailReportBand CreateContainerBand(string dataMember)
        {
            var result = new DetailReportBand
            {
                HeightF = 0F
            };

            result.DataSource = this.BaseReport.DataSource;
            result.InitializeDataMember(this.BaseReport.JoinWithDataMember(dataMember));

            if (this.BaseReport is DetailReportBand)
            {
                result.Level = ((DetailReportBand)this.BaseReport).Level + 1;
            }

            this.BaseReport.Bands.Add(result);

            return result;
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
