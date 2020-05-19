using System;

using DevExpressReportingExtensions.DecorationHelpers;

using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Extensions
{
    public static partial class BandExtensions
    {
        public static SimpleGroupHeaderHelper AddGroupHeaderFranchise(this XtraReport report,
            string fieldName,
            XRColumnSortOrder sortOrder = XRColumnSortOrder.Ascending)
        {
            var detailReport = report.GetLastDetailReport();
            return new SimpleGroupHeaderHelper(detailReport.AddGroupHeaderBand(fieldName, sortOrder));
        }

        public static HierarchicalGroupHeaderHelper AddHierarchicalGroupHeader(this XtraReport report,
            params string[] fieldNames)
        {
            return new HierarchicalGroupHeaderHelper(report, fieldNames);
        }

        public static SimpleGroupHeaderHelper AddGroupHeader(this XtraReportBase report,
            string fieldName,
            XRColumnSortOrder sortOrder = XRColumnSortOrder.Ascending)
        {
            return new SimpleGroupHeaderHelper(report.AddGroupHeaderBand(fieldName, sortOrder));
        }

        public static SimpleGroupHeaderHelper AddGroupHeader(this GroupHeaderBand band)
        {
            return new SimpleGroupHeaderHelper(band);
        }

        public static SimpleGroupHeaderHelper AddGroupHeader(this GroupHeaderBand band,
            string fieldName,
            XRColumnSortOrder sortOrder = XRColumnSortOrder.Ascending)
        {
            band.GroupFields.Add(new GroupField(fieldName, sortOrder));
            return new SimpleGroupHeaderHelper(band);
        }

    }
}
