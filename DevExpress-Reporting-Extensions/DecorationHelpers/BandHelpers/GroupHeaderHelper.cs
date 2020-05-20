using System;
using System.Drawing;

using DevExpressReportingExtensions.DecorationHelpers.BaseClasses;
using DevExpressReportingExtensions.Extensions;

using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.DecorationHelpers
{
    public class GroupHeaderHelper : BaseBandHelper<GroupHeaderBand>
    {
        public XRLabel ContainerControl { get; private set; }

        public GroupHeaderHelper(GroupHeaderBand band)
            : base(band)
        {
            this.InitializeContainer();
        }

        private void InitializeContainer()
        {
            this.ContainerControl = new XRLabel
            {
                AnchorHorizontal = HorizontalAnchorStyles.Both,
                BoundsF = new RectangleF(0F, this.ContainerBand.GetMinPossibleTopPosition(),
                    this.RootReport.GetBandWidth(), 0F),
                CanGrow = true,
                CanShrink = true,
                ForeColor = this.ContainerBand.Level % 2 == 0 ? ReportConstants.Colors.GroupEven : ReportConstants.Colors.GroupOdd,
                BackColor = Color.Transparent,
                //BorderColor = ReportConstants.Colors.Border,
                //Borders = BorderSide.Bottom,
                //BorderWidth = 0.5F,
                //BorderDashStyle = BorderDashStyle.DashDot,
                Padding = new PaddingInfo(2, 2, this.ContainerBand.Level > 0 ? 8 : 4, 2),
                Font = new Font(FontFamily.GenericSansSerif,
                    Convert.ToSingle(Math.Round((this.ContainerBand.Level / 50F) + 0.14F, 2)),
                        FontStyle.Bold, GraphicsUnit.Inch),
                TextAlignment = TextAlignment.MiddleLeft,
                ProcessNullValues = ValueSuppressType.Suppress,
            };

            if (this.ContainerBand.GroupFields.Count > 0)
            {
                var groupField = this.ContainerBand.GroupFields[this.ContainerBand.GroupFields.Count - 1];
                this.ContainerControl.AddTextBinding(this.Report.JoinWithDataMember(groupField.FieldName));
            }
                        
            this.ContainerBand.Controls.Add(this.ContainerControl);
        }

        public GroupHeaderHelper AdjustBookmarks(XRControl bookmarkParent = null)
        {
            var binding = this.ContainerControl.GetTextBinding();
            if (binding != null)
            {
                this.ContainerControl.AddBookmarkBinding(binding.DataMember, binding.FormatString);
            }
            if (bookmarkParent != null)
            {
                this.ContainerControl.BookmarkParent = bookmarkParent;
            }
            return this;
        }

        public GroupHeaderHelper AdjustBorderStyle()
        {
            this.ContainerBand.BorderColor = ReportConstants.Colors.Border;
            this.ContainerBand.Borders = BorderSide.Bottom;
            this.ContainerBand.BorderWidth = 0.5F;
            this.ContainerBand.BorderDashStyle = BorderDashStyle.DashDot;
            return this;
        }

    }
}
