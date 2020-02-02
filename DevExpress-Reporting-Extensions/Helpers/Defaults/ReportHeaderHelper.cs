using System.Drawing;

using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

using DevExpressReportingExtensions.Helpers.Base;
using DevExpressReportingExtensions.Reports;

namespace DevExpressReportingExtensions.Helpers
{
    public class DefaultReportHeaderHelper : BaseReportHeaderHelper
    {
        public readonly XRLabel HeaderLabel;

        public DefaultReportHeaderHelper(XtraReport report, string headerText)
            : this(report, null, headerText)
        {
        }

        public DefaultReportHeaderHelper(XtraReport report, XtraReportBase detailReport, string headerText)
            : base(report, detailReport)
        {
            this.HeaderLabel = this.CreateContainerControls(headerText);
        }

        protected virtual XRLabel CreateContainerControls(string headerText)
        {
            var headerLabel = new XRLabel()
            {
                AnchorHorizontal = HorizontalAnchorStyles.Both,
                BoundsF = new RectangleF(0F, 0F, this.RootReport.GetBandWidth(), 0F),
                CanGrow = true,
                CanShrink = true,
                Padding = new PaddingInfo(2, 2, 0, 8),
                Font = new Font(FontFamily.GenericSansSerif, 0.2F, FontStyle.Regular, GraphicsUnit.Inch),
                TextAlignment = TextAlignment.MiddleLeft,
                ForeColor = Color.Gray,
                Text = headerText
            };
            this.ContainerBand.Controls.Add(headerLabel);

            return headerLabel;
        }

    }
}
