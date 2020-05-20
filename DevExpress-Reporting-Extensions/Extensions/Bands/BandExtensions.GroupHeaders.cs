using System;

using DevExpressReportingExtensions.DecorationHelpers;

using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Extensions
{
    public static partial class BandExtensions
    {
        public static GroupHeaderHelper AddGroupHeaderFranchise(this XtraReport report,
            string fieldName,
            XRColumnSortOrder sortOrder = XRColumnSortOrder.Ascending)
        {
            var detailReport = report.GetLastDetailReport();
            return new GroupHeaderHelper(detailReport.AddGroupHeaderBand(fieldName, sortOrder));
        }

        public static GroupHeadersHelper AddHierarchicalGroupHeader(this XtraReport report,
            params string[] fieldNames)
        {
            return new GroupHeadersHelper(report, fieldNames);
        }

        public static GroupHeaderHelper AddGroupHeader(this XtraReportBase report,
            string fieldName,
            XRColumnSortOrder sortOrder = XRColumnSortOrder.Ascending)
        {
            return new GroupHeaderHelper(report.AddGroupHeaderBand(fieldName, sortOrder));
        }

        public static GroupHeaderHelper AddGroupHeader(this GroupHeaderBand band)
        {
            return new GroupHeaderHelper(band);
        }

        public static GroupHeaderHelper AddGroupHeader(this GroupHeaderBand band,
            string fieldName,
            XRColumnSortOrder sortOrder = XRColumnSortOrder.Ascending)
        {
            band.GroupFields.Add(new GroupField(fieldName, sortOrder));
            return new GroupHeaderHelper(band);
        }

    }
}
