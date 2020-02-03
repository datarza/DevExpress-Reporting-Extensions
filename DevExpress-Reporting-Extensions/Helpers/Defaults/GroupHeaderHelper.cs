using System;
using System.Drawing;
using System.Linq;

using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

using DevExpressReportingExtensions.Helpers.Bases;
using DevExpressReportingExtensions.Reports;

namespace DevExpressReportingExtensions.Helpers
{
    public class DefaultGroupHeaderHelper : BaseMasterDetailHelper
    {
        public readonly GroupHeaderBand ContainerBand;

        protected readonly string fieldName;
        protected readonly XRColumnSortOrder sortOrder;
        protected readonly string formatString;

        public DefaultGroupHeaderHelper(XtraReport report,
            string fieldName,
            XRColumnSortOrder? sortOrder = null,
            string formatString = null)
            : this(report, null, fieldName, sortOrder, formatString)
        {
        }

        public DefaultGroupHeaderHelper(XtraReport report, XtraReportBase detailReport,
            string fieldName,
            XRColumnSortOrder? sortOrder = null,
            string formatString = null)
            : base(report, detailReport)
        {
            this.fieldName = fieldName ?? throw new ArgumentNullException(nameof(fieldName));
            this.sortOrder = sortOrder ?? XRColumnSortOrder.Ascending;
            this.formatString = formatString;

            this.ContainerBand = this.CreateContainerBand();
            this.CreateContainerControls();
        }

        protected virtual GroupHeaderBand CreateContainerBand()
        {
            var result = new GroupHeaderBand
            {
                KeepTogether = true,
                HeightF = 0F,
                GroupUnion = GroupUnion.WithFirstDetail,
                RepeatEveryPage = true,
            };
            result.GroupFields.Add(new GroupField(this.fieldName, this.sortOrder));
            result.Level = this.BaseReport.Bands.OfType<GroupHeaderBand>().Count();
            this.BaseReport.Bands.Add(result);
            result.StyleName = this.CreateContainerBandStyle(result.Level);
            return result;
        }

        protected virtual string CreateContainerBandStyle(int level)
        {
            var styleName = $"{nameof(DefaultGroupHeaderHelper)}_{nameof(GroupHeaderBand)}_{level}";
            this.RootReport.StyleSheet.Add(new XRControlStyle()
            {
                Name = styleName,
                ForeColor = Color.DimGray,
                BackColor = Color.Transparent,
                //BorderColor = Color.LightGray,
                //Borders = BorderSide.Bottom,
                //BorderWidth = 0.5F,
                //BorderDashStyle = BorderDashStyle.DashDot,
                Padding = new PaddingInfo(2, 2, level > 0 ? 8 : 4, 2),
                Font = new Font(FontFamily.GenericSansSerif,
                    Convert.ToSingle(Math.Round((level / 50F) + 0.14F, 2)),
                        FontStyle.Bold, GraphicsUnit.Inch),
                TextAlignment = TextAlignment.BottomLeft,
            });
            return styleName;
        }

        protected virtual XRControl CreateContainerControls()
        {
            var result = new XRLabel
            {
                BoundsF = new RectangleF(0F, 0F, this.RootReport.GetBandWidth(), 0F),
                CanGrow = true,
                CanShrink = true,
                AnchorHorizontal = HorizontalAnchorStyles.Both,
                ProcessNullValues = ValueSuppressType.Suppress,
            };

            result.AddTextBinding(this.BaseReport.JoinWithDataMember(fieldName), formatString);

            this.ContainerBand.Controls.Add(result);

            if (this.RootReport == this.BaseReport)
            {   
                result.PrintOnPage += delegate (object sender, PrintOnPageEventArgs e)
                {
                    this.SetBookmarkForMainGroup((XRControl)sender);
                };
            }

            return result;
        }

        protected virtual void SetBookmarkForMainGroup(XRControl label)
        {
            int maxLevel = label.RootReport.Bands.OfType<GroupHeaderBand>().Max(c => c.Level);
            GroupBand labelBand = label.Band as GroupBand;
            if (labelBand != null && maxLevel == labelBand.Level)
            {
                label.Bookmark = label.Text;
            }
        }

        public DefaultGroupHeaderHelper AdjustBorderStyleFromDetail()
        {
            var detailBand = this.RootReport.Bands.GetBandByType(typeof(DetailBand));
            if (detailBand != null && detailBand.Styles.Style != null
                && detailBand.Styles.Style.Borders.HasFlag(BorderSide.Bottom)
                && !detailBand.Styles.Style.Borders.HasFlag(BorderSide.Top))
            {
                this.ContainerBand.Borders = detailBand.Styles.Style.Borders;
                this.ContainerBand.BorderWidth = detailBand.Styles.Style.BorderWidth;
                this.ContainerBand.BorderColor = detailBand.Styles.Style.BorderColor;
                this.ContainerBand.BorderDashStyle = detailBand.Styles.Style.BorderDashStyle;
            }
            return this;
        }

    }
}
