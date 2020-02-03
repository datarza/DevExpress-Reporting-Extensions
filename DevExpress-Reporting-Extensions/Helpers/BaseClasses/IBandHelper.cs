using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Helpers.Bases
{
    interface IBandHelper<T> where T : Band
    {
        T ContainerBand { get; }
    }
}
