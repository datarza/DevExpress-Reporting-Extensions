using System.Collections.Generic;
using System.Drawing;

using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

using DevExpressReportingExtensions.Helpers.BaseClasses;
using DevExpressReportingExtensions.Reports;

namespace DevExpressReportingExtensions.Helpers
{
    public class GridHelper : BaseDetailBandHelper
    {
        public XRTableRow ContainerControl { get; protected set; }

        public IEnumerable<XRTableCell> Columns { get { return this.ContainerControl.Cells; } }
        
        public GridHelper(XtraReport report, XtraReportBase detailReport = null)
            : base(report, detailReport)
        {
            this.ContainerBand.StyleName = this.CreateContainerBandStyle();
            this.ContainerControl = this.CreateContainerControls();
        }

        protected virtual string CreateContainerBandStyle()
        {
            var styleName = $"{nameof(GridHelper)}_{nameof(DetailBand)}";
            this.RootReport.StyleSheet.Add(new XRControlStyle()
            {
                Name = styleName,
                ForeColor = Color.Black,
                BackColor = Color.Transparent,
                BorderColor = Color.LightGray,
                Borders = BorderSide.Bottom,
                BorderWidth = 0.5F,
                BorderDashStyle = BorderDashStyle.DashDot,
                Padding = new PaddingInfo(2, 2, 1, 1),
                Font = new Font(FontFamily.GenericSansSerif, 0.09F, FontStyle.Regular, GraphicsUnit.Inch),
                TextAlignment = TextAlignment.MiddleLeft,
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

        protected virtual XRTableCell AddColumn(double weight, string dataMember)
        {
            var result = this.ContainerControl.AddCell(weight);

            result.AddTextBinding(this.BaseReport.JoinWithDataMember(dataMember));

            return result;
        }

        public GridHelper AddColumn(
            double weight,
            string dataMember,
            string formatString,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            var result = this.AddColumn(weight, dataMember);

            if (!string.IsNullOrWhiteSpace(formatString))
            {
                result.SetFormat(formatString);
            }

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

        public GridHelper AddColumn(
            double weight,
            string dataMember,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            return this.AddColumn(weight, dataMember, null, border, alignment);
        }

        public GridHelper AddColumn(
            double weight,
            string dataMember,
            TextAlignment alignment)
        {
            return this.AddColumn(weight, dataMember, null, null, alignment);
        }

        public GridHelper AddColumnDate(
            double weight,
            string dataMember,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            var cell = this.AddColumn(weight, dataMember);

            cell.SetFormatDate(null, border, alignment);

            return this;
        }

        public GridHelper AddColumnDateTime(
            double weight,
            string dataMember,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            var cell = this.AddColumn(weight, dataMember);

            cell.SetFormatDateTime(null, border, alignment);

            return this;
        }

        public GridHelper AddColumnNumber(
            double weight,
            string dataMember,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            var cell = this.AddColumn(weight, dataMember);

            cell.SetFormatNumber(null, border, alignment);

            cell.AddZeroNullFormattingRule(dataMember);

            return this;
        }

        public GridHelper AddColumnMoney(
            double weight,
            string dataMember,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            var cell = this.AddColumn(weight, dataMember);

            cell.SetFormatMoney(null, border, alignment);

            cell.AddZeroNullFormattingRule(dataMember);

            return this;
        }

        public GridHelper AddColumnPercent(
            double weight,
            string dataMember,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            var cell = this.AddColumn(weight, dataMember);

            cell.SetFormatPercent(null, border, alignment);

            cell.AddZeroNullFormattingRule(dataMember);

            return this;
        }

        public GridHelper SetFormat(string formatString)
        {
            var cell = this.ContainerControl.GetLastCell();
            if (cell != null)
            {
                cell.SetFormat(formatString);
            }
            return this;
        }

        public GridHelper SetBorder(BorderSide border)
        {
            var cell = this.ContainerControl.GetLastCell();
            if (cell != null)
            {
                cell.SetBorder(border);
            }
            return this;
        }

        public GridHelper SetAlignment(TextAlignment alignment)
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
