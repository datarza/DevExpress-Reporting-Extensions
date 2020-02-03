using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

using DevExpressReportingExtensions.Helpers.Bases;
using DevExpressReportingExtensions.Reports;

namespace DevExpressReportingExtensions.Helpers
{
    public class DefaultGroupFooterHelper : BaseMasterDetailHelper
    {
        public readonly GroupFooterBand ContainerBand;

        public readonly XRTableRow ContainerControl;

        public IEnumerable<XRTableCell> Columns { get { return this.ContainerControl.Cells; } }
        
        public DefaultGroupFooterHelper(XtraReport report, XtraReportBase detailReport = null)
            : base(report, detailReport)
        {
            this.ContainerBand = this.CreateContainerBand();
            this.ContainerControl = this.CreateContainerControls();
        }

        protected virtual GroupFooterBand CreateContainerBand()
        {
            var result = new GroupFooterBand
            {
                KeepTogether = true,
                HeightF = 0F,
                GroupUnion = GroupFooterUnion.WithLastDetail,
                RepeatEveryPage = false,
            };
            result.Level = this.BaseReport.Bands.OfType<GroupFooterBand>().Count();
            this.BaseReport.Bands.Add(result);
            result.StyleName = this.CreateContainerBandStyle();
            return result;
        }
        
        protected virtual string CreateContainerBandStyle()
        {
            var styleName = $"{nameof(DefaultGroupFooterHelper)}_{nameof(GroupFooterBand)}";
            this.RootReport.StyleSheet.Add(new XRControlStyle()
            {
                Name = styleName,
                ForeColor = Color.DimGray,
                BackColor = Color.Transparent,
                BorderColor = Color.LightGray,
                //Borders = BorderSide.Bottom,
                //BorderWidth = 0.5F,
                //BorderDashStyle = BorderDashStyle.DashDot,
                Padding = new PaddingInfo(2, 2, 1, 1),
                Font = new Font(FontFamily.GenericSansSerif, 0.09F, FontStyle.Bold, GraphicsUnit.Inch),
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
        
        protected virtual XRSummary CreateSummary(SummaryFunc summaryFunc,
            string formatString = null)
        {
            var result = new XRSummary
            {
                Running = SummaryRunning.Group,
                Func = summaryFunc,
                IgnoreNullValues = true,
            };

            if (!string.IsNullOrWhiteSpace(formatString))
            {
                result.FormatString = formatString;
            }

            return result;
        }

        public DefaultGroupFooterHelper AddColumn(double weight,
            BorderSide? border = null)
        {
            var cell = this.ContainerControl.AddCell(weight);
            if (border.HasValue)
            {
                cell.SetBorder(border.Value);
            }
            return this;
        }

        public DefaultGroupFooterHelper AddColumn(
            double weight,
            string dataMember,
            SummaryFunc? summaryFunc = null,
            string formatString = null,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            var cell = this.ContainerControl.AddCell(weight);

            var binding = cell.AddTextBinding(this.BaseReport.JoinWithDataMember(dataMember));

            if (!string.IsNullOrWhiteSpace(formatString))
            {
                cell.SetFormat(formatString);
            }

            if (border.HasValue)
            {
                cell.SetBorder(border.Value);
            }

            if (alignment.HasValue)
            {
                cell.SetAlignment(alignment.Value);
            }

            if (summaryFunc.HasValue)
                cell.Summary = this.CreateSummary(summaryFunc.Value, formatString);

            return this;
        }

        public DefaultGroupFooterHelper AddColumnCount(
            double weight,
            string dataMember,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            var cell = this.ContainerControl.AddCell(weight);

            var binding = cell.AddTextBinding(this.BaseReport.JoinWithDataMember(dataMember));

            cell.SetFormatCount(null, border, alignment);

            cell.Summary = this.CreateSummary(SummaryFunc.Count, binding.FormatString);

            return this;
        }

        public DefaultGroupFooterHelper AddColumnNumber(
            double weight,
            string dataMember,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            var cell = this.ContainerControl.AddCell(weight);

            var binding = cell.AddTextBinding(this.BaseReport.JoinWithDataMember(dataMember));

            cell.SetFormatNumber(null, border, alignment);

            cell.Summary = this.CreateSummary(SummaryFunc.Sum, binding.FormatString);

            return this;
        }

        public DefaultGroupFooterHelper AddColumnMoney(
            double weight,
            string dataMember,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            var cell = this.ContainerControl.AddCell(weight);

            var binding = cell.AddTextBinding(this.BaseReport.JoinWithDataMember(dataMember));

            cell.SetFormatMoney(null, border, alignment);

            cell.Summary = this.CreateSummary(SummaryFunc.Sum, binding.FormatString);

            return this;
        }

        public DefaultGroupFooterHelper AddColumnPercent(
            double weight,
            string dataMember,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            var cell = this.ContainerControl.AddCell(weight);

            var binding = this.BaseReport is DetailReportBand ?
                cell.AddTextBinding(this.BaseReport.Report.JoinWithDataMember(dataMember)) :
                cell.AddTextBinding(this.BaseReport.JoinWithDataMember(dataMember));

            cell.SetFormatPercent(null, border, alignment);

            return this;
        }
        
        public DefaultGroupFooterHelper AddColumnPercent(
            double weight,
            string dataMember,
            string getVariation,
            string getDenominator,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            var cell = this.ContainerControl.AddCell(weight);

            var binding = cell.AddTextBinding(this.BaseReport.JoinWithDataMember(dataMember));

            cell.SetFormatPercent(null, border, alignment);

            cell.Summary = this.CreateSummary(SummaryFunc.Custom, binding.FormatString);

            new PercentGroupCalculationHelper(cell, getVariation, getDenominator);

            return this;
        }

        public DefaultGroupFooterHelper SetFormat(string formatString)
        {
            var cell = this.ContainerControl.GetLastCell();
            if (cell != null)
            {
                cell.SetFormat(formatString);
            }
            return this;
        }

        public DefaultGroupFooterHelper SetBorder(BorderSide border)
        {
            var cell = this.ContainerControl.GetLastCell();
            if (cell != null)
            {
                cell.SetBorder(border);
            }
            return this;
        }

        public DefaultGroupFooterHelper SetAlignment(TextAlignment alignment)
        {
            var cell = this.ContainerControl.GetLastCell();
            if (cell != null)
            {
                cell.SetAlignment(alignment);
            }
            return this;
        }

        public DefaultGroupFooterHelper AdjustBorderStyleFromDetail()
        {
            var detailBand = this.BaseReport.Bands.GetBandByType(typeof(DetailBand));
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
