using System;
using System.Linq;

using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.DecorationHelpers.BaseClasses
{
    public abstract class BaseGroupHeaderHelper : BaseMasterDetailReportHelper
    {
        public GroupHeaderBand ContainerBand { get; protected set; }

        protected BaseGroupHeaderHelper(XtraReport report, XtraReportBase detailReport,
            GroupField[] fields)
            : base(report, detailReport)
        {
            if (fields == null || fields.Length == 0)
            {
                throw new ArgumentNullException(nameof(fields));
            }

            this.ContainerBand = this.CreateContainerBand(fields);
        }

        protected virtual GroupHeaderBand CreateContainerBand(GroupField[] fields)
        {
            var result = new GroupHeaderBand
            {
                KeepTogether = true,
                HeightF = 0F,
                GroupUnion = GroupUnion.WithFirstDetail,
                RepeatEveryPage = true,
                Level = this.Report.Bands.OfType<GroupHeaderBand>().Count(),
            };

            result.GroupFields.AddRange(fields);

            this.Report.Bands.Add(result);

            return result;
        }

    }
}
