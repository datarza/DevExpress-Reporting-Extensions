
using DevExpressReportingExtensions.Extensions;

using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.DecorationHelpers.BaseClasses
{
    public abstract class BaseDetailReportHelper : BaseMasterDetailReportHelper
    {
        public DetailReportBand ContainerBand { get; protected set; }

        protected BaseDetailReportHelper(XtraReport report, string dataMember)
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

            result.DataSource = this.Report.DataSource;
            result.InitializeDataMember(this.Report.JoinWithDataMember(dataMember));

            if (this.Report is DetailReportBand)
            {
                result.Level = ((DetailReportBand)this.Report).Level + 1;
            }

            this.Report.Bands.Add(result);

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
