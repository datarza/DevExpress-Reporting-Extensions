using System.Collections.Generic;
using System.Drawing;

using DevExpressReportingExtensions.DecorationHelpers.BaseClasses;
using DevExpressReportingExtensions.Extensions;

using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.DecorationHelpers
{
    public class SimpleGridColumnHelper : BaseBandHelper
    {
        public XRTableRow ContainerControl { get; protected set; }

        public XRControlStyle ContainerStyle { get; private set; }

        public IEnumerable<XRTableCell> Columns { get { return this.ContainerControl.Cells; } }

        public SimpleGridColumnHelper(Band band)
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

        public SimpleGridColumnHelper AddColumn(
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

        public SimpleGridColumnHelper AddColumn(
            double weight,
            string dataMember,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            return this.AddColumn(weight, dataMember, null, border, alignment);
        }

        public SimpleGridColumnHelper AddColumn(
            double weight,
            string dataMember,
            TextAlignment alignment)
        {
            return this.AddColumn(weight, dataMember, null, null, alignment);
        }

        public SimpleGridColumnHelper AddColumnDate(
            double weight,
            string dataMember,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            var cell = this.AddColumn(weight, dataMember);

            cell.SetFormatDate(null, border, alignment);

            return this;
        }

        public SimpleGridColumnHelper AddColumnDateTime(
            double weight,
            string dataMember,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            var cell = this.AddColumn(weight, dataMember);

            cell.SetFormatDateTime(null, border, alignment);

            return this;
        }

        public SimpleGridColumnHelper AddColumnNumber(
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

        public SimpleGridColumnHelper AddColumnMoney(
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

        public SimpleGridColumnHelper AddColumnPercent(
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

        public SimpleGridColumnHelper SetFormat(string formatString)
        {
            var cell = this.ContainerControl.GetLastCell();
            if (cell != null)
            {
                cell.SetFormat(formatString);
            }
            return this;
        }

        public SimpleGridColumnHelper SetBorder(BorderSide border)
        {
            var cell = this.ContainerControl.GetLastCell();
            if (cell != null)
            {
                cell.SetBorder(border);
            }
            return this;
        }

        public SimpleGridColumnHelper SetAlignment(TextAlignment alignment)
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
