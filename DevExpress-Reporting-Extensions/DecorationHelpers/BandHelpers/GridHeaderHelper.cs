using System.Collections.Generic;
using System.Drawing;

using DevExpressReportingExtensions.DecorationHelpers.BaseClasses;
using DevExpressReportingExtensions.Extensions;

using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.DecorationHelpers
{
    public class GridHeaderHelper : BaseBandHelper<Band>
    {
        public XRTableRow ContainerControl { get; private set; }

        public XRControlStyle ContainerStyle { get; private set; }

        public IEnumerable<XRTableCell> Columns { get { return this.ContainerControl.Cells; } }

        public GridHeaderHelper(Band band)
            : base(band)
        {
            this.InitializeContainer();
        }

        private void InitializeContainer()
        {
            var table = new XRTable
            {
                AnchorHorizontal = HorizontalAnchorStyles.Both,
                BoundsF = new RectangleF(0F, this.ContainerBand.GetMinPossibleTopPosition(),
                    this.RootReport.GetBandWidth(), 0F),
                CanGrow = true,
                CanShrink = true,
                ForeColor = ReportConstants.Colors.ColumnHeader,
                BackColor = Color.Transparent,
                BorderColor = ReportConstants.Colors.Border,
                Borders = BorderSide.Bottom,
                BorderWidth = 0.5F,
                BorderDashStyle = BorderDashStyle.Solid,
                Padding = new PaddingInfo(2, 2, 1, 1),
                Font = new Font(FontFamily.GenericSansSerif, 0.09F, FontStyle.Regular, GraphicsUnit.Inch),
                TextAlignment = TextAlignment.BottomLeft,
            };

            this.ContainerControl = new XRTableRow
            {
                Weight = 1D,
            };
            table.Rows.Add(this.ContainerControl);

            this.ContainerBand.Controls.Add(table);
        }

        private XRTableCell AddColumn(double weight, string text)
        {
            return this.ContainerControl.AddCell(weight, text);
        }

        public GridHeaderHelper AddColumn(
           double weight,
           BorderSide? border = null,
           TextAlignment? alignment = null)
        {
            this.AddColumn(weight, string.Empty, border, alignment);

            return this;
        }

        public GridHeaderHelper AddColumn(
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

        public GridHeaderHelper AddColumnDate(
           double weight,
           string text,
           BorderSide? border = null,
           TextAlignment? alignment = null)
        {
            var cell = this.AddColumn(weight, text);

            cell.SetFormatDate(null, border, alignment);

            return this;
        }

        public GridHeaderHelper AddColumnDateTime(
           double weight,
           string text,
           BorderSide? border = null,
           TextAlignment? alignment = null)
        {
            var cell = this.AddColumn(weight, text);

            cell.SetFormatDateTime(null, border, alignment);

            return this;
        }

        public GridHeaderHelper AddColumnNumber(
           double weight,
           string text,
           BorderSide? border = null,
           TextAlignment? alignment = null)
        {
            var cell = this.AddColumn(weight, text);

            cell.SetFormatNumber(null, border, alignment);

            return this;
        }

        public GridHeaderHelper AddColumnMoney(
           double weight,
           string text,
           BorderSide? border = null,
           TextAlignment? alignment = null)
        {
            var cell = this.AddColumn(weight, text);

            cell.SetFormatMoney(null, border, alignment);

            return this;
        }

        public GridHeaderHelper AddColumnPercent(
           double weight,
           string text,
           BorderSide? border = null,
           TextAlignment? alignment = null)
        {
            var cell = this.AddColumn(weight, text);

            cell.SetFormatPercent(null, border, alignment);

            return this;
        }

        public GridHeaderHelper SetBorder(BorderSide border)
        {
            var cell = this.ContainerControl.GetLastCell();
            if (cell != null)
            {
                cell.SetBorder(border);
            }
            return this;
        }

        public GridHeaderHelper SetAlignment(TextAlignment alignment)
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
