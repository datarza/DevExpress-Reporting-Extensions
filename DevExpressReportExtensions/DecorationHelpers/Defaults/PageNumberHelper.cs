using System.Drawing;

using myClippit.DevExpress.Report.Extensions;

using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace myClippit.DevExpress.Report.DecorationHelpers
{
    public class DefaultPageNumberHelper : BaseReportHelper
    {
        public readonly MarginBand ContainerBand;

        public readonly XRPageInfo ContainerControl;

        public DefaultPageNumberHelper(XtraReport report,
            TextAlignment? alignment = null,
            string formatString = null)
            : base(report)
        {
            this.ContainerBand = this.CreateContainerBand();

            this.ContainerControl = this.CreateContainerControls(
                alignment ?? ReportConstants.PageNumbers.Alignment,
                    formatString ?? ReportConstants.PageNumbers.FormatString);
        }

        protected virtual BottomMarginBand CreateContainerBand()
        {
            var result = this.RootReport.GetBandByType<BottomMarginBand>();
            if (result == null)
            {
                result = new BottomMarginBand
                {
                    HeightF = this.RootReport.Margins.Bottom
                };
                this.RootReport.Bands.Add(result);
            }
            return result;
        }

        protected virtual XRPageInfo CreateContainerControls(TextAlignment alignment, string formatString)
        {
            var result = new XRPageInfo
            {
                LocationF = new PointF(0F, 0F),
                SizeF = new SizeF(this.RootReport.GetBandWidth(), this.ContainerBand.HeightF),
                Padding = new PaddingInfo(4, 4, 4, 4),
                AnchorHorizontal = HorizontalAnchorStyles.Both,
                AnchorVertical = VerticalAnchorStyles.Both,
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
