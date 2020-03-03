using System.Collections.Generic;
using System.Drawing;

using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

using DevExpressReportingExtensions.Helpers.BaseClasses;
using DevExpressReportingExtensions.Reports;

namespace DevExpressReportingExtensions.Helpers
{
    public class GridCaptionsHelper : BaseReportHelper
    {
        public Band ContainerBand { get; protected set; }

        public XRTableRow ContainerControl { get; protected set; }

        public IEnumerable<XRTableCell> Columns { get { return this.ContainerControl.Cells; } }

        public GridCaptionsHelper(XtraReport report, SubBand band = null)
            : base(report)
        {
            this.ContainerBand = band ?? this.CreateContainerBand();
            this.ContainerBand.StyleName = this.CreateContainerBandStyle();
            this.ContainerControl = this.CreateContainerControls();
        }

        protected virtual Band CreateContainerBand()
        {
            Band result = this.RootReport.GetBandByType<PageHeaderBand>();
            if (result == null)
            {
                result = new PageHeaderBand()
                {
                    HeightF = 0F,
                };
                this.RootReport.Bands.Add(result);
            }
            else
            {
                if (result.Controls.Count > 0)
                {
                    SubBand subresult = new SubBand()
                    {
                        HeightF = 0F,
                    };
                    result.SubBands.Add(subresult);
                    result = subresult;
                }
                else
                {
                    result.HeightF = 0F;
                }
            }
            return result;
        }

        protected virtual string CreateContainerBandStyle()
        {
            var styleName = $"{nameof(GridCaptionsHelper)}_{this.ContainerBand.GetType().Name}";
            this.RootReport.StyleSheet.Add(new XRControlStyle()
            {
                Name = styleName,
                ForeColor = Color.DimGray,
                BackColor = Color.Transparent,
                BorderColor = Color.LightGray,
                Borders = BorderSide.Bottom | BorderSide.Top,
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

        public GridCaptionsHelper AddColumn(
           double weight,
           BorderSide? border = null,
           TextAlignment? alignment = null)
        {
            this.AddColumn(weight, string.Empty, border, alignment);

            return this;
        }

        public GridCaptionsHelper AddColumn(
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

        public GridCaptionsHelper AddColumnDate(
           double weight,
           string text,
           BorderSide? border = null,
           TextAlignment? alignment = null)
        {
            var cell = this.AddColumn(weight, text);

            cell.SetFormatDate(null, border, alignment);

            return this;
        }

        public GridCaptionsHelper AddColumnDateTime(
           double weight,
           string text,
           BorderSide? border = null,
           TextAlignment? alignment = null)
        {
            var cell = this.AddColumn(weight, text);

            cell.SetFormatDateTime(null, border, alignment);

            return this;
        }

        public GridCaptionsHelper AddColumnNumber(
           double weight,
           string text,
           BorderSide? border = null,
           TextAlignment? alignment = null)
        {
            var cell = this.AddColumn(weight, text);

            cell.SetFormatNumber(null, border, alignment);

            return this;
        }

        public GridCaptionsHelper AddColumnMoney(
           double weight,
           string text,
           BorderSide? border = null,
           TextAlignment? alignment = null)
        {
            var cell = this.AddColumn(weight, text);

            cell.SetFormatMoney(null, border, alignment);

            return this;
        }

        public GridCaptionsHelper AddColumnPercent(
           double weight,
           string text,
           BorderSide? border = null,
           TextAlignment? alignment = null)
        {
            var cell = this.AddColumn(weight, text);

            cell.SetFormatPercent(null, border, alignment);

            return this;
        }

        public GridCaptionsHelper SetBorder(BorderSide border)
        {
            var cell = this.ContainerControl.GetLastCell();
            if (cell != null)
            {
                cell.SetBorder(border);
            }
            return this;
        }

        public GridCaptionsHelper SetAlignment(TextAlignment alignment)
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
