using System;
using System.Collections.Generic;
using System.Drawing;

using DevExpressReportingExtensions.Reports;

using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace DevExpressReportingExtensions.Helpers
{
    public class DefaultGridHelper : BaseDetailReportHelper
    {
        public readonly DetailBand ContainerBand;

        public readonly XRTableRow ContainerControl;

        public IEnumerable<XRTableCell> Columns { get { return this.ContainerControl.Cells; } }
        
        public DefaultGridHelper(XtraReport report, XtraReportBase detailReport = null)
            : base(report, detailReport)
        {
            this.ContainerBand = this.CreateContainerBand();
            this.ContainerControl = this.CreateContainerControls();
        }

        protected virtual DetailBand CreateContainerBand()
        {
            var result = this.BaseReport.GetBandByType<DetailBand>();
            if (result == null)
            {
                result = new DetailBand()
                {
                    HeightF = 0F,
                };
                this.BaseReport.Bands.Add(result);
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
            var styleName = $"{nameof(DefaultGridHelper)}_{nameof(DetailBand)}";
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

        public DefaultGridHelper AddColumn(
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

        public DefaultGridHelper AddColumn(
            double weight,
            string dataMember,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            return this.AddColumn(weight, dataMember, null, border, alignment);
        }

        public DefaultGridHelper AddColumn(
            double weight,
            string dataMember,
            TextAlignment alignment)
        {
            return this.AddColumn(weight, dataMember, null, null, alignment);
        }

        public DefaultGridHelper AddColumnDate(
            double weight,
            string dataMember,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            var cell = this.AddColumn(weight, dataMember);

            cell.SetFormatDate(null, border, alignment);

            return this;
        }

        public DefaultGridHelper AddColumnDateTime(
            double weight,
            string dataMember,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            var cell = this.AddColumn(weight, dataMember);

            cell.SetFormatDateTime(null, border, alignment);

            return this;
        }

        public DefaultGridHelper AddColumnNumber(
            double weight,
            string dataMember,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            var cell = this.AddColumn(weight, dataMember);

            cell.SetFormatNumber(null, border, alignment);

            return this;
        }

        public DefaultGridHelper AddColumnMoney(
            double weight,
            string dataMember,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            var cell = this.AddColumn(weight, dataMember);

            cell.SetFormatMoney(null, border, alignment);

            return this;
        }

        public DefaultGridHelper AddColumnPercent(
            double weight,
            string dataMember,
            BorderSide? border = null,
            TextAlignment? alignment = null)
        {
            var cell = this.AddColumn(weight, dataMember);

            cell.SetFormatPercent(null, border, alignment);

            return this;
        }

        public DefaultGridHelper SetFormat(string formatString)
        {
            var cell = this.ContainerControl.GetLastCell();
            if (cell != null)
            {
                cell.SetFormat(formatString);
            }
            return this;
        }

        public DefaultGridHelper SetBorder(BorderSide border)
        {
            var cell = this.ContainerControl.GetLastCell();
            if (cell != null)
            {
                cell.SetBorder(border);
            }
            return this;
        }

        public DefaultGridHelper SetAlignment(TextAlignment alignment)
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
