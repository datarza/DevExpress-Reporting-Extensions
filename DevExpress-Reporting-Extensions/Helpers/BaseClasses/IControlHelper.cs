using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Helpers.Bases
{
    interface IControlHelper<T> where T : XRControl
    {
        T ContainerControl { get; }
    }
}
