using System;
using System.Drawing;

using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

using DevExpressReportingExtensions.Helpers.BaseClasses;
using DevExpressReportingExtensions.Reports;

namespace DevExpressReportingExtensions.Helpers
{
    public class ReportHeaderHelper : BaseReportHeaderHelper
    {
        public XRLabel DateIntervalLabel { get; protected set; }

        public XRLabel PrintTimeLabel { get; protected set; }

        public ReportHeaderHelper(XtraReport report,
            string mainTitle,
            string secondTitle,
            string mainSubTitle = null,
            string secondSubTitle = null)
            : this(report, null, mainTitle, secondTitle, mainSubTitle, secondSubTitle)
        {
        }

        public ReportHeaderHelper(XtraReport report, XtraReportBase detailReport,
            string mainTitle,
            string secondTitle,
            string mainSubTitle = null,
            string secondSubTitle = null)
            : base(report, detailReport)
        {
            if (string.IsNullOrEmpty(mainTitle))
            {
                throw new ArgumentNullException(nameof(mainTitle));
            }

            if (string.IsNullOrEmpty(secondTitle))
            {
                throw new ArgumentNullException(nameof(secondTitle));
            }

            this.DateIntervalLabel = this.CreateMainContainerControls(mainTitle, mainSubTitle);

            this.PrintTimeLabel = this.CreateSecondContainerControls(secondTitle, secondSubTitle);
        }
        
        protected virtual XRLabel CreateMainContainerControls(string title, string subTitle)
        {
            var titleLabel = new XRLabel()
            {
                AnchorHorizontal = HorizontalAnchorStyles.Both,
                BoundsF = new RectangleF(0F, 0F, this.RootReport.GetBandWidth() / 2F, 0F),
                CanGrow = true,
                CanShrink = true,
                Padding = new PaddingInfo(2, 2, 0, 0),
                Font = new Font(FontFamily.GenericSansSerif, 0.22F, FontStyle.Regular, GraphicsUnit.Inch),
                TextAlignment = TextAlignment.MiddleLeft,
                ForeColor = Color.DimGray,
                Text = title,
            };
            this.ContainerBand.Controls.Add(titleLabel);

            var subTitleLabel = new XRLabel()
            {
                AnchorHorizontal = HorizontalAnchorStyles.Both,
                BoundsF = new RectangleF(titleLabel.LeftF, titleLabel.HeightF, titleLabel.WidthF, 0F),
                CanGrow = true,
                CanShrink = true,
                Padding = new PaddingInfo(2, 2, 0, 5),
                Font = new Font(FontFamily.GenericSansSerif, 0.1F, FontStyle.Regular, GraphicsUnit.Inch),
                TextAlignment = TextAlignment.MiddleLeft,
                ForeColor = Color.DimGray,
                Text = subTitle,
            };
            this.ContainerBand.Controls.Add(subTitleLabel);

            return subTitleLabel;
        }

        protected virtual XRLabel CreateSecondContainerControls(string title, string subTitle)
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
                ForeColor = Color.Gray,
                Text = title,
            };
            this.ContainerBand.Controls.Add(titleLabel);

            var subTitleLabel = new XRLabel()
            {
                AnchorHorizontal = HorizontalAnchorStyles.Both,
                BoundsF = new RectangleF(titleLabel.LeftF, titleLabel.HeightF, titleLabel.WidthF, 0F),
                CanGrow = true,
                CanShrink = true,
                Padding = new PaddingInfo(2, 2, 0, 5),
                Font = new Font(FontFamily.GenericSansSerif, 0.1F, FontStyle.Regular, GraphicsUnit.Inch),
                TextAlignment = TextAlignment.MiddleRight,
                ForeColor = Color.Gray,
                Text = subTitle,
            };
            this.ContainerBand.Controls.Add(subTitleLabel);

            return subTitleLabel;
        }

        public virtual void PrintPeriodOnMainSubTitle(DateTime? dateFrom, DateTime? dateTo)
        {
            if (dateFrom.HasValue && dateTo.HasValue)
            {
                this.DateIntervalLabel.Text = $"For period from {dateFrom:d} to {dateTo:d}";
            }
            else if (dateFrom.HasValue)
            {
                this.DateIntervalLabel.Text = $"For period from {dateFrom:d}";
            }
            else if (dateTo.HasValue)
            {
                this.DateIntervalLabel.Text = $"For period to {dateTo:d}";
            }
            else
            {
                this.DateIntervalLabel.Text = string.Empty;
            }
        }

        public virtual void PrintDateOnSecondSubTitle(DateTime? printTime)
        {
            if (printTime.HasValue)
            {
                this.PrintTimeLabel.Text = printTime.Value.ToString("f");
            }
            else
            {
                this.PrintTimeLabel.Text = string.Empty;
            }
        }
    }
}
