using System;
using System.Drawing;

using myClippit.DevExpress.Report.Extensions;

using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace myClippit.DevExpress.Report.DecorationHelpers
{
    public class DefaultReportHeaderHelper : BaseReportHeaderHelper
    {
        public readonly XRLabel PrintTimeLabel;

        public DefaultReportHeaderHelper(XtraReport report, XtraReportBase detailReport = null)
            : base(report, detailReport)
        {
            this.PrintTimeLabel = this.CreateContainerControls();
        }
        
        protected virtual XRLabel CreateContainerControls()
        {
            var titleLabel = new XRLabel()
            {
                AnchorHorizontal = HorizontalAnchorStyles.Both,
                BoundsF = new RectangleF(this.RootReport.GetBandWidth() / 2F, 0F, this.RootReport.GetBandWidth() / 2F, 0F),
                CanGrow = true,
                CanShrink = true,
                Padding = new PaddingInfo(2, 2, 0, 0),
                Font = new Font(FontFamily.GenericSansSerif, 0.18F, FontStyle.Regular, GraphicsUnit.Inch),
                TextAlignment = TextAlignment.MiddleRight,
                ForeColor = Color.Gray
            };
            this.ContainerBand.Controls.Add(titleLabel);

            titleLabel.PrintOnPage += TitleLabel_PrintOnPage;

            return titleLabel;
        }
        
        private void TitleLabel_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            ((XRControl)sender).Text = DateTime.Now.ToString("f");
        }

    }
}
