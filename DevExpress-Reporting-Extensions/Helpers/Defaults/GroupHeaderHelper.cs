using System;
using System.Drawing;
using System.Linq;

using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

using DevExpressReportingExtensions.Helpers.BaseClasses;
using DevExpressReportingExtensions.Reports;

namespace DevExpressReportingExtensions.Helpers
{
    public class GroupHeaderHelper : BaseGroupHeaderHelper
    {
        public GroupHeaderHelper(XtraReport report,
            string fieldName,
            XRColumnSortOrder sortOrder = XRColumnSortOrder.Ascending,
            string formatString = null)
            : this(report, null, fieldName, sortOrder, formatString)
        {
        }

        public GroupHeaderHelper(XtraReport report, XtraReportBase detailReport,
            string fieldName,
            XRColumnSortOrder sortOrder = XRColumnSortOrder.Ascending,
            string formatString = null)
            : this(report, detailReport, formatString, new GroupField(fieldName, sortOrder))
        {
        }

        protected GroupHeaderHelper(XtraReport report, XtraReportBase detailReport,
            string formatString,
            params GroupField[] fields)
            : base(report, detailReport, fields)
        {
            this.ContainerBand.StyleName = this.CreateContainerBandStyle(this.ContainerBand.Level);
            this.CreateContainerControls(fields[0].FieldName, formatString);
        }

        protected virtual string CreateContainerBandStyle(int level)
        {
            var styleName = $"{nameof(GroupHeaderHelper)}_{nameof(GroupHeaderBand)}_{level}";
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

        protected virtual XRControl CreateContainerControls(string fieldName, string formatString)
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

        public GroupHeaderHelper AdjustBorderStyleFromDetail()
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
