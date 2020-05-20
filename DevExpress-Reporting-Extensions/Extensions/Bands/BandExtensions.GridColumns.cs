using DevExpressReportingExtensions.DecorationHelpers;

using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Extensions
{
    public static partial class BandExtensions
    {
        public static GridColumnHelper AddGridColumns(this XtraReportBase report)
        {
            return new GridColumnHelper(report.AddDetailBand());
        }

        public static GridColumnHelper AddGridColumns(this Band band)
        {
            return new GridColumnHelper(band);
        }
        
    }
}