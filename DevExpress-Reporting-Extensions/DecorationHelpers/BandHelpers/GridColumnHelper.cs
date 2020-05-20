using System.Collections.Generic;
using System.Drawing;

using DevExpressReportingExtensions.DecorationHelpers.BaseClasses;
using DevExpressReportingExtensions.Extensions;

using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.DecorationHelpers
{
    public class GridColumnHelper : BaseBandHelper<Band>
    {
        public XRTableRow ContainerControl { get; protected set; }

        public XRControlStyle ContainerStyle { get; private set; }

        public IEnumerable<XRTableCell> Columns { get { return this.ContainerControl.Cells; } }

        public GridColumnHelper(Band band)
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
                ForeColor = ReportConstants.Colors.Base,
                BackColor = Color.Transparent,
                BorderColor = ReportConstants.Colors.Border,
                Borders = BorderSide.Bottom,
                BorderWidth = 0.5F,
                BorderDashStyle = BorderDashStyle.DashDot,
                Padding = new PaddingInfo(2, 2, 1, 1),
                Font = new Font(FontFamily.GenericSansSerif, 0.09F, FontStyle.Regular, GraphicsUnit.Inch),
                TextAlignment = TextAlignment.MiddleLeft,
            };

            this.ContainerControl = new XRTableRow
            {
                Weight = 1D,
            };
            table.Rows.Add(this.ContainerControl);

            this.ContainerBand.Controls.Add(table);
        }

        private XRTableCell AddColumn(double weight, string dataMember)
        {
            var result = this.ContainerControl.AddCell(weight);

            result.AddTextBinding(this.Report.JoinWithDataMember(dataMember));

            return result;
        }

        public GridColumnHelper AddColumn(
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

        public GridColumnHelper AddColumn(
            double weight,
            string dataMember,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            return this.AddColumn(weight, dataMember, null, border, alignment);
        }

        public GridColumnHelper AddColumn(
            double weight,
            string dataMember,
            TextAlignment alignment)
        {
            return this.AddColumn(weight, dataMember, null, null, alignment);
        }

        public GridColumnHelper AddColumnDate(
            double weight,
            string dataMember,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            var cell = this.AddColumn(weight, dataMember);

            cell.SetFormatDate(null, border, alignment);

            return this;
        }

        public GridColumnHelper AddColumnDateTime(
            double weight,
            string dataMember,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            var cell = this.AddColumn(weight, dataMember);

            cell.SetFormatDateTime(null, border, alignment);

            return this;
        }

        public GridColumnHelper AddColumnNumber(
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

        public GridColumnHelper AddColumnMoney(
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

        public GridColumnHelper AddColumnPercent(
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

        public GridColumnHelper SetFormat(string formatString)
        {
            var cell = this.ContainerControl.GetLastCell();
            if (cell != null)
            {
                cell.SetFormat(formatString);
            }
            return this;
        }

        public GridColumnHelper SetBorder(BorderSide border)
        {
            var cell = this.ContainerControl.GetLastCell();
            if (cell != null)
            {
                cell.SetBorder(border);
            }
            return this;
        }

        public GridColumnHelper SetAlignment(TextAlignment alignment)
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
