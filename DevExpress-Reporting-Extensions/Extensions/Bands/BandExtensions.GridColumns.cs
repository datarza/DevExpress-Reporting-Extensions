using DevExpressReportingExtensions.DecorationHelpers;

using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Extensions
{
    public static partial class BandExtensions
    {
        public static SimpleGridColumnHelper AddGridColumns(this XtraReportBase report)
        {
            return new SimpleGridColumnHelper(report.AddDetailBand());
        }

        public static SimpleGridColumnHelper AddGridColumns(this Band band)
        {
            return new SimpleGridColumnHelper(band);
        }
        
    }
}