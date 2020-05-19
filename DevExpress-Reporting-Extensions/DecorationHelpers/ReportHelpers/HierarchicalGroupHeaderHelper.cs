using System.Collections.Generic;
using System.Linq;

using DevExpressReportingExtensions.DecorationHelpers.BaseClasses;
using DevExpressReportingExtensions.Extensions;

using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.DecorationHelpers
{
    public class HierarchicalGroupHeaderHelper : BaseMasterDetailReportHelper
    {
        protected readonly IList<SimpleGroupHeaderHelper> headerHelpers;

        public IEnumerable<GroupHeaderBand> HeaderBands
        {
            get
            {
                return this.headerHelpers.Select(c => c.ContainerBand);
            }
        }

        public IEnumerable<XRLabel> ContainerControls
        {
            get
            {
                return this.headerHelpers.Select(c => c.ContainerControl);
            }
        }

        public HierarchicalGroupHeaderHelper(XtraReport report,
            params string[] fieldNames)
            : this(report, null, fieldNames)
        {
        }

        public HierarchicalGroupHeaderHelper(XtraReport report, XtraReportBase detailReport,
            params string[] fieldNames)
            : base(report, detailReport)
        {
            this.headerHelpers = new List<SimpleGroupHeaderHelper>(fieldNames.Length);
            if (fieldNames != null && fieldNames.Length > 0)
            {
                for (int i = fieldNames.Length - 1; i >= 0; i--)
                {
                    this.headerHelpers.Add(this.Report.AddGroupHeader(fieldNames[i]));
                }
                this.headerHelpers[0].AdjustBorderStyle();
                for (int i = 0; i < this.headerHelpers.Count - 1; i++)
                {
                    this.headerHelpers[i].AdjustBookmarks(this.headerHelpers[i + 1].ContainerControl);
                }
                this.headerHelpers[this.headerHelpers.Count - 1].AdjustBookmarks();
            }
        }

    }
}
