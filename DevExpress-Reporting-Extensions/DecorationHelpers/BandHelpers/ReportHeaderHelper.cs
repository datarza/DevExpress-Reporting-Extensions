using System;
using System.Drawing;

using DevExpressReportingExtensions.DecorationHelpers.BaseClasses;
using DevExpressReportingExtensions.Extensions;

using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.DecorationHelpers
{
    public class ReportHeaderHelper : BaseBandHelper<Band>
    {
        public XRTable ContainerControl { get; private set; }

        public XRLabel MainTitleLabel { get; private set; }

        public XRLabel SecondTitleLabel { get; private set; }

        public XRLabel DatesIntervalLabel { get; private set; }

        public XRLabel CurrentTimeLabel { get; private set; }

        public ReportHeaderHelper(Band band)
            : base(band)
        {
            this.InitializeContainer();
            if (!string.IsNullOrWhiteSpace(this.RootReport.Bookmark))
            {
                this.SetMainTitleText(this.RootReport.Bookmark);
            }
        }

        public ReportHeaderHelper(Band band, string mainTitle)
            : base(band)
        {
            this.InitializeContainer();
            this.SetMainTitleText(mainTitle);
        }

        public ReportHeaderHelper(Band band, string mainTitle, string secondTitle)
            : base(band)
        {
            this.InitializeContainer();
            this.SetMainTitleText(mainTitle);
            this.SetSecondTitleText(secondTitle);
        }

        private void InitializeContainer()
        {
            this.ContainerControl = new XRTable()
            {
                AnchorHorizontal = HorizontalAnchorStyles.Both,
                BoundsF = new RectangleF(0F, this.ContainerBand.GetMinPossibleTopPosition(),
                    this.RootReport.GetBandWidth(), 0F),
                CanGrow = true,
                CanShrink = true,
            };

            this.InitializeMainTitle();
            this.InitializeSecondTitle();
            this.InitializeDatesInterval();
            this.InitializeCurrentTime();

            var row1 = new XRTableRow
            {
                Weight = 1D,
            };
            
            row1.Cells.Add(this.MainTitleLabel);
            row1.Cells.Add(this.SecondTitleLabel);

            this.ContainerControl.Rows.Add(row1);

            var row2 = new XRTableRow
            {
                Weight = 1D,
            };

            row2.Cells.Add(this.DatesIntervalLabel);
            row2.Cells.Add(this.CurrentTimeLabel);

            this.ContainerControl.Rows.Add(row2);

            this.ContainerBand.Controls.Add(this.ContainerControl);
        }

        private void InitializeMainTitle()
        {
            this.MainTitleLabel = new XRTableCell()
            {
                AnchorHorizontal = HorizontalAnchorStyles.Both,
                CanGrow = true,
                CanShrink = true,
                ForeColor = ReportConstants.Colors.Header,
                Padding = new PaddingInfo(2, 2, 2, 2),
                Font = new Font(FontFamily.GenericSansSerif, 0.22F, FontStyle.Regular, GraphicsUnit.Inch),
                TextAlignment = TextAlignment.MiddleLeft,
            };
        }

        private void InitializeSecondTitle()
        {
            this.SecondTitleLabel = new XRTableCell()
            {
                AnchorHorizontal = HorizontalAnchorStyles.Both,
                CanGrow = true,
                CanShrink = true,
                ForeColor = ReportConstants.Colors.Header,
                Padding = new PaddingInfo(2, 2, 2, 2),
                Font = new Font(FontFamily.GenericSansSerif, 0.18F, FontStyle.Regular, GraphicsUnit.Inch),
                TextAlignment = TextAlignment.MiddleRight,
            
            };
        }

        private void InitializeDatesInterval()
        {
            this.DatesIntervalLabel = new XRTableCell()
            {
                AnchorHorizontal = HorizontalAnchorStyles.Both,
                CanGrow = true,
                CanShrink = true,
                ForeColor = ReportConstants.Colors.SubHeader,
                Padding = new PaddingInfo(2, 2, 2, 6),
                Font = new Font(FontFamily.GenericSansSerif, 0.1F, FontStyle.Regular, GraphicsUnit.Inch),
                TextAlignment = TextAlignment.MiddleLeft,
            };
        }

        private void InitializeCurrentTime()
        {            
            this.CurrentTimeLabel = new XRTableCell()
            {
                AnchorHorizontal = HorizontalAnchorStyles.Both,
                CanGrow = true,
                CanShrink = true,
                ForeColor = ReportConstants.Colors.SubHeader,
                Padding = new PaddingInfo(2, 2, 2, 6),
                Font = new Font(FontFamily.GenericSansSerif, 0.1F, FontStyle.Regular, GraphicsUnit.Inch),
                TextAlignment = TextAlignment.MiddleRight,
            };
        }

        public ReportHeaderHelper SetMainTitleText(string text)
        {
            this.MainTitleLabel.Text = text;
            return this;
        }

        public ReportHeaderHelper SetSecondTitleText(string text)
        {
            this.SecondTitleLabel.Text = text;
            return this;
        }

        public ReportHeaderHelper BindSecondTitleText(string dataMember)
        {
            this.SecondTitleLabel.AddTextBinding(this.Report.JoinWithDataMember(dataMember));
            return this;
        }

        public ReportHeaderHelper BindSecondTitleTextAndBookmark(string dataMember)
        {
            var controlDataMember = this.Report.JoinWithDataMember(dataMember);
            this.SecondTitleLabel.AddTextBinding(controlDataMember);
            this.SecondTitleLabel.AddBookmarkBinding(controlDataMember);
            return this;
        }

        public ReportHeaderHelper PrintDatesInterval(DateTime? dateFrom, DateTime? dateTo)
        {
            if (dateFrom.HasValue && dateTo.HasValue)
            {
                this.DatesIntervalLabel.Text = $"For period from {dateFrom:D} to {dateTo:D}";
            }
            else if (dateFrom.HasValue)
            {
                this.DatesIntervalLabel.Text = $"For period from {dateFrom:D}";
            }
            else if (dateTo.HasValue)
            {
                this.DatesIntervalLabel.Text = $"For period to {dateTo:D}";
            }
            else
            {
                this.DatesIntervalLabel.Text = string.Empty;
            }
            return this;
        }

        public ReportHeaderHelper PrintCurrentTime(DateTime? printTime)
        {
            if (printTime.HasValue)
            {
                this.CurrentTimeLabel.Text = printTime.Value.ToString("f");
            }
            else
            {
                this.CurrentTimeLabel.Text = string.Empty;
            }
            return this;
        }

    }
}
