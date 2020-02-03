using System.Drawing;

using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

using DevExpressReportingExtensions.Helpers.Bases;
using DevExpressReportingExtensions.Reports;

namespace DevExpressReportingExtensions.Helpers
{
    public class DefaultPageNumberHelper : BasePageFooterHelper, IControlHelper<XRPageInfo>
    {
        public XRPageInfo ContainerControl { get; protected set; }

        public DefaultPageNumberHelper(XtraReport report,
            TextAlignment? alignment = null,
            string formatString = null)
            : base(report)
        {
            this.ContainerControl = this.CreateContainerControls(
                alignment ?? ReportConstants.PageNumbers.Alignment,
                    formatString ?? ReportConstants.PageNumbers.FormatString);
        }

        protected virtual XRPageInfo CreateContainerControls(TextAlignment alignment, string formatString)
        {
            var result = new XRPageInfo
            {
                AnchorHorizontal = HorizontalAnchorStyles.Both,
                BoundsF = new RectangleF(0F, 0F, this.RootReport.GetBandWidth(), 0F),
                Padding = new PaddingInfo(4, 4, 4, 4),
                TextAlignment = alignment,
                Format = formatString,
                ForeColor = Color.Gray,
                Font = new Font(FontFamily.GenericSansSerif, 0.08F, FontStyle.Italic, GraphicsUnit.Inch),
                PageInfo = PageInfo.NumberOfTotal,
            };
            this.ContainerBand.Controls.Add(result);
            return result;
        }

    }
}
