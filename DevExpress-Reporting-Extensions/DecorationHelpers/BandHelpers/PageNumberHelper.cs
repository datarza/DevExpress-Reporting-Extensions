using System.Drawing;

using DevExpressReportingExtensions.DecorationHelpers.BaseClasses;
using DevExpressReportingExtensions.Extensions;

using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.DecorationHelpers
{
    public class PageNumberHelper : BaseBandHelper<Band>
    {
        public XRPageInfo ContainerControl { get; private set; }

        public PageNumberHelper(Band band)
            : base(band)
        {
            this.InitializeContainer();
        }

        public PageNumberHelper(Band band, Band runningBand)
            : base(band)
        {
            this.InitializeContainer();
            this.SetRunningBand(runningBand);
        }

        private void InitializeContainer()
        {
            this.ContainerControl = new XRPageInfo
            {
                AnchorHorizontal = HorizontalAnchorStyles.Both,
                BoundsF = new RectangleF(0F, this.ContainerBand.GetMinPossibleTopPosition(),
                    this.RootReport.GetBandWidth(), 20F),
                //CanGrow = true, 
                //CanShrink = true, 
                ForeColor = ReportConstants.Colors.PageNumber,
                Padding = new PaddingInfo(4, 4, 0, 0),
                Font = new Font(FontFamily.GenericSansSerif, 0.08F, FontStyle.Italic, GraphicsUnit.Inch),
                TextAlignment = TextAlignment.MiddleRight,
                Format = ReportConstants.FormatStrings.PageNumber,
                PageInfo = PageInfo.NumberOfTotal,
            };

            this.ContainerBand.Controls.Add(this.ContainerControl);
        }

        public virtual PageNumberHelper SetRunningBand(Band runningBand)
        {
            this.ContainerControl.RunningBand = runningBand;
            return this;
        }

    }
}
