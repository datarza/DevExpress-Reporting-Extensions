using System.Linq;

using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Helpers.BaseClasses
{
    public abstract class BaseGroupFooterHelper : BaseMasterDetailReportHelper
    {
        public GroupFooterBand ContainerBand { get; protected set; }

        protected BaseGroupFooterHelper(XtraReport report, XtraReportBase detailReport)
            : base(report, detailReport)
        {
            this.ContainerBand = this.CreateContainerBand();
        }

        protected virtual GroupFooterBand CreateContainerBand()
        {
            var result = new GroupFooterBand
            {
                KeepTogether = true,
                HeightF = 0F,
                GroupUnion = GroupFooterUnion.WithLastDetail,
                RepeatEveryPage = false,
                Level = this.BaseReport.Bands.OfType<GroupFooterBand>().Count(),
            };

            this.BaseReport.Bands.Add(result);

            return result;
        }

    }
}
