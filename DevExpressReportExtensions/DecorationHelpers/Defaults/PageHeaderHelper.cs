using System.Collections.Generic;
using System.Drawing;

using myClippit.DevExpress.Report.Extensions;

using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace myClippit.DevExpress.Report.DecorationHelpers
{
    public class DefaultPageHeaderHelper : BaseReportHelper
    {
        public readonly PageBand ContainerBand;

        public readonly XRTableRow ContainerControl;

        public IEnumerable<XRTableCell> Columns { get { return this.ContainerControl.Cells; } }

        public DefaultPageHeaderHelper(XtraReport report)
            : base(report)
        {
            this.ContainerBand = this.CreateContainerBand();
            this.ContainerControl = this.CreateContainerControls();
        }

        protected virtual PageHeaderBand CreateContainerBand()
        {
            var result = this.RootReport.GetBandByType<PageHeaderBand>();
            if (result == null)
            {
                result = new PageHeaderBand()
                {
                    PrintOn = PrintOnPages.AllPages,
                    HeightF = 0F,
                };
                this.RootReport.Bands.Add(result);
            }
            else
            {
                result.Controls.Clear();
                result.HeightF = 0F;
            }
            result.StyleName = this.CreateContainerBandStyle();
            return result;
        }

        protected virtual string CreateContainerBandStyle()
        {
            var styleName = $"{nameof(DefaultPageHeaderHelper)}_{nameof(PageHeaderBand)}";
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

        public DefaultPageHeaderHelper AddColumn(
           double weight,
           BorderSide? border = null,
           TextAlignment? alignment = null)
        {
            this.AddColumn(weight, string.Empty, border, alignment);

            return this;
        }

        public DefaultPageHeaderHelper AddColumn(
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

        public DefaultPageHeaderHelper AddColumnDate(
           double weight,
           string text,
           BorderSide? border = null,
           TextAlignment? alignment = null)
        {
            var cell = this.AddColumn(weight, text);

            cell.SetFormatDate(null, border, alignment);

            return this;
        }

        public DefaultPageHeaderHelper AddColumnDateTime(
           double weight,
           string text,
           BorderSide? border = null,
           TextAlignment? alignment = null)
        {
            var cell = this.AddColumn(weight, text);

            cell.SetFormatDateTime(null, border, alignment);

            return this;
        }

        public DefaultPageHeaderHelper AddColumnNumber(
           double weight,
           string text,
           BorderSide? border = null,
           TextAlignment? alignment = null)
        {
            var cell = this.AddColumn(weight, text);

            cell.SetFormatNumber(null, border, alignment);

            return this;
        }

        public DefaultPageHeaderHelper AddColumnMoney(
           double weight,
           string text,
           BorderSide? border = null,
           TextAlignment? alignment = null)
        {
            var cell = this.AddColumn(weight, text);

            cell.SetFormatMoney(null, border, alignment);

            return this;
        }

        public DefaultPageHeaderHelper AddColumnPercent(
           double weight,
           string text,
           BorderSide? border = null,
           TextAlignment? alignment = null)
        {
            var cell = this.AddColumn(weight, text);

            cell.SetFormatPercent(null, border, alignment);

            return this;
        }

        public DefaultPageHeaderHelper SetBorder(BorderSide border)
        {
            var cell = this.ContainerControl.GetLastCell();
            if (cell != null)
            {
                cell.SetBorder(border);
            }
            return this;
        }

        public DefaultPageHeaderHelper SetAlignment(TextAlignment alignment)
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
