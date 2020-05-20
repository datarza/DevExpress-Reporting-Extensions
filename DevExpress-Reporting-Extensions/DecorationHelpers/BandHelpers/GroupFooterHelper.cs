using System;
using System.Collections.Generic;
using System.Drawing;

using DevExpressReportingExtensions.DecorationHelpers.BaseClasses;
using DevExpressReportingExtensions.Extensions;

using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.DecorationHelpers
{
    public class GroupFooterHelper : BaseBandHelper<Band>
    {
        public SummaryRunning RunningBand { get; private set; }

        public XRTableRow ContainerControl { get; private set; }

        public XRControlStyle ContainerStyle { get; private set; }

        public IEnumerable<XRTableCell> Columns { get { return this.ContainerControl.Cells; } }
       
        public GroupFooterHelper(GroupFooterBand band)
            : base(band)
        {
            this.RunningBand = SummaryRunning.Group;
            this.InitializeContainer();
        }

        public GroupFooterHelper(ReportFooterBand band)
            : base(band)
        {
            this.RunningBand = SummaryRunning.Report;
            this.InitializeContainer();
        }

        public GroupFooterHelper(PageFooterBand band)
            : base(band)
        {
            this.RunningBand = SummaryRunning.Page;
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

        private XRSummary CreateSummary(SummaryFunc summaryFunc,
            string formatString = null)
        {
            var result = new XRSummary
            {
                Running = this.RunningBand,
                Func = summaryFunc,
                IgnoreNullValues = true,
            };

            if (!string.IsNullOrWhiteSpace(formatString))
            {
                result.FormatString = formatString;
            }

            return result;
        }

        public GroupFooterHelper AddColumn(double weight,
            BorderSide? border = null)
        {
            var cell = this.ContainerControl.AddCell(weight);
            if (border.HasValue)
            {
                cell.SetBorder(border.Value);
            }
            return this;
        }

        public GroupFooterHelper AddColumn(
            double weight,
            string dataMember,
            SummaryFunc? summaryFunc = null,
            string formatString = null,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            var cell = this.ContainerControl.AddCell(weight);

            var binding = cell.AddTextBinding(this.Report.JoinWithDataMember(dataMember));

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

        public GroupFooterHelper AddColumnCount(
            double weight,
            string dataMember,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            var cell = this.ContainerControl.AddCell(weight);

            var binding = cell.AddTextBinding(this.Report.JoinWithDataMember(dataMember));

            cell.SetFormatCount(null, border, alignment);

            cell.Summary = this.CreateSummary(SummaryFunc.Count, binding.FormatString);

            return this;
        }

        public GroupFooterHelper AddColumnNumber(
            double weight,
            string dataMember,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            var cell = this.ContainerControl.AddCell(weight);

            var binding = cell.AddTextBinding(this.Report.JoinWithDataMember(dataMember));

            cell.SetFormatNumber(null, border, alignment);

            cell.Summary = this.CreateSummary(SummaryFunc.Sum, binding.FormatString);

            return this;
        }

        public GroupFooterHelper AddColumnMoney(
            double weight,
            string dataMember,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            var cell = this.ContainerControl.AddCell(weight);

            var binding = cell.AddTextBinding(this.Report.JoinWithDataMember(dataMember));

            cell.SetFormatMoney(null, border, alignment);

            cell.Summary = this.CreateSummary(SummaryFunc.Sum, binding.FormatString);

            return this;
        }

        public GroupFooterHelper AddColumnPercent(
            double weight,
            string dataMember,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            var cell = this.ContainerControl.AddCell(weight);

            var binding = this.Report is DetailReportBand ?
                cell.AddTextBinding(this.Report.Report.JoinWithDataMember(dataMember)) :
                cell.AddTextBinding(this.Report.JoinWithDataMember(dataMember));

            cell.SetFormatPercent(null, border, alignment);

            return this;
        }

        public GroupFooterHelper AddColumnPercent<T>(
            double weight,
            string dataMember,
            Func<T, decimal?> numeratorGetValue,
            Func<T, decimal?> denominatorGetValue,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            var cell = this.ContainerControl.AddCell(weight);

            var binding = cell.AddTextBinding(this.Report.JoinWithDataMember(dataMember));

            cell.SetFormatPercent(null, border, alignment);

            cell.Summary = this.CreateSummary(SummaryFunc.Custom, binding.FormatString);

            new PercentGroupCalculationHelper<T>(cell, numeratorGetValue, denominatorGetValue);

            return this;
        }

        public GroupFooterHelper AddColumnPercent(
            double weight,
            string dataMember,
            string numeratorColumnName,
            string denominatorColumnName,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            var cell = this.ContainerControl.AddCell(weight);

            var binding = cell.AddTextBinding(this.Report.JoinWithDataMember(dataMember));

            cell.SetFormatPercent(null, border, alignment);

            cell.Summary = this.CreateSummary(SummaryFunc.Custom, binding.FormatString);

            new PercentGroupCalculationHelper(cell, numeratorColumnName, denominatorColumnName);

            return this;
        }

        public GroupFooterHelper SetFormat(string formatString)
        {
            var cell = this.ContainerControl.GetLastCell();
            if (cell != null)
            {
                cell.SetFormat(formatString);
            }
            return this;
        }

        public GroupFooterHelper SetBorder(BorderSide border)
        {
            var cell = this.ContainerControl.GetLastCell();
            if (cell != null)
            {
                cell.SetBorder(border);
            }
            return this;
        }

        public GroupFooterHelper SetAlignment(TextAlignment alignment)
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
