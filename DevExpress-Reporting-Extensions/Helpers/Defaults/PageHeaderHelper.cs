using System.Collections.Generic;
using System.Drawing;

using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

using DevExpressReportingExtensions.Helpers.BaseClasses;
using DevExpressReportingExtensions.Reports;

namespace DevExpressReportingExtensions.Helpers
{
    public class PageHeaderHelper : BasePageHeaderHelper
    {
        public XRTableRow ContainerControl { get; protected set; }

        public IEnumerable<XRTableCell> Columns { get { return this.ContainerControl.Cells; } }

        public PageHeaderHelper(XtraReport report)
            : base(report)
        {
            this.ContainerBand.StyleName = this.CreateContainerBandStyle();
            this.ContainerControl = this.CreateContainerControls();
        }

        protected virtual string CreateContainerBandStyle()
        {
            var styleName = $"{nameof(PageHeaderHelper)}_{nameof(PageHeaderBand)}";
            this.RootReport.StyleSheet.Add(new XRControlStyle()
            {
                Name = styleName,
                ForeColor = Color.DimGray,
                BackColor = Color.Transparent,
                BorderColor = Color.LightGray,
                Borders = BorderSide.Bottom,
                BorderWidth = 0.5F,
                BorderDashStyle = BorderDashStyle.Solid,
                Padding = new PaddingInfo(2, 2, 1, 1),
                Font = new Font(FontFamily.GenericSansSerif, 0.09F, FontStyle.Bold, GraphicsUnit.Inch),
                TextAlignment = TextAlignment.BottomLeft,
            });
            return styleName;
        }

        protected virtual XRTableRow CreateContainerControls()
        {
            var table = new XRTable
            {
                AnchorHorizontal = HorizontalAnchorStyles.Both,
                BoundsF = new RectangleF(0F, 0F, this.RootReport.GetBandWidth(), 0F),
                CanGrow = true,
                CanShrink = true,
            };
            var row = new XRTableRow()
            {
                Weight = 1D,
                CanGrow = true,
                CanShrink = true,
            };
            table.Rows.Add(row);
            this.ContainerBand.Controls.Add(table);
            return row;
        }

        protected virtual XRTableCell AddColumn(double weight, string text)
        {
            return this.ContainerControl.AddCell(weight, text);
        }

        public PageHeaderHelper AddColumn(
           double weight,
           BorderSide? border = null,
           TextAlignment? alignment = null)
        {
            this.AddColumn(weight, string.Empty, border, alignment);

            return this;
        }

        public PageHeaderHelper AddColumn(
           double weight,
           string text,
           BorderSide? border = null,
           TextAlignment? alignment = null)
        {
            var result = this.AddColumn(weight, text);

            if (border.HasValue)
            {
                result.SetBorder(border.Value);
            }

            if (alignment.HasValue)
            {
                result.SetAlignment(alignment.Value);
            }

            return this;
        }

        public PageHeaderHelper AddColumnDate(
           double weight,
           string text,
           BorderSide? border = null,
           TextAlignment? alignment = null)
        {
            var cell = this.AddColumn(weight, text);

            cell.SetFormatDate(null, border, alignment);

            return this;
        }

        public PageHeaderHelper AddColumnDateTime(
           double weight,
           string text,
           BorderSide? border = null,
           TextAlignment? alignment = null)
        {
            var cell = this.AddColumn(weight, text);

            cell.SetFormatDateTime(null, border, alignment);

            return this;
        }

        public PageHeaderHelper AddColumnNumber(
           double weight,
           string text,
           BorderSide? border = null,
           TextAlignment? alignment = null)
        {
            var cell = this.AddColumn(weight, text);

            cell.SetFormatNumber(null, border, alignment);

            return this;
        }

        public PageHeaderHelper AddColumnMoney(
           double weight,
           string text,
           BorderSide? border = null,
           TextAlignment? alignment = null)
        {
            var cell = this.AddColumn(weight, text);

            cell.SetFormatMoney(null, border, alignment);

            return this;
        }

        public PageHeaderHelper AddColumnPercent(
           double weight,
           string text,
           BorderSide? border = null,
           TextAlignment? alignment = null)
        {
            var cell = this.AddColumn(weight, text);

            cell.SetFormatPercent(null, border, alignment);

            return this;
        }

        public PageHeaderHelper SetBorder(BorderSide border)
        {
            var cell = this.ContainerControl.GetLastCell();
            if (cell != null)
            {
                cell.SetBorder(border);
            }
            return this;
        }

        public PageHeaderHelper SetAlignment(TextAlignment alignment)
        {
            var cell = this.ContainerControl.GetLastCell();
            if (cell != null)
            {
                cell.SetAlignment(alignment);
            }
            return this;
        }

    }
}
